using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace Employees
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string Phone { get; set; }
        public Position position { get; set; }
    }
    public enum Position
    {
        Physical,Manager,Developer,
    }
}
