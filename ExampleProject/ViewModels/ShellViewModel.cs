using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ExampleProject.Database;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace ExampleProject.ViewModels
{
    public class ShellViewModel : Screen
    {
        public List<String> _tickers = new List<string>() { "AAPL","GOOG","GOOGL","YHOO","TSLA","INTC","AMZN","BIDU","ORCL","MSFT","ORCL","ATVI","NVDA","GME","LNKD","NFLX" };
        
        public List<string> Tickers
        {
            get { return _tickers; }
        }

        private SeriesCollection _num = new SeriesCollection();

        public SeriesCollection Num
        {
            get { return _num; }

            set { _num = value; }
        }

        private string _selected;

        public string Selected
        {
            get { return _selected; }
            set
            {
                _selected = value; 
                UpdateGraph();
            }
        }

        public void UpdateGraph()
        {
            Num.Clear();
            string query = String.Format("SELECT * FROM HistoricalData WHERE Ticker=\'{0}\'", Selected);
            Console.WriteLine(query);
            List<HistoricalStockObject> list = DatabaseReader.Reader.ReadFromDatabase<HistoricalStockObject>(query);

            LineSeries temp = new LineSeries
            {
                Values = new ChartValues<double>() {}
            };

            foreach (var l in list)
            {
                temp.Values.Add(l.DayClose);
            }
            
            Num.Add(temp);
        }
    }
}
