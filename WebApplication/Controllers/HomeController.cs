
using System.Diagnostics;
using Domain.Integral;
using Domain.Integral.Method;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var watcher = new Stopwatch();
            watcher.Start();
            var first = new Integral("x^2", 0, 5, 5000).Calculate(new RectangleMethod());
            watcher.Stop();
            ViewData["time1"] = watcher.ElapsedMilliseconds;
            
            watcher.Restart();
            var second = new Integral("x^2", 0, 5, 5000).Calculate(new TrapezeMethod());
            watcher.Stop();
            ViewData["time2"] = watcher.ElapsedMilliseconds;
            
            ViewData["output"] = $"first: {first} \nsecond: {second}";
            return View();
        }
    }
}