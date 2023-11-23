using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class MarcaController : ApiController
    {
        private readonly IMarcaService marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            this.marcaService = marcaService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMarca()
        {
            List<Marca> marcas = await marcaService.GetAll();
            return Ok(marcas);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMarcaById(int idMarca)
        {
            Marca marca = await marcaService.GetByIdAsync(idMarca);
            return Ok(marca);
        }

        [HttpPost]
        [ResponseType(typeof(Marca))]
        public async Task<IHttpActionResult> CreateMarca(CreateMarcaDTO marcaDto)
        {
            Marca marca = await marcaService.CreateAsync(marcaDto);
            var url = Url.Content("~/") + "/api/marcas/" + marca.ID_MARCA;
            return Created(url, marca);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTalla(int idMarca, UpdateMarcaDTO marcaDto)
        {
            Marca marca = await marcaService.UpdateAsync(idMarca, marcaDto);
            return Ok(marca);
        }
    }
}
