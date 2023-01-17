using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    public class Product
    {
        private static long count = 0;
        private static Random rnd = new Random();
        static List<Product> products = new List<Product>
        {
            new Product("Electric sander", Type.M, new List<int> { 99, 82, 81, 79 }, 157.98M),
            new Product("Power saw", Type.M, new List<int> { 99, 86, 90, 94 }, 99.99M),
            new Product("Sledge hammer", Type.F, new List<int> { 93, 92, 80, 87 }, 21.50M),
            new Product("Hammer", Type.M, new List<int> { 97, 89, 85, 82 }, 11.99M),
            new Product("Lawn mower", Type.F, new List<int> { 35, 72, 91, 70 }, 139.50M),
            new Product("Screwdriver", Type.F, new List<int> { 88, 94, 65, 91 }, 56.99M),
            new Product("Jig saw", Type.M, new List<int> { 75, 84, 91, 39 }, 11.00M),
            new Product("Wrench", Type.F, new List<int> { 97, 92, 81, 60 }, 17.50M),
            new Product("Sledge hammer", Type.M, new List<int> { 75, 84, 91, 39 }, 21.50M),
            new Product("Hammer", Type.F, new List<int> { 94, 92, 91, 91 }, 11.99M),
            new Product("Lawn mower", Type.M, new List<int> { 96, 85, 91, 60 }, 179.50M),
            new Product("Screwdriver", Type.M, new List<int> { 96, 85, 51, 30 }, 66.99M),
        };

        private string id;
        private List<int> weeklyPurchases;

        public Product(string description, Type category, List<int> weeklyPurchases, decimal price)
        {
            this.Quarter = (YearlyQuarter)rnd.Next(1, 5);
            this.Description = description;
            this.Category = category;
            this.Price = price;

            int randomIdNumber = rnd.Next(0, 1_000_000);
            this.id = this.Category.ToString() + new string('0', 6 - randomIdNumber.ToString().Length) + randomIdNumber.ToString();
            this.weeklyPurchases = weeklyPurchases;
        }

        public Type Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public YearlyQuarter Quarter { get; set; }

        public override string ToString()
        {
            return $"{this.id}: {string.Join(", ", this.weeklyPurchases.Select(x => x.ToString()))}";
        }

        public static void GroupByCategoryCountDescending()
        {
            var result = string.Join("", products.GroupBy(x => x.Category)
                .Select(x => new
                {
                    Category = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .Select(x => $"Category group: {x.Category}\nNumber of products in the group: {x.Count}\n\n").ToList());
                
            Console.WriteLine(result);
        }

        public static void GroupByQtrAndProductPriceAvg()
        {
            var result = string.Join("", products.GroupBy(x => x.Quarter)
                .Select(x => new
                {
                    Quarter = x.Key,
                    Price = x.Average(y => y.Price)
                })
                .OrderBy(x => x.Quarter)
                .Select(x => $"Quarter group: {x.Quarter}\nAverage price per quarter: ${x.Price:0.00}\n\n").ToList());

            Console.WriteLine(result);

        }

        public static void GroupByQtrCategoryWeeklySum()
        {
            var result = string.Join("\n\n", 
                products.GroupBy(x => x.Quarter).OrderBy(x => x.Key)
               .Select(x => new
               {
                   Category = x.Key,
                   Products = x.ToList()
               })
               .Select(x => $"Quarter Group: {x.Category}\n" +
                    string.Join("\n", x.Products
                    .GroupBy(y => y.Category)
                    .Select(y => new
                    {
                        Category = y.Key,
                        Products = y.ToList()
                    })
                    .Select(y => $"      Category Group: {y.Category}\n" + string.Join("\n", 
                        y.Products
                        .Select(z => "            " + (z.Description, z.weeklyPurchases.Sum())))))
                ));

            Console.WriteLine(result);
        }

        public static void GroupByQtrCategoryAndProducts()
        {
            var result = string.Join("\n\n",
                products.GroupBy(x => x.Quarter).OrderBy(x => x.Key)
               .Select(x => new
               {
                   Category = x.Key,
                   Products = x.ToList()
               })
               .OrderBy(x => x.Category)
               .Select(x => $"Quarter Group: {x.Category}\n" +
                    string.Join("\n", x.Products
                    .GroupBy(y => y.Category)
                    .Select(y => new
                    {
                        Category = y.Key,
                        Products = y.ToList()
                    })
                    .Select(y => $"      Category Group: {y.Category}\n" + string.Join("\n",
                        y.Products.Select(z => "            " + z.ToString()).OrderBy(z => z).ToList())))));

            Console.WriteLine(result);
        }

        public static void GroupByQtrMinMaxPrice()
        {
            var result = string.Join("", products.GroupBy(x => x.Quarter)
                .Select(x => new
                {
                    Quarter = x.Key,
                    MinPrice = x.Min(y => y.Price),
                    MaxPrice = x.Max(y => y.Price)
                })
                .OrderBy(x => x.Quarter)
                .Select(x => $"Quarter group: {x.Quarter}\n" + 
                             $"     Min price per quarter: ${x.MinPrice:0.00}\n" +
                             $"     Max price per quarter: ${x.MaxPrice:0.00}\n").ToList());

            Console.WriteLine(result);
        }
    }
}
