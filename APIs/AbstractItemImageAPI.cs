using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    abstract class AbstractItemImageAPI
    {
        public void run(ObservableCollection<OSRSItemInformation> itemList)
        {
            Task getImages = new Task(() =>
            {
                var imageList = new ObservableCollection<OSRSItemImage>();
                var threadList = new List<Thread>();

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                foreach (var item in itemList)
                {
                    string imagePath = imageFolder + item.IconName;

                    if (!File.Exists(imagePath))
                    {
                        Thread thread = new Thread
                        (
                            () =>
                            {
                                OSRSItemImage itemImage = getItemImage(item.IconName);
                                itemImage.itemName = item.Name;

                                if (itemImage.Image != null)
                                {
                                    File.WriteAllBytes(imagePath, itemImage.Image);
                                }

                                lock(imageList)
                                {
                                    imageList.Add(itemImage);
                                }
                            }
                        );
                        threadList.Add(thread);
                        thread.Start();
                    }
                    else
                    {
                        OSRSItemImage itemImage = new OSRSItemImage();
                        itemImage.itemName = item.Name;
                        itemImage.Image = File.ReadAllBytes(imagePath);

                        lock (imageList)
                        {
                            imageList.Add(itemImage);
                        }
                    }
                }

                foreach (var thread in threadList)
                {
                    thread.Join();
                }

                ItemImageAPIUpdateEventArgs eventArgs = new ItemImageAPIUpdateEventArgs(imageList);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    OnItemAPIUpdate?.Invoke(this, eventArgs);
                });
            });

            getImages.Start();
        }

        public abstract OSRSItemImage getItemImage(string itemName);

        public event EventHandler<ItemImageAPIUpdateEventArgs> OnItemAPIUpdate;
        public const string imageFolder = "images/";
    }

}
