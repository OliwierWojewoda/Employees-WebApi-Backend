using Employees.ModelCrt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Employees.Controllers;
using Employees.Dto.Employee;
using AutoMapper;
using System.Collections.Generic;
using Employees.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

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

        public async Task<ServiceResponse<GetEmployeeDto>> Get(int id)
        {
            var serviceResponse =  new ServiceResponse<GetEmployeeDto>();
            var employee =  _context.Employees.FirstOrDefault(c => c.ID == id);
             serviceResponse.Data =  _mapper.Map<GetEmployeeDto>(employee);
            return  serviceResponse;
        } 

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAll()
        {
            return new ServiceResponse<List<GetEmployeeDto>> 
            { 
                Data = await _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToListAsync()
            };
        }
        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetBirthdays()
        {
            var employees = await _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToListAsync();
            var list = new List<GetEmployeeDto>();
            var today = DateTime.Now;
            foreach (var employee in employees)
            {
                if (employee.BirthDate.Month == today.Month && employee.BirthDate.Day>today.Day)
                {
                    list.Add(employee);
                }
                else if(employee.BirthDate.Month == ((today.Month+1)%12) && employee.BirthDate.Day < today.Day)
                {
                    list.Add(employee);
                }
            }
            int doy = today.Month * 31 + today.Day;

            var result = list.OrderBy(a =>
                         (a.BirthDate.Month * 31 + a.BirthDate.Day) +
              (a.BirthDate.Month * 31 + a.BirthDate.Day > doy ? 0 : 400)).ToList();

            return new ServiceResponse<List<GetEmployeeDto>>
            {
                Data = result
            };
        }
        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllSortBySurname()
        {
            var employees = await _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToListAsync();
            return new ServiceResponse<List<GetEmployeeDto>>
            {
                Data = employees.OrderBy(x => x.SurName).ToList()
        };
        }
        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllSortByBirthDate()
        {
            var employees = await _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToListAsync();
            return new ServiceResponse<List<GetEmployeeDto>>
            {
                Data = employees.OrderBy(x => x.BirthDate).ToList()
        };
        }
        public async Task<ServiceResponse<List<GetEmployeeDto>>> Add(AddEmployeeDto newemployee)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            Employee employee = _mapper.Map<Employee>(newemployee);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetEmployeeDto>>> Update(int ID, UpdateEmployeeDto updatedEmployee)
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();           
            try
            {
                var employee = _context.Employees.Find(ID);
                _mapper.Map(updatedEmployee, employee);
                response.Data = _context.Employees.Select(c => _mapper.Map<GetEmployeeDto>(c)).ToList();
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
