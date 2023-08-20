using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.webapi.two.Filters;

namespace WebApplication1.webapi.two.Controllers
{
    //[Authorize(Roles ="Admin")]
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class NamesApiController : ControllerBase
    {
        private readonly string [] arr = { "a", "b" };
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return arr.ToList();
        }
        
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[ApiKeyAuth]
        [HttpGet("{id}")]
        public string GetAtIndex(int index)
        {
            return arr[index];
        }
    }
}
