using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.API.Repositories;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesApiController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(id);
                if (result == null)
                    return NotFound();
                else
                    return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee e)
        {
            try
            {
                if (e == null)
                {
                    return BadRequest();
                }
                var createdEmployee = await _employeeRepository.AddEmployee(e);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee e)
        {
            try
            {
                if (id != e.Id)
                {
                    return BadRequest($"emp {id} not found");
                }
                var emp = _employeeRepository.GetEmployee(id);
                if (emp == null)
                {
                    return NotFound($" {id} not found");
                }
                return await _employeeRepository.UpdateEmployees(e);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var emp = _employeeRepository.GetEmployee(id);
                if (emp == null)
                {
                    return NotFound($"emp {id} not found");
                }


                return await _employeeRepository.DeleteEmployees(id);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<Employee>> SearchEmployee(string name)
        {
            try
            {
                var result = await _employeeRepository.SearchEmployees(name);
                if (result.Any())
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving data");
            }

        }
    }
}
