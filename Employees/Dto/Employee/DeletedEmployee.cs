using Employees.ModelCrt;

namespace Employees.Dto.Employee
{
    public class DeletedEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }
        public Position position { get; set; }
    }
}
