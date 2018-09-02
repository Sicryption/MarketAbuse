using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAbuse
{
    public partial class CreationForm : Form
    {
        List<object> createdObjects = new List<object>();
        List<CreationProcess> creationList = new List<CreationProcess>();
        MarketAbuse mainForm;

        public CreationForm(string name, List<CreationProcess> listOfItemsBeingCreated, MarketAbuse mainform)
        {
            mainForm = mainform;
            InitializeComponent();
            Text = name;
            creationList = listOfItemsBeingCreated;

            OrganizeListbox(creationList.Where(a => a != null).OrderBy(a => a.completedItemsNameList).ToList());
            Size = new Size(302, 320);
        }

        public static List<Item> UpdateList(List<Item> list)
        {
            for(int i = 0; i < list.Count(); i++)
                foreach (Item i2 in MarketAbuse.ItemList)
                    if (list[i].name == i2.name && list[i].id == i2.id)
                    {
                        list[i].buyPrice = i2.buyPrice;
                        list[i].overallPrice = i2.overallPrice;
                        list[i].sellPrice = i2.sellPrice;
                        list[i].sellQuantity = i2.sellQuantity;
                        list[i].buyQuantity = i2.buyQuantity;
                        break;
                    }
            return list;
        }

        public void CreateLabel(string text, ref Point location, ref List<object> objectArray, GroupBox container, CreationProcess process, Item i = null)
        {
            Label temp = new Label();
            container.Controls.Add(temp);
            temp.Location = location;
            temp.AutoSize = true;
            temp.Text = text;


            if (i != null)
            {
                temp.Tag = i.id;
                temp.DoubleClick += new EventHandler(updateitem);
            }

            if (text.Contains("Name: "))
            {
                PictureBox image = new PictureBox();
                container.Controls.Add(image);
                Point loc = new Point(location.X + 175, location.Y);
                image.Location = loc;
                image.Tag = i.id;
                if(i != null)
                    image.Load("http://cdn.rsbuddy.com/items/" + i.id + ".png");
                image.DoubleClick += new EventHandler(updateitem);
                image.Size = image.Image.Size;
                objectArray.Add(image);
            }

            if (process.margin != "null" && text.Contains("Margin: "))
            {
                if (int.Parse(process.margin) > 0)
                    temp.ForeColor = Color.Green;
                else if (int.Parse(process.margin) == 0)
                    temp.ForeColor = SystemColors.ControlText;
                else if (int.Parse(process.margin) < 0)
                    temp.ForeColor = Color.Red;
            }

            location.Y += temp.Height + 7;
            objectArray.Add(temp);
        }

        private void itemCombinations_DoubleClick(object sender, EventArgs e)
        {
            if (sender == null || ((ListBox)sender) == null || ((ListBox)sender).SelectedItem == null || ((ListBox)sender).SelectedItem.ToString() == null)
                return;

            MarketAbuse.UpdateGEInformation();
            for (int i = 0; i < creationList.Count(); i++)
            {
                creationList[i].completedItems = UpdateList(creationList[i].completedItems);
                creationList[i].itemsNeeded = UpdateList(creationList[i].itemsNeeded);
            }

            this.Size = new Size(594, 320);

            CreationProcess process = ((ListBox)sender).SelectedItem as CreationProcess;

            if (process != null)
            {
                Point objectPosition = new Point(6, 16);

                foreach (object o in createdObjects)
                {
                    if (o.GetType() == typeof(PictureBox))
                        ((PictureBox)o).Dispose();
                    else if(o.GetType() == typeof(Label))
                        ((Label)o).Dispose();
                    else if (o.GetType() == typeof(Panel))
                        ((Panel)o).Dispose();
                }

                createdObjects.Clear();

                foreach (Item i in process.itemsNeeded)
                {
                    i.UpdateItemData();
                    string nameAmount = (i.quantity == 1) ? "Name: " + i.name : "Name: " + i.name + " x" + i.quantity;
                    string buyamount = (i.quantity == 1) ? "Buy Price: " + (i.buyPrice).ToString("#,##0")
                        : "Buy Price: " + (i.buyPrice * i.quantity).ToString("#,##0") + " (" + i.buyPrice + " ea)";
                    CreateLabel(nameAmount, ref objectPosition, ref createdObjects, groupBox3, process, i);

                    Panel tempPanel = new Panel();
                    tempPanel.Location = ((Label)createdObjects[createdObjects.Count() -1]).Location;

                    CreateLabel(buyamount, ref objectPosition, ref createdObjects, groupBox3, process, i);

                    Label label = ((Label)createdObjects[createdObjects.Count() - 1]);
                    Size s = new Size(tempPanel.Width, label.Location.Y - tempPanel.Location.Y + label.Height);
                    tempPanel.Size = s;
                    tempPanel.DoubleClick += new EventHandler(updateitem);
                    tempPanel.BorderStyle = BorderStyle.None;
                    tempPanel.Parent = groupBox3;
                    tempPanel.Tag = i.id;
                    createdObjects.Add(tempPanel);
                }

                foreach (Item i in process.completedItems)
                {
                    string nameAmount = (i.quantity == 1)? "Name: " + i.name: "Name: " + i.name + " x" + i.quantity;
                    string sellamount = (i.quantity == 1) ? "Sell Price: " + (i.sellPrice).ToString("#,##0")
                        : "Sell Price: " + (i.sellPrice * i.quantity).ToString("#,##0") + " (" + i.sellPrice + " ea)";


                    CreateLabel(nameAmount, ref objectPosition, ref createdObjects, groupBox3, process, i);

                    Panel tempPanel = new Panel();
                    tempPanel.Location = ((Label)createdObjects[createdObjects.Count() - 1]).Location;

                    CreateLabel(sellamount, ref objectPosition, ref createdObjects, groupBox3, process, i);

                    Label label = ((Label)createdObjects[createdObjects.Count() - 1]);
                    Size s = new Size(tempPanel.Width, label.Location.Y - tempPanel.Location.Y + label.Height);
                    tempPanel.Size = s;
                    tempPanel.DoubleClick += new EventHandler(updateitem);
                    tempPanel.BorderStyle = BorderStyle.None;
                    tempPanel.Parent = groupBox3;
                    tempPanel.Tag = i.id;
                    createdObjects.Add(tempPanel);
                }
                string margin = (process.margin == "null") ? "Margin: " + process.margin
                    : "Margin: " + int.Parse(process.margin).ToString("#,##0");
                CreateLabel(margin, ref objectPosition, ref createdObjects, groupBox3, process);
            }
            else
                MessageBox.Show("This item has not been configured yet.");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketAbuse.UpdateGEInformation();

            itemCombinations.Items.Clear();
            switch (comboBox1.Text)
            {
                case "Alphabatize":
                    OrganizeListbox(creationList.Where(a => a.margin != "null").OrderBy(a => a.completedItemsNameList).ToList());
                    break;
                case "Highest Profit":
                    OrganizeListbox(creationList.Where(a => a.margin != "null").OrderByDescending(a => int.Parse(a.margin)).ToList());
                    break;
                case "Lowest Profit":
                    OrganizeListbox(creationList.Where(a => a.margin != "null").OrderBy(a => int.Parse(a.margin)).ToList());
                    break;
            }
        }

        private void OrganizeListbox(List<CreationProcess> list)
        {
            if (list == null)
                return;

            foreach (CreationProcess i in list)
            {
                foreach (Item item in i.itemsNeeded)
                    if (item.buyPrice == 0)
                        i.margin = "null";
                foreach (Item item in i.completedItems)
                    if (item.sellPrice == 0)
                        i.margin = "null";

                bool isNotNull = false;
                foreach (Item item in i.completedItems)
                    if (i.margin != "null")
                        isNotNull = true;
                if (isNotNull)
                    itemCombinations.Items.Add(i);
            }
            foreach (CreationProcess i in creationList.Where(a => a != null).OrderBy(a => a.completedItemsNameList).ToList())
                if (i.margin == "null")
                    itemCombinations.Items.Add(i);
        }

        private void updateitem(object sender, EventArgs e)
        {
            if (mainForm != null)
            {
                mainForm.UpdateItemListing(MarketAbuse.GetItem((int)(((Control)sender).Tag)));
                mainForm.BringToFront();
            }
        }
    }
}
