using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebApp.Models
{
    public class SweetLatteModel : ICoffee
    {
        public SweetLatteModel()
        {
            CoffeeBean = 2;
            Milk = 3;
            Sugar = 5;

        }

        public int CoffeeBean { get; set; }

        public int Milk { get; set; }

        public int Sugar { get; set; }

      
    }
}