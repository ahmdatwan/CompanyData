using System.ComponentModel.DataAnnotations;

namespace CompanyData.BLL.Models
{
    public class EmployeeForCreationDTO
    {
        [Required(ErrorMessage ="You should provide an employee name!")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage ="You should provide an employee job!")]
        public string Job { get; set; }
        public double Salary { get; set; }

        public int DepartmentId { get; set; }
    }
}
