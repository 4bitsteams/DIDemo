using DIDemo.Interface;
using DIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DIDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _transientServiceOne;
        private readonly ITransientService _transientServiceTwo;
        private readonly IScopedService _scopedServiceOne;
        private readonly IScopedService _scopedServiceWto;
        private readonly SingletonService _singletonServiceOne;
        private readonly SingletonService _singletonServiceTwo;

        public HomeController(
            ILogger<HomeController> logger,
            ITransientService transientServiceOne,
            ITransientService transientServiceTwo,
            IScopedService scopedServiceOne,
            IScopedService scopedServiceWto,
            SingletonService singletonServiceOne,
            SingletonService singletonServiceTwo


            )
        {
            _scopedServiceOne = scopedServiceOne;
            _scopedServiceWto = scopedServiceWto;
            _transientServiceOne = transientServiceOne;
            _transientServiceTwo = transientServiceTwo;
            _singletonServiceOne = singletonServiceOne;
            _singletonServiceTwo = singletonServiceTwo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.transientServiceOne = _transientServiceOne.GetTaskId().ToString();
            ViewBag.transientServiceTwo = _transientServiceTwo.GetTaskId().ToString();

            ViewBag.scopedServiceOne = _scopedServiceOne.GetTaskId().ToString();
            ViewBag.scopedServiceWto = _scopedServiceWto.GetTaskId().ToString();
            
            ViewBag.singletonServiceOne = _singletonServiceOne.GetTaskId().ToString();
            ViewBag.singletonServiceTwo = _singletonServiceTwo.GetTaskId().ToString();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}