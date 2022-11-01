using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

namespace Employees.ModelCrt
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; } = "Jan";
        public string SurName { get; set; } = "Kowalski";
        public DateTime BirthDate { get; set; }
        
        public string Phone { get; set; }
        public Position position { get; set; } = Position.Physical;
       
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Position
    {
        Physical, Manager, Developer,
    }
}
