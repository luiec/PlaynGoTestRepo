using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebApp.Models
{
    public class OrderHistory
    {
        public string CoffeeType { get; set; }
        public DateTime Date { get; set; }

        public OrderHistory()
        {
            Date = new DateTime();
        }

    }
}