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
            var response = await _employeeservice.Get(id);
            return Ok(response.Data);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetAll()
        {
            return Ok(await _employeeservice.GetAll());

        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Add(AddEmployeeDto newemployee)
        {
            var response = await _employeeservice.Add(newemployee);
            return Ok(response.Data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> Update(int id, UpdateEmployeeDto updatedEmployee)
        {
            var response = await (_employeeservice.Update(id,updatedEmployee));
            if(response == null)
            {
                return NotFound(response);
            } 
            return Ok(response.Data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> Delete(int id)
        {
            var response = await _employeeservice.Delete(id);
            return Ok(response.Data);
        }
        [HttpGet("GetBirthdays")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetBirthdays()
        {
            return Ok(await _employeeservice.GetBirthdays());
        }
        [HttpGet("SurnameSorted")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetAllSortBySurname()
        {
            return Ok(await _employeeservice.GetAllSortBySurname());
        }
        [HttpGet("BirthDaySorted")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDto>>>> GetAllSortByBirthDate()
        {
            return Ok(await _employeeservice.GetAllSortByBirthDate());
        }
    }
}
