using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        void DeleteAsync(T entity);
        void Insert(T entity);



        public Task SaveChangesAsync();

    }
}
