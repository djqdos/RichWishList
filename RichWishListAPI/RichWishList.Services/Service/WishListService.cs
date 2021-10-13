using RichWishList.Models;
using RichWishList.Repository.Interface;
using RichWishList.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichWishList.Services.Service
{
    public class WishListService : IWishListService
    {
        private IRepositoryBase<WishListItem> _repo;        

        public WishListService(IRepositoryBase<WishListItem> repo)
        {
            _repo = repo;
        }


        public async Task<WishListItem> Create(WishListItem item)
        {
            var result = await _repo.Create(item);
            return result;
        }

        public Task<string> Delete(Guid id)
        {
            var response = _repo.Delete(id);
            return response;
        }

        public async Task<List<WishListItem>> GetAll()
        {
            var response = await _repo.GetAll();
            return response;
        }

        public async Task<WishListItem> GetById(Guid id)
        {
            var response = await _repo.Get(id);
            return response;
        }

        public async Task<string> Update(WishListItem item)
        {
            var response = await _repo.Update(item);
            return response;
        }
    }
}
