using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_One.Web.Models
{
    public class ProductSell
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public DateTime SoldDate { get; set; }
        public double Price { get; set; }
    }
}
