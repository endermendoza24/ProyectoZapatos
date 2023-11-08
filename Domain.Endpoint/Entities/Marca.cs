using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Marca : BaseEntity
    {
        public string ID_MARCA { get; set; }
        public bool estado { get; set; }
        public string NOMBRE_MARCA { get; set; }
    }
}
