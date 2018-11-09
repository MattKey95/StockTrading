using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    public class DataUpdater
    {
        public List<String> Tickers = new List<string>() { "AAPL", "GOOG", "GOOGL", "YHOO", "TSLA", "INTC", "AMZN", "BIDU", "ORCL", "MSFT", "ORCL", "ATVI", "NVDA", "GME", "LNKD", "NFLX" };


        private static DataUpdater _updater;

        public static DataUpdater Updater
        {
            get
            {
                if (_updater == null)
                {
                    _updater = new DataUpdater();
                }

                return _updater;
            }
        }

        public void UpdateAllStocks()
        {
            foreach (var t in Tickers)
            {
                DataUpdater.Updater.UpdateHistoricalData(t);
            }
        }


        public void UpdateHistoricalData(string Ticker)
        {
            var yesterday = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

            string query = String.Format("SELECT MAX(DayDate) AS DayDate FROM HistoricalData WHERE Ticker=\'{0}\'", Ticker);
            
            List<ServerHistoricalStockObject> result = DatabaseReader.Reader.ReadFromDatabase<ServerHistoricalStockObject>(query);

            if (result.Count == 0 || DateTime.Parse(result[0].Date) < DateTime.Parse(yesterday))
            {
                Console.WriteLine("Updating "+Ticker);
                List<ServerHistoricalStockObject> list = JsonToStockObject.Json.CreateHistoricalStockObjects(Ticker, "1m");
                StockObjectToDatabase.Database.UpdateHistoricalData(list, false);
            }
            
        }
    }
}
