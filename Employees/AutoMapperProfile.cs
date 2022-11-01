using AutoMapper;
using Employees.Dto.Employee;
using Employees.ModelCrt;
using System.Security.Cryptography.Xml;

namespace Employees
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
