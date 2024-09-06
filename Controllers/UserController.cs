using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("GetCurrentDateTime")]
        public IActionResult getDateTime()
        {
            var obj = new 
            {
                Date = DateTime.Now.ToLongDateString(),
                Hour = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }

        [HttpGet("Introduce/{name}")]
        public IActionResult introduce(string name)
        {
            var message = $"Olá, {name}. Seja bem vindo (a)!";
            return Ok(new {message});
        }
    }
}