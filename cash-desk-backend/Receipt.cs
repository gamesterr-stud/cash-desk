using System;
using System.Collections.Generic;
using System.Text;

namespace cash_desk_backend
{
    public class Receipt
    {
        public Receipt()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Net { get; set; }

    }
}
