using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Running..";
    }
}