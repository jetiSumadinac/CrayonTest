using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CrayonTest.Models.InputModels;
using CrayonTest.Models.OutputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("proof-of-concept")]
        public async Task<IActionResult> ProofOfConcept([FromBody]InputExchangeDataModel data) 
        {
            HttpClient httpClient = new HttpClient();

            DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss");

            var sortedDates = SortDatesAscending(data.Dates);
            var firstDate = sortedDates.First().ToString("yyyy-MM-dd");
            var lastDate = sortedDates.Last().ToString("yyyy-MM-dd");
            string url = $"https://api.exchangeratesapi.io/history?symbols={data.BaseCurr},{data.TargetCurr}&base={data.BaseCurr}&start_at={firstDate}&end_at={lastDate}";

            var response = await httpClient.GetAsync(url); //TODO: URL should be localized
            var result = await response.Content.ReadAsAsync<ResponseRatesModel>();

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