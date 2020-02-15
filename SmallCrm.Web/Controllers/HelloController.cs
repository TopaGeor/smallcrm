using Microsoft.AspNetCore.Mvc;

namespace SmallCrm.Web.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult SayHello()
        {
            var model = new Models.NameViewModel()
            {
                Name = "Lalilulelo"
            };

            return View(model);
        }
    }
}