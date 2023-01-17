﻿using System;

namespace AllOut.Desktop.Models
{
    public class SalesItem
    {
        public string SalesID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
