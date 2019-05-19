using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrayonTest.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected virtual IActionResult SingleObject<T>(T data)
        {
            return new ObjectResult(data);
        }
    }
}