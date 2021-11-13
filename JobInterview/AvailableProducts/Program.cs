using System;
using AvailableProductsLibrary;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AvailableProducts
{
    class Program
    {
        static string readJson;
        static List<Suppliers>  suppliers = new List<Suppliers>(); 
        
        static void Main(string[] args)
        {
            ReadData();
            StoreData();
            PrintData();
        }
        static void ReadData(){
            try{
                readJson = File.ReadAllText("file.json");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
              
        }
        static void StoreData(){
            suppliers = JsonConvert.DeserializeObject<List<Suppliers>>(readJson);
        }
        static void PrintData(){
            var myLinq = suppliers.SelectMany(a => a.ListOfProducts, (supp, prod) => new { supp, prod})
            .GroupBy(a => a.prod.Id)
            .Select(a=> new{
                Id = a.Key,
                Quantity = a.Sum(b=>b.prod.Quantity)
            });
            foreach (Suppliers supplier in suppliers)
            {
                Console.WriteLine($"Supplier Name: { supplier.Name }");
                foreach (Products product in supplier.ListOfProducts)
                {
                    if (product.IsAvailable()){
                        Console.WriteLine($"Product Name: { product.Name }");
                        Console.WriteLine($"Quantity: { myLinq.Single(a => a.Id == product.Id).Quantity }");
                        Console.WriteLine($"Initial Price: Price { product.InitialPrice } EUR");
                        Console.WriteLine($"Selling Price: Price { product.SellingPrice(supplier.Markup)} EUR");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
