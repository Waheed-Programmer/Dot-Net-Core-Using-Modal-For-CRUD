using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeContact { get; set; }
        public string EmployeeAddress { get; set; }

        [ForeignKey("Departments")]
        public int? DepartmentId { get; set; }
        public virtual Department Departments { get; set; }

    }
}
