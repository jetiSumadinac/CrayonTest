using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrayonTest.Controllers
{
    public class BaseCurrencies {
        public string Base { get; set; }
        public Dictionary<string, string> Rates { get; set; }
        public DateTime Date { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
       
        public TestController()
        {
        }

        [HttpPost("test-post")]
        public async Task<IActionResult> Test()
        {
            return Ok("penis");
        }

        [HttpGet("test-http-client")]
        public async Task<IActionResult> TestHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.exchangeratesapi.io/latest"); //TODO: URL should be localized
            var result = await response.Content.ReadAsAsync<BaseCurrencies>();

            return Ok(result);
        }
        
    }
}