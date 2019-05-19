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
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IRatesService _ratesService;
        public TestController(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        [HttpGet("proof-of-concept")]
        public async Task<IActionResult> ProofOfConcept([FromBody]InputExchangeDataModel data)
        {
            var result = await _ratesService.GetRates(data);
            return Ok(result);
        }
    }
}