using System;
using System.Collections.Generic;

namespace CoffeeWebApp.Models
{
    public static class PantryModel
    {
        public static int CoffeeBeanBag { get; set; }
        public static int MilkBag { get; set; }
        public static int SugarBag { get; set; }

        public static int CoffeeBeanUnits
        {
            get; set;
        }
        public static int MilkUnits
        {
            get; set;
        }
        public static int SugarUnits
        {
            get; set;
        }

        private static Dictionary<string, ICoffee> CoffeeDictionary { get; set; }

        public static Dictionary<string, int> CoffeeOrders { get; set; }

        public static List<OrderHistory> History { get; set; }

        static PantryModel()
        {
            CoffeeBeanBag = 3;
            MilkBag = 3;
            SugarBag = 3;

            CoffeeBeanUnits = CoffeeBeanBag * 15;
            MilkUnits = MilkBag * 15;
            SugarUnits = SugarBag * 15;

            CoffeeDictionary = new Dictionary<string, ICoffee>();
            CoffeeDictionary.Add(CoffeeType.DoubleAmericano.ToString(), new DoubleAmericanoModel());
            CoffeeDictionary.Add(CoffeeType.SweetLatte.ToString(), new SweetLatteModel());
            CoffeeDictionary.Add(CoffeeType.FlatWhite.ToString(), new FlatWhiteModel());

            History = new List<OrderHistory>();
            CoffeeOrders = new Dictionary<string, int>();
            CoffeeOrders.Add(CoffeeType.DoubleAmericano.ToString(), 0);
            CoffeeOrders.Add(CoffeeType.SweetLatte.ToString(), 0);
            CoffeeOrders.Add(CoffeeType.FlatWhite.ToString(), 0);

        }
        public enum CoffeeType
        {
            DoubleAmericano,
            SweetLatte,
            FlatWhite

        }
        public static void OrderCoffee(string coffeeType)
        {
            if (CoffeeDictionary.ContainsKey(coffeeType))
            {
                var coffee = CoffeeDictionary[coffeeType];
                if (CheckIngredients(coffee))
                {
                    coffee.OrderCoffee();
                    UpdateInventoryUnits(coffee.CoffeeBean, coffee.Milk, coffee.Sugar);
                    RecordOrder(coffeeType);
                }
            }
        }

        private static bool CheckIngredients(ICoffee orderedCoffee)
        {
            return CoffeeBeanUnits >= orderedCoffee.CoffeeBean && MilkUnits >= orderedCoffee.Milk && SugarUnits > orderedCoffee.Sugar;
        }

        public static void UpdateInventoryUnits(int coffeeBeanUnit, int milkUnit, int sugarUnit)
        {
            CoffeeBeanUnits -= coffeeBeanUnit;
            MilkUnits -= milkUnit;
            SugarUnits -= sugarUnit;
        }

        private static void RecordOrder(string coffeeType)
        {
            OrderHistory order = new OrderHistory();
            order.CoffeeType = coffeeType;
            order.Date = DateTime.Today;
            History.Add(order);
            UpdateOrderCount();
        }

        private static void UpdateOrderCount()
        {
            CoffeeOrders[CoffeeType.DoubleAmericano.ToString()] = History.FindAll(x => x.CoffeeType == CoffeeType.DoubleAmericano.ToString()).Count;
            CoffeeOrders[CoffeeType.SweetLatte.ToString()] = History.FindAll(x => x.CoffeeType == CoffeeType.SweetLatte.ToString()).Count;
            CoffeeOrders[CoffeeType.FlatWhite.ToString()] = History.FindAll(x => x.CoffeeType == CoffeeType.FlatWhite.ToString()).Count;

        }
    }
}