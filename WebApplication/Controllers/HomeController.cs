
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
                var integral = new IntegralBuilderService().Build(parameter);
                return Json(integral);
            }

            if (Request.Query["side"] == "right")
            {
                var parameter = new LesAdapter().Adapt(Request.Query);
                var les = new LesBuilderService().Build(parameter);
                return Json(les);
            }
            return View();
        }
    }
}