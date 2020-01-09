using MVC.Helpers;
using MVC.Models;
using MVC.Models.Crypto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Managers
{
    public class CurrencyManager
    {
        private readonly string API_KEY = "dae93059-c7e8-4211-81bd-b65fb32df1ad";
        public CurrencyManager()
        {

        }

        public IEnumerable<CurrencyModel> GetCurrencies()
        {
            var helper = new Helper();
            var cryptoData = helper.DeserializeObject<CryptoData>(CallAPI());
            List<CurrencyModel> currencyModels = new List<CurrencyModel>();

            var currencyModel = new CurrencyModel
            {
                Price = cryptoData.Data.BTC.Quote.USD.Price,
                Name = cryptoData.Data.BTC.Name
            };

            currencyModels.Add(currencyModel);

            var currencyModel1 = new CurrencyModel
            {
                Price = cryptoData.Data.VET.Quote.USD.Price,
                Name = cryptoData.Data.VET.Name
            };

            currencyModels.Add(currencyModel1);

            return currencyModels;
        }

        private string CallAPI() {
            var query = new QueryParameters
            {
                Crypto = new List<string> { "BTC", "VET" },
                Currency = new List<string> { "USD" }
            };

            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);

            string cryptoQuery = "";
            string currencyQuery = "";
            foreach (var crypto in query.Crypto)
            {
                cryptoQuery += crypto + ",";
            }

            foreach (var currency in query.Currency)
            {
                currencyQuery += currency + ",";
            }

            cryptoQuery = cryptoQuery.TrimEnd(',');
            currencyQuery = currencyQuery.TrimEnd(',');

            queryString["symbol"] = cryptoQuery;
            queryString["convert"] = currencyQuery;

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }

        public class QueryParameters
        {
            public IList Crypto { get; set; }
            public IList Currency { get; set; }
            public IList APIKey { get; set; }
        }


    }
}
