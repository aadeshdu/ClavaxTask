using System.ComponentModel.DataAnnotations;

namespace Clavaxtask.Models
{
    public class Employee
    {
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string EmployeeDOB { get; set; }

        [Required]
        public string EmployeeGender { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string EmployeeAddress { get; set; }

        public string State { get; set; }

    


    }
}
