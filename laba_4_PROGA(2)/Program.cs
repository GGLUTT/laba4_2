using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeVanApp
{
    public enum CoffeeState
    {
        Bean,
        Ground,
        Instant
    }

    public class CoffeeProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public CoffeeState State { get; set; }

        public CoffeeProduct(string name, double price, double weight, CoffeeState state)
        {
            Name = name;
            Price = price;
            Weight = weight;
            State = state;
        }

        public override string ToString()
        {
            return $"{Name} - {State} - Price: {Price}, Weight: {Weight}";
        }
    }

    public class CoffeeVan
    {
        private List<CoffeeProduct> products;

        public CoffeeVan()
        {
            products = new List<CoffeeProduct>();
        }

        public void LoadProduct(CoffeeProduct product)
        {
            products.Add(product);
        }

        public void SortProductsByPriceAndWeight()
        {
            products = products.OrderBy(p => p.Price / p.Weight).ToList();
        }

        public List<CoffeeProduct> FindProductsByQuality(double minPrice, double maxPrice, double minWeight, double maxWeight)
        {
            return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.Weight >= minWeight && p.Weight <= maxWeight).ToList();
        }

        public void DisplayProducts(List<CoffeeProduct> products)
        {
            if (products.Any())
            {
                Console.WriteLine("Пошук продуктів за вашим запитом:");
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Продуктів не знайдено!!!!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CoffeeVan van = new CoffeeVan();

            van.LoadProduct(new CoffeeProduct("Arabica", 10, 0.5, CoffeeState.Bean));
            van.LoadProduct(new CoffeeProduct("Robusta", 8, 0.7, CoffeeState.Bean));
            van.LoadProduct(new CoffeeProduct("Cappuccino", 12, 0.3, CoffeeState.Ground));
            van.LoadProduct(new CoffeeProduct("Espresso", 15, 0.2, CoffeeState.Instant));

            Console.WriteLine("Сортування товарів за ціною та вагою...");
            van.SortProductsByPriceAndWeight();

            Console.WriteLine("Введіть мін ціну:");
            double minPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть мах ціну:");
            double maxPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть мін вагу:");
            double minWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть мах вагу:");
            double maxWeight = double.Parse(Console.ReadLine());

            var foundProducts = van.FindProductsByQuality(minPrice, maxPrice, minWeight, maxWeight);
            van.DisplayProducts(foundProducts);
        }
    }
}
