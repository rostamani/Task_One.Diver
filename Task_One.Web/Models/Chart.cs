using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_One.Web.Models
{
    public class Chart
    {
        public string ProductName { get; set; }
        public string StoreName { get; set; }
        public List<ChartData> Points { get; set; }
    }
}
