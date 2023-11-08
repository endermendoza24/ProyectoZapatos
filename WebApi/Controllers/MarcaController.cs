using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using Domain.Endpoint.DTOs;

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
        public async Task<IHttpActionResult> GetMarcaById(Guid id)
        {
            Marca talla = await marcaService.GetByIdAsync(id);
            return Ok(talla);
        }

        [HttpPost]
        [ResponseType(typeof(Marca))]
        public async Task<IHttpActionResult> CreateMarc(CreateMarcaDTO marcaDto)
        {
            Marca talla = await marcaService.CreateAsync(marcaDto);
            var url = Url.Content("~/") + "/api/marcas/" + talla.Id;
            return Created(url, talla);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTalla(Guid id, UpdateMarcaDTO tallaDto)
        {
            Marca talla = await marcaService.UpdateAsync(id, tallaDto);
            return Ok(talla);
        }
    }
}
