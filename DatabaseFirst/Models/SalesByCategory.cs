using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class SalesByCategory : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal? ProductSales { get; set; }
    }
}
