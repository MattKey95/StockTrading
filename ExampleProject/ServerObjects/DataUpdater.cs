using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    public class DataUpdater
    {
        public List<String> Tickers = new List<string>()
        {
            "AAPL", "GOOG", "GOOGL", "TSLA", "INTC", "AMZN", "BIDU", "ORCL", "MSFT", "ORCL", "ATVI", "NVDA", "GME",
            "NFLX"
        };


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


        public void UpdateHistoricalData()
        {
            /*
            string deleteQuery = "DELETE FROM HistoricalData";
            DatabaseWriter.Writer.RunQuery(deleteQuery);

            List<List<ServerHistoricalStockObject>> data = new List<List<ServerHistoricalStockObject>>();
            foreach (var t in Tickers)
            {
                List<ServerHistoricalStockObject> temp = JsonToStockObject.Json.CreateHistoricalStockObjects(t, "5y");
                data.Add(temp);
            }

            foreach (var list in data)
            {
                StockObjectToDatabase.Database.UpdateHistoricalData(list, false);
            }
            */
            Console.WriteLine("DISABLED!");
        }
    }
}