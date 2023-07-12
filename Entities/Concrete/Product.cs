﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    // public bu classa diğer katlamnlarda ulaşsın demek
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string  ProductName { get; set; }
        public short UnıtsInStock { get; set; }
        public decimal UnitPrice { get; set; }

    }
}