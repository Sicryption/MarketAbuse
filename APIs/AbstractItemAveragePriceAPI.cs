using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    public abstract class AbstractItemAveragePriceAPI
    {
        public void run()
        {
            timer = new Timer(new TimerCallback(onTimerTick), null, 0, updateRate_ms);
        }

        ~AbstractItemAveragePriceAPI()
        {
            timer.Dispose();
        }

        public abstract ObservableCollection<OSRSItemAveragePrices> doAPIUpdate();
        private void onTimerTick(object sender)
        {
            ObservableCollection<OSRSItemAveragePrices> itemList = doAPIUpdate();

            ItemAveragePriceAPIUpdateEventArgs eventArgs = new ItemAveragePriceAPIUpdateEventArgs(itemList);
            OnItemAPIUpdate?.Invoke(this, eventArgs);
        }

        public event EventHandler<ItemAveragePriceAPIUpdateEventArgs> OnItemAPIUpdate;

        private Timer timer;
        private const int updateRate_ms = 60000;
    }
}
