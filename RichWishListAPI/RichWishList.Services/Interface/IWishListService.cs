using RichWishList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichWishList.Services.Interface
{
    public interface IWishListService
    {
        Task<WishListItem> GetById(Guid id);

        Task<List<WishListItem>> GetAll();

        Task<string> Update(WishListItem item);

        Task<WishListItem> Create(WishListItem item);

        Task<string> Delete(Guid id);
    }
}
