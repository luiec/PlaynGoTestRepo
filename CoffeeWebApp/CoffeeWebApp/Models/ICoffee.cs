using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebApp.Models
{
    public interface ICoffee
    {
        int CoffeeBean { get; set; }
        int Milk { get; set; }
        int Sugar { get; set; }  

    }
}