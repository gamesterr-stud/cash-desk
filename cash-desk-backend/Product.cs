using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace cash_desk_backend
{
    
    public class Product
    {
        public int Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal VatRate { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

    }
}

