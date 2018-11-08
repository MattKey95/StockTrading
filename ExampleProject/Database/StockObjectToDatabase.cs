using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    public class StockObjectToDatabase
    {
        public void UpdateHistoricalData(List<HistoricalStockObject> objects, bool Overrider)
        {
            List<string> QueryList = new List<string>();

            foreach (var o in objects)
            {
                string sql =
                    "INSERT INTO HistoricalData (Ticker,DayDate,DayOpen,DayHigh,DayLow,DayClose,Volume,UnadjustedVolume,Change,ChangePercent,Vwap,Label,ChangeOverTime) " +
                    "VALUES(\'{0}\',\'{1}\',{2},{3},{4},{5},{6},{7},{8},{9},{10},\'{11}\',{12});";
                sql = string.Format(sql, o.Ticker, o.DayDate, o.DayOpen, o.DayHigh, o.DayLow, o.DayClose, o.Volume, o.UnadjustedVolume,
                    o.Change,o.ChangePercent, o.Vwap, o.Label, o.ChangeOverTime);

                QueryList.Add(sql);
            }

            DatabaseWriter.Writer.RunQueryList(QueryList);
        }
    }
}
