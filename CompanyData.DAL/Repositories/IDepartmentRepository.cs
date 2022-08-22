using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyData.DAL.Entities;

namespace CompanyData.DAL.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<bool> DepartmentExists(int id);
        Task<bool> IsDepartmentEmpty(int id);
        Task<IEnumerable<Employee>> GetEmployees(int id);
    }
}
