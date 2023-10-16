using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ToDosController : ApiController
    {
        private readonly IToDosService toDosService;

        public ToDosController(IToDosService toDosService)
        {
            this.toDosService = toDosService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetToDos()
        {
            List<ToDo> toDos = await toDosService.GetAll();
            return Ok(toDos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            ToDo toDo = await toDosService.GetByIdAsync(id);
            return Ok(toDo);
        }
    }
}
