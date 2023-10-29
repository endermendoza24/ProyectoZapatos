using System.Collections.Generic;

namespace Domain.Endpoint.Entities
{
    public class Dish : AuditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
