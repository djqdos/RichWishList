using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichWishList.Models
{
    public class WishListItem
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
