
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.AdapterService;
using WebApplication.Services.IntegralService;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["integral_result"] = "";
            ViewData["LES_result"] = "";
            
            if (Request.Query["side"] == "left")
            {
                var parameter = new IntegralAdapter().Adapt(Request.Query);
                var integral = new SimpleBuilderService().Build(parameter);
                return Json(integral);
            }

            if (Request.Query["side"] == "right")
            {
                //TODO()
            }
            return View();
        }
    }
}