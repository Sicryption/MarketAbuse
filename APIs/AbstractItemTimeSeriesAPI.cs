using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    public abstract class AbstractItemTimeSeriesAPI
    {
        public AbstractItemTimeSeriesAPI(uint itemId)
        {
            this.itemId = itemId;
        }

        public void run()
        {
            Task task = new Task(() =>
            {
                var timeSeriesData = getTimeSeries(itemId);

                ItemTimeSeriesAPIUpdateEventArgs args = new ItemTimeSeriesAPIUpdateEventArgs(itemId, timeSeriesData);

                OnItemAPIUpdate?.Invoke(this, args);
            }
            );

            task.Start();
        }

        public abstract ObservableCollection<OSRSItemTimeSeries> getTimeSeries(uint itemId);

        public event EventHandler<ItemTimeSeriesAPIUpdateEventArgs> OnItemAPIUpdate;

        uint itemId;
    }
}
