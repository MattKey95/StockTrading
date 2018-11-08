using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    class JsonToStockObject
    {
        public List<HistoricalStockObject> CreateHistoricalStockObjects(string Ticker, string Time)
        {
            List<HistoricalStockObject> list = new List<HistoricalStockObject>();
            list = JsonConvert.DeserializeObject<List<HistoricalStockObject>>(IEXTradingAPICommunicator.GetHistoricalData(Ticker, Time));

            foreach(HistoricalStockObject h in list)
            {
                h.Ticker = Ticker;
            }

            return list;
        }
    }
}
