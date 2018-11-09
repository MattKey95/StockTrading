using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    public class JsonToStockObject
    {
        private static JsonToStockObject _json;

        public static JsonToStockObject Json
        {
            get
            {
                if (_json == null)
                {
                    _json = new JsonToStockObject();
                }

                return _json;
            }
        }

        public List<ServerHistoricalStockObject> CreateHistoricalStockObjects(string Ticker, string Time)
        {
            List<ServerHistoricalStockObject> list = new List<ServerHistoricalStockObject>();
            try
            {
                list = JsonConvert.DeserializeObject<List<ServerHistoricalStockObject>>(
                    IEXTradingAPICommunicator.GetHistoricalData(Ticker, Time));
            }
            catch (Exception)
            {

            }

            foreach(ServerHistoricalStockObject h in list)
            {
                h.Ticker = Ticker;
            }

            return list;
        }
    }
}
