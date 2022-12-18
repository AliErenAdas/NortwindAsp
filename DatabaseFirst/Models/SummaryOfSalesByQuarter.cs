﻿using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class SummaryOfSalesByQuarter : IEntity
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
