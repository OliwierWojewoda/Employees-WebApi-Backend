using Employees.ModelCrt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Employees.Controllers;
using Employees.Dto.Employee;
using AutoMapper;
using System.Collections.Generic;
using Employees.Data;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public EmployeeServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        } 
        public async Task<ServiceResponse<List<GetEmployeeDto>>> Add(AddEmployeeDto newemployee)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            await _context.Employees.ToListAsync();
            Employee employee = _mapper.Map<Employee>(newemployee);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> Get(int id)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeDto>();
            var employee = _context.Employees.FirstOrDefault(c => c.ID == id);
            serviceResponse.Data = _mapper.Map<GetEmployeeDto>(employee);
            return serviceResponse;
        } 

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAll()
        {
            return new ServiceResponse<List<GetEmployeeDto>> 
            { 
                Data = _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToList()
            };
        }
        public async Task<ServiceResponse<GetEmployeeDto>> Update(UpdateEmployeeDto updatedEmployee)
        {
            ServiceResponse<GetEmployeeDto> response = new ServiceResponse<GetEmployeeDto>();
            try
            {
                var employee = _context.Employees.FirstOrDefault(c => c.ID == updatedEmployee.ID);
                // employee.Name = updatedEmployee.Name
                _mapper.Map(updatedEmployee, employee);
                response.Data = _mapper.Map<GetEmployeeDto>(employee);
                await _context.SaveChangesAsync();  
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<List<GetEmployeeDto>>> Delete(int id)
        {
           ServiceResponse<List<GetEmployeeDto>> response = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                Employee employee = _context.Employees.First(c => c.ID == id);
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                response.Data = _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
