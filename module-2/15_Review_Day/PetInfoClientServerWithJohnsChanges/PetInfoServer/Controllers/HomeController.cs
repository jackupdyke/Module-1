﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        //GET: /
        [HttpGet]
        public string Ready()
        {
            return "The server is ready.";
        }
    }
}
