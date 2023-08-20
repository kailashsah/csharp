using ApiKeyAuth.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiKeyAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesApiController : ControllerBase
    {
        private readonly string[] names = {"Tom","Parth" };
        [ApiKeyAuth]
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(names);
        }
    }
}
