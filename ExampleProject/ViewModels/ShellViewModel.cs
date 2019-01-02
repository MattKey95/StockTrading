using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using ExampleProject.Database;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Threading;

namespace ExampleProject.ViewModels
{
    public class ShellViewModel : Screen
    {
        public List<String> _tickers = new List<string>() { "AAPL","GOOG","GOOGL", "TSLA","INTC","AMZN","BIDU","ORCL","MSFT","ORCL","ATVI","NVDA","GME","NFLX" };
        
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
            List<object[]> list = new List<object[]>();
            List<HistoricalStockObject> objects = new List<HistoricalStockObject>();
            
                
            Num.Clear();
            Task.Run(() =>
            {
                string query = String.Format("SELECT * FROM HistoricalData WHERE Ticker=\'{0}\'", Selected);
                Console.WriteLine(query);
                list = DatabaseReader.Reader.ReadFromDatabase(query);
                objects = DataRecordToStockObject.Converter.ToHistorical(list);
            });

            LineSeries temp = new LineSeries
            {
                Values = new ChartValues<double>() { }
            };
            
            foreach (var l in objects)
            {
                temp.Values.Add(l.DayClose);
            }
            
            Num.Add(temp);
        }

        public void UpdateStocks()
        {
            DataUpdater.Updater.UpdateHistoricalData();
        }
    }
}
