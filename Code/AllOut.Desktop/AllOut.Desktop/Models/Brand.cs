﻿using System;

namespace AllOut.Desktop.Models
{
    public class Brand
    {
        public Guid BrandID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
