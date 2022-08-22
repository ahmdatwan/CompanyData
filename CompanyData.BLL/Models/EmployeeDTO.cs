namespace CompanyData.BLL.Models
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Job { get; set; }
        public double Salary { get; set; }

        public int DepartmentId { get; set; }

    }
}
