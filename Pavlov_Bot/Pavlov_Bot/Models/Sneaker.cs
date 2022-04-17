using System;
using System.Collections.Generic;

#nullable disable

namespace Pavlov_Bot
{
    public partial class Sneaker
    {
        public Sneaker()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ShopCartItems = new HashSet<ShopCartItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool Available { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual SizeSneaker SizeSneaker { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ShopCartItem> ShopCartItems { get; set; }
    }
}
