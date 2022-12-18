using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class CurrentProductList : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
