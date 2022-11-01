using Employees.ModelCrt;

namespace Employees.Dto.Employee
{
    public class AddEmployeeDto
    {
        public string Name { get; set; } = "Jan";
        public string SurName { get; set; } = "Kowalski";
        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }
        public Position position { get; set; } = Position.Physical;

    
    }
}
