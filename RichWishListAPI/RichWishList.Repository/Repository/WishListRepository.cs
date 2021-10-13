using Microsoft.EntityFrameworkCore;
using RichWishList.Models;
using RichWishList.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichWishList.Repository.Repository
{
    public class WishListRepository : IRepositoryBase<WishListItem>
    {
        private WishListDBContext _ctx;

        public WishListRepository(WishListDBContext dbContext)
        {
            _ctx = dbContext;
        }

        public async Task<WishListItem> Create(WishListItem item)
        {
            
            _ctx.WishList.Add(item);
            await _ctx.SaveChangesAsync();
            return item;       
        }

        public async Task<WishListItem> Get(Guid id)
        {
            var result = await _ctx.WishList.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<WishListItem>> GetAll()
        {
            var results = await _ctx.WishList.ToListAsync();
            return results;
        }

        public async Task<string> Update(WishListItem item)
        {
            var response = _ctx.WishList.Update(item);
            await _ctx.SaveChangesAsync();
            return response.State.ToString(); 
        }

        public async Task<string> Delete(Guid id)
        {
            var item = await _ctx.WishList.FirstOrDefaultAsync(x => x.Id == id);
            if (item is null)
            {
                return "NotFound";
            }
            var response = _ctx.WishList.Remove(item);            
            await _ctx.SaveChangesAsync();
            return response.State.ToString();
        }
    }
}
