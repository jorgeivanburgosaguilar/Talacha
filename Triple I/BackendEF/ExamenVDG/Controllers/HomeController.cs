using Microsoft.AspNetCore.Mvc;

namespace ExamenVDG.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();
    }
}