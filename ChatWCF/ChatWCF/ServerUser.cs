﻿using System.ServiceModel;

namespace ChatWCF
{
    public class ServerUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OperationContext OperationContext { get; set; }
    }
}
