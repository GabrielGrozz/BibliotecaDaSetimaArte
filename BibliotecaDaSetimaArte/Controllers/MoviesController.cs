using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDaSetimaArte.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
