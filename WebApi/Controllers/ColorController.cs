using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using Domain.Endpoint.DTOs;
using Domain.Endpoint.Services;
using System.Net;

namespace WebApi.Controllers
{
    public class ColorController : ApiController
    {
        private readonly IColorService colorService;

        public ColorController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetColor()
        {
            List<Color> color = await colorService.GetAll();
            return Ok(color);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetColorById(Guid id)
        {
            Color color = await colorService.GetByIdAsync(id);
            return Ok(color);
        }

        [HttpPost]
        [ResponseType(typeof(Color))]
        public async Task<IHttpActionResult> CreateColor(CreateColorDTO colorDTO)
        {
            Color color = await colorService.CreateAsync(colorDTO);
            var url = Url.Content("~/") + "/api/color/" + color.Id;
            return Created(url, color);
        }


        [HttpPut]
        public async Task<IHttpActionResult> UpdateColor(Guid id, UpdateColorDTO colorDTO)
        {
            // Corrige el tipo del DTO a UpdateColorDTO
            Color color = await colorService.UpdateAsync(id, colorDTO);
            return Ok(color);
        }

    }
}
