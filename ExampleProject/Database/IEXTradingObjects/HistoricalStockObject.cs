using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    public class HistoricalStockObject
    {
        public string Ticker { get; set; }
        public string DayDate { get; set; }
        public double DayOpen { get; set; }
        public double DayHigh { get; set; }
        public double DayLow { get; set; }
        public double DayClose { get; set; }
        public int Volume { get; set; }
        public int UnadjustedVolume { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public double Vwap { get; set; }
        public string Label { get; set; }
        public double ChangeOverTime { get; set; }
    }
}
