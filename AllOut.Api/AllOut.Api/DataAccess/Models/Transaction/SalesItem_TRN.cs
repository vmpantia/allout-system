﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models.Transaction
{
    [PrimaryKey(nameof(RequestID), nameof(Number))]
    public class SalesItem_TRN
    {
        [MaxLength(12)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid SalesID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
