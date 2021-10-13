using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichWishList.Models
{
    public class WishListDBContext : DbContext
    {
        public WishListDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WishListItem> WishList { get; set; }
    }
}
