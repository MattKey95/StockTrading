using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExampleProject.Database
{
    static class IEXTradingAPICommunicator
    {
        const string tickers = "AAPL,GOOG,GOOGL,YHOO,TSLA,INTC,AMZN,BIDU,ORCL,MSFT,ORCL,ATVI,NVDA,GME,LNKD,NFLX";

        public static string CallAPI(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //For IP-API
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                return null;
            }
        }

        public static string GetHistoricalData(string ticker, string timePeriod)
        {
            var IEXTrading_API_PATH = "https://api.iextrading.com/1.0/stock/{0}/chart/{1}";
            IEXTrading_API_PATH = string.Format(IEXTrading_API_PATH, ticker, timePeriod);
            string json = CallAPI(IEXTrading_API_PATH);
            return json;
        }
    }
}
