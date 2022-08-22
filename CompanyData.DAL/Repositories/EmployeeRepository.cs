using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyData.DAL.DbContexts;
using CompanyData.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyData.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyDataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetDepartmentEmployees(int id)
        {

            return await _context.Employees.Where(employee => employee.DepartmentId == id).ToListAsync();
        }

        public void Insert(Employee employee, Department department)
        {
            department.Employees.Add(employee);
        }
    }
}
