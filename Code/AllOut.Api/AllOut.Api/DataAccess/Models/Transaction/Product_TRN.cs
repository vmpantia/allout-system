﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(ProductID))]
    public class Product_TRN
    {
        [MaxLength(15)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid ProductID { get; set; }
        public Guid BrandID { get; set; }
        public Guid CategoryID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public int ReorderPoint { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
