using RichWishList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichWishList.Repository.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();

        Task<string> Update(T item);

        Task<T> Create(T item);

        Task<string> Delete(Guid id);
    }
}
