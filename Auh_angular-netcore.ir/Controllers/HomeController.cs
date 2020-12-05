using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Auh_angular_netcore.ir.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]



    public class HomeController 
    {
        private IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("HellowWorld")]
        public string HellowWorld()
        {
            return ("salam");
        }







      

   

    }
}
