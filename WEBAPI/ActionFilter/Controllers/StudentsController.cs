using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Simple.Filters;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [Example ("Controller student", 0)]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly string[] students = { "aaa", "bbb" };
        
        [Example("Method Get", -1)]
        public IActionResult Get()
        {
            return Ok(students);
        }


        [HttpGet("{index:int}")]
        public ActionResult GetStudent(int index)
        {
            try
            {
                return Ok(students[index]);

            }
            catch (Exception ex)
            {
                //return StatusCode( StatusCodes.Status501NotImplemented, ex.Message);
                return NotFound(ex.Message);
            }
        }

        [ExAsyncFilter]
        [HttpGet("{find}")]
        public ActionResult GetStudentQuery(int stu)
        {
            return Ok("query handler");
        }
    }
}
