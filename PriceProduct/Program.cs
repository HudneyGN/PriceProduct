using System;
using System.Globalization;
using System.Collections.Generic;
using PriceProduct.Entities;
namespace PriceProduct {
    internal class Program {
        static void Main(string[] args) {

            List<Product> p = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {
                Console.WriteLine($"Product {1} data: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                string resp = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price:  ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);



                if (resp == "c" || resp == "C") {
                    p.Add(new Product(name, price));
                }
                else if (resp == "i" || resp == "I") {
                    Console.Write("Customs fee:");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    p.Add(new ImportedProduct(name, price, customsFee));
                }
                else {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    p.Add(new UsedProduct(name, price, manufactureDate));
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product obj in p) {
                Console.WriteLine(obj.PriceTag());
            }
        }
    }
}