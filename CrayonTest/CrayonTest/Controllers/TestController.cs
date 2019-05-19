using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        public TestController()
        {
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
            HttpClient httpClient = new HttpClient();

            var sortedDates = SortDatesAscending(data.Dates);
            var firstDate = sortedDates.First().ToString("yyyy-MM-dd");
            var lastDate = sortedDates.Last().ToString("yyyy-MM-dd");
            string url = $"https://api.exchangeratesapi.io/history?symbols={data.BaseCurr},{data.TargetCurr}&base={data.BaseCurr}&start_at={firstDate}&end_at={lastDate}";

            var response = await httpClient.GetAsync(url); //TODO: URL should be localized
            var responseObject = await response.Content.ReadAsAsync<ResponseRatesModel>();

            List<double> _rates = new List<double>();
            double min = Double.MaxValue;
            double max = 0;
            DateTime dateOnMax = DateTime.UnixEpoch, dateOnMin = DateTime.UnixEpoch;
            foreach (var r in responseObject.Rates)
            {
                if (r.Value.Values.First() > max)
                {
                    max = r.Value.Values.First();
                    dateOnMax = r.Key;
                }
                else if (r.Value.Values.First() < min)
                {
                    min = r.Value.Values.First();
                    dateOnMin = r.Key;
                }
                _rates.Add(r.Value.Values.First());
            }
            var result = new ReturnModel //TODO: Constructor
            {
                AverageValue = _rates.Average(),
                MaxExchangeRate = max,
                MinExchangeRate = min,
                DateOnMaxRate = dateOnMax,
                DateOnMinRate = dateOnMin,
            };
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