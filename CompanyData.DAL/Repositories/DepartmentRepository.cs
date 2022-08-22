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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CompanyDataContext context) : base(context)
        {

        }
        public async Task<bool> DepartmentExists(int id)
        {
            return await _context.Departments.AnyAsync(department => department.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees(int id)
        {
            return await _context.Employees.Where(employee => employee.DepartmentId == id).ToListAsync();
        }

        public async Task<bool> IsDepartmentEmpty(int id)
        {
            return await _context.Employees.AnyAsync(emp => emp.DepartmentId == id);

        }
    }
}
