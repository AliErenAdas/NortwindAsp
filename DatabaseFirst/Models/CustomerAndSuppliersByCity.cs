using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class CustomerAndSuppliersByCity : IEntity
    {
        public string? City { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string Relationship { get; set; } = null!;
    }
}
