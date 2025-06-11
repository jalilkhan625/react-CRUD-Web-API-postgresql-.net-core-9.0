using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees_API.Models
{
    [Table("employees")]
    public class Employee
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string position { get; set; }

        private DateTime _dateofbirth;
        public DateTime dateofbirth
        {
            get => _dateofbirth;
            set => _dateofbirth = value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
                : value.ToUniversalTime();
        }

        public int experience { get; set; }
        public string skill { get; set; }
        public decimal hourlyrate { get; set; }
        public byte[]? photo { get; set; }
    }
}