using _3Pillars_Backend_BLL.Specifications.Class;
using _3Pillars_Backend_BLL.Specifications.Interface;
using _3Pillars_Backend_DAL.Data;
using _3Pillars_Backend_DAL.Entities;
using _3Pillars_Backend_Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Pillars_Backend_Repository.Repository.Class
{
    // GenericRepository mn No3 Generic  implements Interface IGenericRepository 
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
    {
        private readonly AddressBookContext context; // Reference From AddressBookContext 
        public GenericRepository(AddressBookContext context) // Inject Constructor To Promots Dependency Injection
        {
            this.context = context;
        }

        public async Task<int> Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<int> Update(T entity)
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<int> Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync(); throw new NotImplementedException();
        }

        public IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);
        }
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

       
    }
}
