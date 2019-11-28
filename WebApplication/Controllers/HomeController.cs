using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Integral;
using Domain.Integral.Method;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var first = new Integral("x^2", 0, 10, 1000).Calculate(new RectangleMethod());
            var second = new Integral("x^2", 0, 10, 1000).Calculate(new TrapezeMethod());
            ViewData["output"] = $"first: {first} \nsecond: {second}";
            return View();
        }
    }
}