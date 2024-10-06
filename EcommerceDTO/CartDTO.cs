﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
    public class CartDTO
    {
        public ProductDTO? Product { get; set; }
        public int?Amount {  get; set; }

        public decimal? Price { get; set; }

        public decimal? Total {  get; set; }
    }
}
