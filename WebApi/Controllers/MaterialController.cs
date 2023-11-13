using Domain.Talla.DTOs;
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
    public class MaterialController : ApiController
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMaterial()
        {
            List<Material> material = await materialService.GetAll();
            return Ok(material);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMaterialById(Guid id)
        {
            Material material = await materialService.GetByIdAsync(id);
            return Ok(material);
        }

        [HttpPost]
        [ResponseType(typeof(Material))]
        public async Task<IHttpActionResult> CreateMaterial(CreateMaterialDTO materialDTO)
        {
            Material material = await materialService.CreateAsync(materialDTO);
            var url = Url.Content("~/") + "/api/material/" + material.Id;
            return Created(url, material);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateTalla(Guid id, UpdateMaterialDTO materialDTO)
        {
            Material material = await materialService.UpdateAsync(id, materialDTO);
            return Ok(material);
        }
    }
}
