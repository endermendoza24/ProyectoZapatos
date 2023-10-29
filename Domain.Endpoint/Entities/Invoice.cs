using System.Collections.Generic;

namespace Domain.Endpoint.Entities
{
    public class Invoice : AuditableEntity
    {
        public string Number { get; set; }
        public string CustomerName { get; set; }
        public string Notes { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
