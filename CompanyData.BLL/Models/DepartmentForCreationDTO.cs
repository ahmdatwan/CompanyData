using System.ComponentModel.DataAnnotations;

namespace CompanyData.BLL.Models
{
    public class DepartmentForCreationDTO
    {
        [Required(ErrorMessage = "You should provide a department name!")]
        public string Name { get; set; }
        public string? Location { get; set; }
    }
}
