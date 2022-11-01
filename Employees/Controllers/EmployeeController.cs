using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employees.ModelCrt;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using Employees.Services;
using Employees.Dto.Employee;
using Employees.Data;
using Microsoft.EntityFrameworkCore;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeservice;
        
        public EmployeeController(IEmployeeServices employeeservice)
        {
            _employeeservice = employeeservice;           
        }
        [HttpGet("GetBy{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeservice.Get(id));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetAll()
        {
            return Ok(await _employeeservice.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Add(AddEmployeeDto newemployee)
        {
            return Ok(await _employeeservice.Add(newemployee));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> Update(int ID,UpdateEmployeeDto updatedEmployee)
        {
            var response = await (_employeeservice.Update(ID,updatedEmployee));
            if(response == null)
            {
                return NotFound(response);
            } 
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Delete(int id)
        {
            return Ok(await _employeeservice.Delete(id));
        }
    }
}
