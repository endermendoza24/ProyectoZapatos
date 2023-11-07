using Domain.Talla.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;

namespace WebApi.Controllers
{
    public class TallasController : ApiController
    {
        private readonly ITallasService tallasService;

        public TallasController(ITallasService tallasService)
        {
            this.tallasService = tallasService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTallas()
        {
            List<Tallas> tallas = await tallasService.GetAll();
            return Ok(tallas);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTallaById(Guid id)
        {
            Tallas talla = await tallasService.GetByIdAsync(id);
            return Ok(talla);
        }

        [HttpPost]
        [ResponseType(typeof(Tallas))]
        public async Task<IHttpActionResult> CreateTalla(CreateTallasDto tallaDto)
        {
            Tallas talla = await tallasService.CreateAsync(tallaDto);
            var url = Url.Content("~/") + "/api/tallas/" + talla.Id;
            return Created(url, talla);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTalla(Guid id, UpdateTallasDto tallaDto)
        {
            Tallas talla = await tallasService.UpdateAsync(id, tallaDto);
            return Ok(talla);
        }
    }
}
