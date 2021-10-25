using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MusicRecommender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FindRecommendationsController : ControllerBase
    {
        private static readonly string[] Recommendations = new[]
        {
             "Cool", "Hot"
        };

        public FindRecommendationsController()
        { }

        [HttpGet]
        public IEnumerable<string> Get() => Recommendations;
    }
}