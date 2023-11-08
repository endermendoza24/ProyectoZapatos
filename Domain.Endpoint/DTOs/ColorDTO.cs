using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateColorDTO
    {
        public string ID_COLOR { get; set; }
        string NOMBRE_COLOR { get; set; }
    }

    public class UpdateColorDTO
    {
        public string ID_COLOR { get; set; }
        public string NOMBRE_COLOR { get; set; }
    }
}
