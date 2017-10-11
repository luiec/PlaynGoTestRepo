using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebApp.Models
{
    public class DoubleAmericanoModel : ICoffee
    {
        public DoubleAmericanoModel()
        {
            CoffeeBean = 3;
            Milk = 0;
            Sugar = 0;
        }

        public int CoffeeBean { get; set; }

        public int Milk { get; set; }

        public int Sugar { get; set; }

        public void OrderCoffee()
        {
         //   throw new NotImplementedException();
        }
    }
}