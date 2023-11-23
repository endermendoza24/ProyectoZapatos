using System;
using Domain.Endpoint.Entities;

namespace Domain.Talla.DTOs
{
    public class CreateTallasDto
    {
        public int ID_TALLA { get; set; }
        public string NumTalla { get; set; }
    }

    public class UpdateTallasDto
    {
        public int ID_TALLA { get; set; }
        public string NumTalla { get; set; }
    }
}
