using System.Web.Http;

namespace WebApi.Controllers
{
    public class ToDosController : ApiController
    {
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Ok(new { Message = "Hello World" });
        }
    }
}
