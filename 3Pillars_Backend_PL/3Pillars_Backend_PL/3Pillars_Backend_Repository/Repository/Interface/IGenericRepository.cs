using _3Pillars_Backend_BLL.Specifications.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3Pillars_Backend_Repository.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        Task<int> Add(T entity);                                               //  Add Function which take Generic entity 
        Task<int> Update(T entity);                                           //  Update Function which take Generic entity
        Task<int> Delete(T entity);                                          //  Delete Function which take Generic entity
        Task<IReadOnlyList<T>> GetAllAsync();                                //  GetAll Function 
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec); // GetAll Function With Specification
        Task<T> GetByIdAsync(int id);                                     // GetById Function
        Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);           // GetById Function with Specification
    }
}
