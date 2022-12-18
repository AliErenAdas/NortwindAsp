using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class ProductsByCategory : IEntity
    {
        public string CategoryName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? QuantityPerUnit { get; set; }
        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
