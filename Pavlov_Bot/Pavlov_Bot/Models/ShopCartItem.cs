using System;
using System.Collections.Generic;

#nullable disable

namespace Pavlov_Bot
{
    public partial class ShopCartItem
    {
        public int Id { get; set; }
        public int? SneakerId { get; set; }
        public int Price { get; set; }
        public string ShopCartId { get; set; }

        public virtual Sneaker Sneaker { get; set; }
    }
}
