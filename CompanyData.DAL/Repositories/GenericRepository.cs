using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyData.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CompanyData.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        protected readonly CompanyDataContext _context;
        private DbSet<T>? table = null;
        public GenericRepository(CompanyDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            table = context.Set<T>();

        }

        public void DeleteAsync(T entity)
        {

            table.Remove(entity);


        }



        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);

        }
        public void Insert(T entity)
        {
            table.Add(entity);

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
