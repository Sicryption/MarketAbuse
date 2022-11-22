using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using MarketAbuse.APIs;
using MarketAbuse.OSRSObjects;
using MarketAbuse.Filters;
using MarketAbuse.Sorts;
using LiveCharts;
using LiveCharts.Wpf;
using MarketAbuse.Converters;

namespace MarketAbuse
{
    public partial class TimeSeriesDisplay : Window
    {
        public TimeSeriesDisplay(OSRSItemViewModel viewModel, ObservableCollection<OSRSItemTimeSeries> timeSeriesData)
        {
            ItemViewModel = viewModel;

            createSeriesCollection(timeSeriesData);
            converter = new UtcToLocalDateTimeConverter();

            InitializeComponent();

            itemNameLabel.DataContext = this;
            itemImage.DataContext = this;
            timeseriesChart.DataContext = this;

            XFormatter = value => converter.RawConvert(timeSeriesData[(int)value].timestamp).ToString();
            YFormatter = value => string.Format("{0:n0}", value);

            setupMaxYRange(timeSeriesData);
        }

        private void setupMaxYRange(ObservableCollection<OSRSItemTimeSeries> timeSeriesData)
        {
            var highestPrice = timeSeriesData.OrderByDescending(a => a.averageHighPrice).First().averageHighPrice;
            var lowestPrice = timeSeriesData.OrderBy(a => a.averageLowPrice).First().averageLowPrice;

            var range = highestPrice - lowestPrice;

            MaxYRange = (long)(range * 1.5);
        }

        private void createSeriesCollection(ObservableCollection<OSRSItemTimeSeries> timeSeriesData)
        {
            SeriesCollection = new SeriesCollection();
            ChartValues<int> averageHighPrice = new ChartValues<int>();
            ChartValues<int> averageLowPrice = new ChartValues<int>();

            foreach (var timeSeries in timeSeriesData)
            {
                averageHighPrice.Add(timeSeries.averageHighPrice);
                averageLowPrice.Add(timeSeries.averageLowPrice);
            }

            LineSeries highPriceLineSeries = new LineSeries
            {
                Title = "Average High Price",
                Values = averageHighPrice,
                PointGeometrySize = 0
            };

            LineSeries lowPriceLineSeries = new LineSeries
            {
                Title = "Average Low Price",
                Values = averageLowPrice,
                PointGeometrySize = 0
            };

            SeriesCollection.Add(highPriceLineSeries);
            SeriesCollection.Add(lowPriceLineSeries);
        }

        public OSRSItemViewModel ItemViewModel { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public long MaxYRange { get; set; }

        private readonly UtcToLocalDateTimeConverter converter;
    }
}
