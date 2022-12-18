using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class OrderSubtotal : IEntity
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
