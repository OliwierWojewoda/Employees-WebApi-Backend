using Employees.Dto.Employee;
using Employees.ModelCrt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Employees.Services
{
    public interface IEmployeeServices
    {
        Task<ServiceResponse<GetEmployeeDto>> Get(int id);
        Task<ServiceResponse<List<GetEmployeeDto>>> GetAll();
        Task<ServiceResponse<List<GetEmployeeDto>>> Add(AddEmployeeDto newemployee);
        Task<ServiceResponse<GetEmployeeDto>> Update(UpdateEmployeeDto updatedEmployee);
        Task<ServiceResponse<List<GetEmployeeDto>>> Delete (int id);
    }
}
