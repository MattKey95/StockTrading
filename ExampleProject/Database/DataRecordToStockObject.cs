using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    public class DataRecordToStockObject
    {
        private static DataRecordToStockObject _converter;

        public static DataRecordToStockObject Converter
        {
            get
            {
                if (_converter == null)
                {
                    _converter = new DataRecordToStockObject();
                }

                return _converter;
            }
        }

        public List<HistoricalStockObject> ToHistorical(List<object[]> records)
        {
            List<HistoricalStockObject> ReturnList = new List<HistoricalStockObject>();

            foreach (object[] r in records)
            {
                HistoricalStockObject h = new HistoricalStockObject();
                h.Ticker = (string)r[0];
                h.DayDate = (string) r[1];
                h.DayOpen = (double)r[2];
                h.DayHigh = (double) r[3];
                h.DayLow = (double) r[4];
                h.DayClose = (double) r[5];
                h.Volume = (int) r[6];
                h.UnadjustedVolume = (int) r[7];
                h.Change = (double) r[8];
                h.ChangePercent = (double) r[9];
                h.Vwap = (double) r[10];
                h.Label = (string) r[11];
                h.ChangeOverTime = (double) r[12];
                ReturnList.Add(h);
            }

            return ReturnList;
        }
    }
}
