using Microsoft.AspNetCore.Mvc;

namespace MovieMart.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //TODO:here ....
    }
}
