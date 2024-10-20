using Insulizzy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insulizzy.Controllers
{
    public class InsulinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string meal, int bgLevel, int mealCarbs)
        {
            var calculator = new InsulinCalculator
            {
                Meal = meal,
                BGLevel = bgLevel,
                MealCarbs = mealCarbs
            };

            ViewBag.Insulin = calculator.CalculateInsulin();
            ViewBag.InsulinCorrection = calculator.CalculateInsulinCorrection();
            ViewBag.InsulinTotal = calculator.CalculateInsulinTotal();

            return View("Result");
        }
    }
}
