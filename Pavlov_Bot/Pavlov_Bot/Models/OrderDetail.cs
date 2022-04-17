using System;
using System.Collections.Generic;

#nullable disable

namespace Pavlov_Bot
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SneakerId { get; set; }
        public long Price { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string SneakerName { get; set; }
        public string Surname { get; set; }

        public virtual Order Order { get; set; }
        public virtual Sneaker Sneaker { get; set; }
    }
}
