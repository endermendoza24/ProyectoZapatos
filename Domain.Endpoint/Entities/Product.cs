using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Endpoint.Entities
{
    public class Product : AuditableEntity
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
