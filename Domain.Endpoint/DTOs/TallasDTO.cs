using System;
using Domain.Endpoint.Entities;

namespace Domain.Talla.DTOs
{
    public class CreateTallasDto
    {
        public string ID_TALLA { get; set; }
        public string NumTalla { get; set; }
    }

    public class UpdateTallasDto
    {
        public string ID_TALLA { get; set; }
        public string NumTalla { get; set; }
    }
}
