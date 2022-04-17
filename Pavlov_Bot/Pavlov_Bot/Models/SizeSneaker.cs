using System;
using System.Collections.Generic;

#nullable disable

namespace Pavlov_Bot
{
    public partial class SizeSneaker
    {
        public int Id { get; set; }
        public int SneakerId { get; set; }
        public int Size { get; set; }
        public int Amount { get; set; }

        public virtual Sneaker Sneaker { get; set; }
    }
}
