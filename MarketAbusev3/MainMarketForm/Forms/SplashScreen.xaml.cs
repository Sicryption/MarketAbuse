using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainMarketForm
{
    /// <summary>
    /// Interaction logic for SplashScreeen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private Thread initialLaunchThread;
        public Thread IHThread;
        private ItemHandler IH;
        public MainWindow MW;

        public SplashScreen()
        {
            InitializeComponent();
            IH = new ItemHandler();

            MW = new MainWindow(this, IH);
            IH.SS = this;

            initialLaunchThread = new Thread(HandleInitialLaunch);
            initialLaunchThread.Start();

            //initial launch thread stops at this point
            //the Item handler Thread is active
            //this form is hidden
            //Main Window is active and showing
        }

        public void HandleInitialLaunch()
        {
            UpdateProgressBar(0, "Checking for internet connection");
            if (InternetCheck())
                UpdateProgressBar(20, "Connection Successful");
            else
            {
                UpdateProgressBar(20, "No Active Connection!");
                MessageBox.Show("Unable to connect to the internet");
                Environment.Exit(0);
            }

            UpdateProgressBar(30, "Checking for updates");
            if (VersionCheck())
                UpdateProgressBar(50, "No Updates Found");
            else
            {
                UpdateProgressBar(40, "Update Found");
                UpdateProgressBar(50, "Attempting to Update");
                TryUpdate();
            }

            UpdateProgressBar(60, "Downloading Price Summary");

            //initiate item refreshing
            IHThread = new Thread(IH.RefreshItemList);
            IHThread.Start();
        }

        public bool InternetCheck()
        {
            WebClient wc = new WebClient();
            bool returnValue;
            try
            {
                wc.DownloadString("https://raw.githubusercontent.com/Sicryption/MarketAbuse/master/UpdateVersion");
                returnValue = true;
            }
            catch { returnValue = false; }

            wc.Dispose();
            return returnValue;
        }

        public void UpdateProgressBar(int value, string text)
        {
            this.Dispatcher.Invoke(() =>
            {
                ProgressBar.Value = value;
                ProgressStatus.Text = text;
            });
            Thread.Sleep(100);
        }

        public void OpenMainWindow()
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Hide();
                MW.Show();
            });
        }

        public bool VersionCheck()
        {
            WebClient wc = new WebClient();
            string s = wc.DownloadString("https://raw.githubusercontent.com/Sicryption/MarketAbuse/master/UpdateVersion");
            wc.Dispose();

            if (isVersionUpgrade(s))
                return false;

            return true;
        }

        public bool isVersionUpgrade(string version)
        {
            string[] values = version.Split('.');
            values[3].Replace("\n", "");
            string[] currentValues = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');

            for (int i = 0; i < values.Length; i++)
                if (Convert.ToInt32(values[i]) > Convert.ToInt32(currentValues[i]))
                    return true;

            return false;
        }

        public void TryUpdate()
        {
            string updaterName = "Updater.exe",
                updatedFileName = "Market Abuse Updated.exe",
                updateURL,
                updateURLURL = "https://raw.githubusercontent.com/Sicryption/MarketAbuse/master/UpdateURL",
                updaterURL,
                updaterURLURL = "https://raw.githubusercontent.com/Sicryption/MarketAbuse/master/UpdaterURL";

            WebClient wc = new WebClient();
            updateURL = wc.DownloadString(updateURLURL).Replace("\n", "");
            var e = Environment.GetCommandLineArgs();
            wc.DownloadFile(updateURL, updatedFileName);

            updaterURL = wc.DownloadString(updaterURLURL).Replace("\n", "");
            if (!File.Exists(updaterName))
                wc.DownloadFile(updaterURL, updaterName);

            Process.Start(updaterName, "\"" + Process.GetCurrentProcess().ProcessName + "\" \"" + System.AppDomain.CurrentDomain.FriendlyName + "\" \"" + updatedFileName + "\"");

            wc.Dispose();

            Environment.Exit(0);
        }
    }
}
