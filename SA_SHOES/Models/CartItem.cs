﻿using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_SHOES.Models
{
    [Serializable]
    public class CartItem
    {
        
        public Product Product { set; get; }
        public int Quantity { set; get; }
        public int Size { set; get; }
    }
}