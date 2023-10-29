using System;

namespace Domain.Endpoint.Entities
{
    public class InvoiceDetail : BaseEntity, IHaveCreationData
    {
        public Guid InvoiceId { get; set; }
        public Guid? ProductDetailId { get; set; }
        public Guid? DishId { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}