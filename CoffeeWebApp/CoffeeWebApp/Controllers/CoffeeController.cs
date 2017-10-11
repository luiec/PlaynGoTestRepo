using CoffeeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using static CoffeeWebApp.Models.PantryModel;

namespace CoffeeWebApp.Controllers
{
    public class CoffeeController : Controller
    {
        // GET: Coffee
        public ActionResult Coffee()
        {
            return View();
        }

        public bool Order(string coffeeType)
        {
            OrderCoffee(coffeeType);
            return true;
        }

        public ActionResult LoadIngredientsChart()
        {
            var chart = new Chart(width: 400, height: 300)
                .AddSeries(
                            chartType: "bar",
                            xValue: new[] { "Coffee Beans", "Milk Cartons", "Sugar Packets" },
                            yValues: new[] { CoffeeBeanUnits.ToString(), MilkUnits.ToString(), SugarUnits.ToString() })
                            .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult LoadCoffeeChart()
        {

            var coffeeChart = new Chart(width: 400, height: 300)
                .AddSeries(
                            chartType: "bar",
                            xValue: new[] { CoffeeType.DoubleAmericano.ToString(), CoffeeType.SweetLatte.ToString(), CoffeeType.FlatWhite.ToString() },
                            yValues: new[] { CoffeeOrders[CoffeeType.DoubleAmericano.ToString()], CoffeeOrders[CoffeeType.SweetLatte.ToString()], CoffeeOrders[CoffeeType.FlatWhite.ToString()] })
                            .GetBytes("png");
            return File(coffeeChart, "image/bytes");
        }
    }
}