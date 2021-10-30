using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MusicRecommender.Common.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var status = HttpStatusCode.InternalServerError;
            var userMessage = "Internal server error occurred.";
            var exceptionType = context.Exception.GetType();
            var errorMessage = $"{userMessage}: {context.Exception.Message} {context.Exception.StackTrace}"; 

            _logger.LogError($"{errorMessage} {exceptionType}");

            context.ExceptionHandled = true;
            string userResponseMessage = PrepareUserResponseJson(userMessage, (int)status);
            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";

            response.WriteAsync(userResponseMessage);
        }

        private string PrepareUserResponseJson(string errorMessage, int statusCode)
        {
            return JsonConvert.SerializeObject(new ResponseEnvelop<Object>(statusCode, errorMessage, null));
        }
    }
}
