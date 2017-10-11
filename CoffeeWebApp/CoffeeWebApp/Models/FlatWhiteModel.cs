using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebApp.Models
{
    public class FlatWhiteModel : ICoffee
    {
        public FlatWhiteModel()
        {
            CoffeeBean = 2;
            Milk = 4;
            Sugar = 1;
        }

        public int CoffeeBean { get; set; }

        public int Milk { get; set; }

        public int Sugar { get; set; }

        public void OrderCoffee()
        {
            //throw new NotImplementedException();
        }
    }
}