using System;
using System.Collections.Generic;

#nullable disable

namespace Pavlov_Bot
{
    public partial class Category
    {
        public Category()
        {
            Sneakers = new HashSet<Sneaker>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }

        public virtual ICollection<Sneaker> Sneakers { get; set; }
    }
}
