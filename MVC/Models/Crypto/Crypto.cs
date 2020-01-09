using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.Crypto
{
    public abstract class Crypto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
        public long Circulating_supply { get; set; }
        public long Total_supply { get; set; }
        public object Max_supply { get; set; }
        public DateTime Date_added { get; set; }
        public int Num_market_pairs { get; set; }
        public List<object> Tags { get; set; }
        public object Platform { get; set; }
        public int Cmc_rank { get; set; }
        public DateTime Last_updated { get; set; }
        public Quote Quote { get; set; }
    }
}
