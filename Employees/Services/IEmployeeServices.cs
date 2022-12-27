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
        Task<ServiceResponse<List<GetEmployeeDto>>> Update(int ID, UpdateEmployeeDto updatedEmployee);
        Task<ServiceResponse<List<GetEmployeeDto>>> Delete (int id);
        Task<ServiceResponse<List<GetEmployeeDto>>> GetBirthdays();
        Task<ServiceResponse<List<GetEmployeeDto>>> GetAllSortBySurname();
        Task<ServiceResponse<List<GetEmployeeDto>>> GetAllSortByBirthDate();
    }
}
