using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    abstract class AbstractItemPriceAPI
    {
        public void run()
        {
            timer = new Timer(new TimerCallback(onTimerTick), null, 0, updateRate_ms);
        }

        ~AbstractItemPriceAPI()
        {
            timer.Dispose();
        }

        public abstract ObservableCollection<OSRSItemPrices> doAPIUpdate();
        private void onTimerTick(object sender)
        {
            ObservableCollection<OSRSItemPrices> itemList = doAPIUpdate();

            ItemPriceAPIUpdateEventArgs eventArgs = new ItemPriceAPIUpdateEventArgs(itemList);
            OnItemAPIUpdate?.Invoke(this, eventArgs);
        }

        public event EventHandler<ItemPriceAPIUpdateEventArgs> OnItemAPIUpdate;

        private Timer timer;
        private const int updateRate_ms = 30000;
    }
}
