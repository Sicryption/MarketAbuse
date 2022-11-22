using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    abstract class AbstractItemInformationAPI
    {
        public void run()
        {
            Task task = new Task(() =>
            {

                ItemInformationAPIUpdateEventArgs args = new ItemInformationAPIUpdateEventArgs(doAPIUpdate());

                OnItemAPIUpdate?.Invoke(this, args);
            });

            task.Start();
        }

        public abstract ObservableCollection<OSRSItemInformation> doAPIUpdate();

        public event EventHandler<ItemInformationAPIUpdateEventArgs> OnItemAPIUpdate;
    }

}
