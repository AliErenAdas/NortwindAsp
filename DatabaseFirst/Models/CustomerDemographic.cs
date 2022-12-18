using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models
{
    public partial class CustomerDemographic : IEntity
    {
        public CustomerDemographic()
        {
            Customers = new HashSet<Customer>();
        }

        public string CustomerTypeId { get; set; } = null!;
        public string? CustomerDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
