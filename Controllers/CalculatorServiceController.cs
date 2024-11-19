using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webLab2._1.Models;

namespace webLab2._1.Controllers
{
    public class CalculatorServiceController : Controller
    {
        private readonly Random _random = new Random();                

        private readonly ILogger<CalculatorServiceController> _logger;

        public CalculatorServiceController(ILogger<CalculatorServiceController> logger)
        {
            _logger = logger;                    
        }

        public IActionResult Index()
        {
            return View();
        }                

        public IActionResult ManualParsingSingle()
        {
            if (Request.Method == "POST")
            {
                try
                {
                    var calc = new CalculatorModel()
                    {
                        X = Int32.Parse(HttpContext.Request.Form["x"]),
                        Operation = HttpContext.Request.Form["operation"],
                        Y = Int32.Parse(HttpContext.Request.Form["y"])
                    };

                    ViewBag.Result = calc.Calc();
                }
                catch
                {
                    ViewBag.Result = "Invalid input";
                }

                return View("Result");
            }
            return View("Window");
        }

        [HttpGet]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparateGet()
        {
            return View("Window");
        }

        [HttpPost]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparatePost()
        {
            try
            {
                var calc = new CalculatorModel()
                {
                    X = Int32.Parse(HttpContext.Request.Form["x"]),
                    Operation = HttpContext.Request.Form["operation"],
                    Y = Int32.Parse(HttpContext.Request.Form["y"])
                };

                ViewBag.Result = calc.Calc();
            }
            catch
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingParameters()
        {
            return View("Window");
        }
        [HttpPost]
        public IActionResult ModelBindingParameters(int x, string operation, int y)
        {
            if (ModelState.IsValid)
            {
                var calc = new CalculatorModel()
                {
                    X = x,
                    Operation = operation,
                    Y = y
                };
                ViewBag.Result = calc.Calc();
            }
            else
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingSeparate()
        {
            return View("Window");
        }
        [HttpPost]
        public IActionResult ModelBindingSeparate(CalculatorModel model)
        {
            ViewBag.Result = ModelState.IsValid
                ? model.Calc()
                : "Invalid input";

            return View("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}