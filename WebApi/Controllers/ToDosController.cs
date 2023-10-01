using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ToDosController : ApiController
    {
        private readonly IToDosService _toDosService;

        public ToDosController(IToDosService toDosService)
        {
            _toDosService = toDosService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetToDos()
        {
            List<ToDo> toDos = await _toDosService.GetAll();
            return Ok(toDos);
        }
    }
}
