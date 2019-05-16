using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrayonTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
       
        public TestController()
        {
        }

        [HttpPost("test-post")]
        public IActionResult Test()
        {
            return Ok("penis");
        }
        
    }
}