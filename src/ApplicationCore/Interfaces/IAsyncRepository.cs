using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    //ürünleri saklayacağımız mantığa repository diyoruz
   public interface IAsyncRepository<T> where T :BaseEntity //baseentityden miras alan t lerle
    {
        Task<T> GetByIdAsync(int id);  //id si verilen entityi döndür   
        Task<List<T>> ListAllAsync();   //listeyi getirecek
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
    }
}
