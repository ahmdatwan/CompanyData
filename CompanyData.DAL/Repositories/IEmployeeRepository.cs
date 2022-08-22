using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyData.DAL.Entities;

namespace CompanyData.DAL.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetDepartmentEmployees(int id);
        void Insert(Employee employee, Department department);
    }
}
