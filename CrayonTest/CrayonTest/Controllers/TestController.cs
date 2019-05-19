using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CrayonTest.Interfaces.RatesServices;
using CrayonTest.Models.InputModels;
using CrayonTest.Models.OutputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrayonTest.Controllers
{
    public class BaseCurrencies
    {
        public string Base { get; set; }
        public Dictionary<string, string> Rates { get; set; }
        public DateTime Date { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IRatesService _ratesService;
        public TestController(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        [HttpPost("test-post")]
        public async Task<IActionResult> Test()
        {
            return Ok("Helooo from test!");
        }

        [HttpGet("test-http-client")]
        public async Task<IActionResult> TestHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.exchangeratesapi.io/latest"); //TODO: URL should be localized
            var result = await response.Content.ReadAsAsync<BaseCurrencies>();

            return Ok(result);
        }

        [HttpGet("proof-of-concept")]
        public async Task<IActionResult> ProofOfConcept([FromBody]InputExchangeDataModel data)
        {
            var result = await _ratesService.GetRates(data);
            return Ok(result);
        }

        #region private methods
        static List<DateTime> SortDatesAscending(List<DateTime> list)
        {
            list.Sort((a, b) => a.CompareTo(b));
            return list;
        }
        #endregion
    }
}