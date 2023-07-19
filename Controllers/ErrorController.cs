using Microsoft.AspNetCore.Mvc;

namespace AnimalPlaceProject.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return Content("There was an unexpected error. Please come back later");
        }
    }
}
