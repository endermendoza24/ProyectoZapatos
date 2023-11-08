﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.DTOs
{
    public class CreateMarcaDTO
    {
        public string ID_MARCA { get; set; }
        public bool estado { get; set; }
        public string NOMBRE_MARCA { get; set; }
    }

    public class UpdateMarcaDTO
    {
        public string ID_MARCA { get; set; }
        public bool estado { get; set; }
        public string NOMBRE_MARCA { get; set; }
    }
}
