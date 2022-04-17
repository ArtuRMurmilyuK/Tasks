using System;
using System.Collections.Generic;

#nullable disable

namespace Pavlov_Bot
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
