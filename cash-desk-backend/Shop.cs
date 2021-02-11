using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using cash_desk_backend;
using Newtonsoft.Json;

namespace cash_desk_backend
{
    public class Shop
    {
        public Shop()
        {
            CreateProducts();            
        }
        public List<Product> AllProducts { get; set; }
        public List<Product> CreateProducts()
        {
            var path = Directory.GetCurrentDirectory() + "\\Database.json";
            var content = File.ReadAllText(path);
            AllProducts = JsonConvert.DeserializeObject<List<Product>>(content);
            return AllProducts;
        }
    }
}