using System.Collections.Generic;
using System.Linq;
using Jimismith.Versioning.Example.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jimismith.Versioning.Example.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")]
    [Route("api/values")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IEnumerable<string> GetV1(string query)
        {
            return new int[] { 1, 2, 3 }.Select(i => $"{query}-{i}");
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        public V1_1ViewModel GetV1_1(string query)
        {
            return new V1_1ViewModel {
                Result = new int[] { 1, 2, 3 }.Select(i => $"{query}-{i}")
            };
        }
        [HttpGet("all")]
        public IEnumerable<string> GetAll(string query)
        {
            return new int[] { 1, 2, 3 }.Select(i => $"{query}-{i}");
        }
    }
}
