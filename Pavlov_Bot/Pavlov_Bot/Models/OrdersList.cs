using System;
using System.Collections.Generic;

#nullable disable

namespace Pavlov_Bot
{
    public partial class OrdersList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
