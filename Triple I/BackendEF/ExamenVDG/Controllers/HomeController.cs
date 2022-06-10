using Microsoft.AspNetCore.Mvc;

namespace ExamenVDG.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}