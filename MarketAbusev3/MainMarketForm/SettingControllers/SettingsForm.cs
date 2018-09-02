using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMarketForm
{
    public class SettingsForm
    {
        public Settings form;
        public MainWindow MW;

        public SettingsForm(MainWindow mw)
        {
            MW = mw;
            form = new Settings();
            
            form.CloseButton.Click += (s, e) => form.Hide();
        }

        public void Show()
        {
            form.Show();
            form.Activate();
        }
    }
}
