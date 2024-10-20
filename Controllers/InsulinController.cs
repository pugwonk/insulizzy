using Microsoft.AspNetCore.Mvc;
using Insulizzy.Models;

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

            double insulin = calculator.CalculateInsulin();
            double roundedInsulin = calculator.RoundInsulin(insulin);
            double correction = calculator.CalculateInsulinCorrection();
            double totalInsulin = calculator.CalculateInsulinTotal();

            ViewBag.Insulin = roundedInsulin;
            ViewBag.InsulinCorrection = correction;
            ViewBag.InsulinTotal = totalInsulin;

            return View("Index");
        }
    }
}
