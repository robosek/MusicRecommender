using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MusicRecommender.Common.Filter;
using MusicRecommender.Common.Service;
using MusicRecommender.Recommendation.Adapter.In;
using MusicRecommender.Recommendation.Adapter.Out.Spotify;
using MusicRecommender.Recommendation.Application;
using MusicRecommender.Recommendation.Domain;
using System.Reflection;

namespace MusicRecommender
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "cors",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyOrigin();
                                  });
            });

            services
                .AddControllers(config => config.Filters.Add(typeof(ExceptionFilter)))
                .ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new CustomControllerFeatureProvider());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicRecommender", Version = "v1" });
            });

            services.AddScoped<ICustomHttpService, CustomHttpService>();
            services.AddScoped<IMusicQuery, SpotifyService>();
            services.AddScoped<IFindRecommendationsUseCase, FindRecommendationsService>();
            services.AddScoped<ISortRecommendationsPolicy, SortByMatchPolicy>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicRecommender v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context => context.Response.WriteAsync("Music Recommender API"));
                endpoints.MapControllers();
            });
        }
    }

    internal class CustomControllerFeatureProvider : ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            var isCustomController = !typeInfo.IsAbstract && typeof(FindRecommendationsController).IsAssignableFrom(typeInfo);
            return isCustomController || base.IsController(typeInfo);
        }
    }
}