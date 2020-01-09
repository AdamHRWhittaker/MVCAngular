using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Crypto
{
    public abstract class Currency
    {
        public decimal Price { get; set; }
        public double Volume_24h { get; set; }
        public double Percent_change_1h { get; set; }
        public double Percent_change_24h { get; set; }
        public double Percent_change_7d { get; set; }
        public double Market_cap { get; set; }
        public DateTime Last_updated { get; set; }
    }
}
