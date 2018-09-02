namespace MarketAbuse
{
    partial class MarketAbuse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (SecondForm != null)
                    SecondForm.Close();
                FavoriteWriter();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketAbuse));
            this.directLookupTextbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.itemLookupTextbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.itemlistbox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sellquantity = new System.Windows.Forms.Label();
            this.buyquantity = new System.Windows.Forms.Label();
            this.marginValue = new System.Windows.Forms.Label();
            this.margin = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.avgbuy = new System.Windows.Forms.Label();
            this.avgoverall = new System.Windows.Forms.Label();
            this.avgsell = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.marginupdate = new System.Windows.Forms.Button();
            this.marginlistbox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oSBuddyExchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.favoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poisonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.constructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.craftingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farmingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fletchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herbloreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barbarianMixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herbCleaningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.potionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runecraftingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smithingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.priceLimit = new System.Windows.Forms.NumericUpDown();
            this.members = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // directLookupTextbox
            // 
            this.directLookupTextbox.Location = new System.Drawing.Point(6, 19);
            this.directLookupTextbox.Name = "directLookupTextbox";
            this.directLookupTextbox.Size = new System.Drawing.Size(167, 20);
            this.directLookupTextbox.TabIndex = 0;
            this.directLookupTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.directSearchbox);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(218, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.itemLookupTextbox);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.itemlistbox);
            this.groupBox4.Location = new System.Drawing.Point(12, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 224);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Lookup";
            // 
            // itemLookupTextbox
            // 
            this.itemLookupTextbox.Location = new System.Drawing.Point(6, 19);
            this.itemLookupTextbox.Name = "itemLookupTextbox";
            this.itemLookupTextbox.Size = new System.Drawing.Size(167, 20);
            this.itemLookupTextbox.TabIndex = 4;
            this.itemLookupTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listboxSearchbox);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // itemlistbox
            // 
            this.itemlistbox.FormattingEnabled = true;
            this.itemlistbox.Location = new System.Drawing.Point(6, 44);
            this.itemlistbox.Name = "itemlistbox";
            this.itemlistbox.ScrollAlwaysVisible = true;
            this.itemlistbox.Size = new System.Drawing.Size(252, 173);
            this.itemlistbox.Sorted = true;
            this.itemlistbox.TabIndex = 3;
            this.itemlistbox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClicked);
            this.itemlistbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxSnap_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.directLookupTextbox);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(12, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 56);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Direct Lookup";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sellquantity);
            this.groupBox2.Controls.Add(this.buyquantity);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.marginValue);
            this.groupBox2.Controls.Add(this.margin);
            this.groupBox2.Controls.Add(this.name);
            this.groupBox2.Controls.Add(this.avgbuy);
            this.groupBox2.Controls.Add(this.avgoverall);
            this.groupBox2.Controls.Add(this.avgsell);
            this.groupBox2.Location = new System.Drawing.Point(280, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 141);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // sellquantity
            // 
            this.sellquantity.AutoSize = true;
            this.sellquantity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sellquantity.Location = new System.Drawing.Point(7, 106);
            this.sellquantity.Name = "sellquantity";
            this.sellquantity.Size = new System.Drawing.Size(83, 13);
            this.sellquantity.TabIndex = 11;
            this.sellquantity.Text = "Selling Quantity:";
            // 
            // buyquantity
            // 
            this.buyquantity.AutoSize = true;
            this.buyquantity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buyquantity.Location = new System.Drawing.Point(7, 88);
            this.buyquantity.Name = "buyquantity";
            this.buyquantity.Size = new System.Drawing.Size(84, 13);
            this.buyquantity.TabIndex = 10;
            this.buyquantity.Text = "Buying Quantity:";
            // 
            // marginValue
            // 
            this.marginValue.AutoSize = true;
            this.marginValue.Location = new System.Drawing.Point(47, 124);
            this.marginValue.Name = "marginValue";
            this.marginValue.Size = new System.Drawing.Size(34, 13);
            this.marginValue.TabIndex = 8;
            this.marginValue.Text = "Value";
            // 
            // margin
            // 
            this.margin.AutoSize = true;
            this.margin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.margin.Location = new System.Drawing.Point(7, 124);
            this.margin.Name = "margin";
            this.margin.Size = new System.Drawing.Size(45, 13);
            this.margin.TabIndex = 6;
            this.margin.Text = "Margin: ";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(6, 16);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(41, 13);
            this.name.TabIndex = 5;
            this.name.Text = "Name: ";
            // 
            // avgbuy
            // 
            this.avgbuy.AutoSize = true;
            this.avgbuy.Location = new System.Drawing.Point(7, 34);
            this.avgbuy.Name = "avgbuy";
            this.avgbuy.Size = new System.Drawing.Size(71, 13);
            this.avgbuy.TabIndex = 2;
            this.avgbuy.Text = "Average Buy:";
            // 
            // avgoverall
            // 
            this.avgoverall.AutoSize = true;
            this.avgoverall.Location = new System.Drawing.Point(7, 52);
            this.avgoverall.Name = "avgoverall";
            this.avgoverall.Size = new System.Drawing.Size(86, 13);
            this.avgoverall.TabIndex = 3;
            this.avgoverall.Text = "Average Overall:";
            // 
            // avgsell
            // 
            this.avgsell.AutoSize = true;
            this.avgsell.Location = new System.Drawing.Point(7, 70);
            this.avgsell.Name = "avgsell";
            this.avgsell.Size = new System.Drawing.Size(70, 13);
            this.avgsell.TabIndex = 4;
            this.avgsell.Text = "Average Sell:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.marginupdate);
            this.groupBox5.Controls.Add(this.marginlistbox);
            this.groupBox5.Location = new System.Drawing.Point(280, 181);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(264, 213);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Margins";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(175, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 20);
            this.button4.TabIndex = 6;
            this.button4.Text = "Quantity";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 20);
            this.button3.TabIndex = 5;
            this.button3.Text = "Favorites";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // marginupdate
            // 
            this.marginupdate.Location = new System.Drawing.Point(6, 19);
            this.marginupdate.Name = "marginupdate";
            this.marginupdate.Size = new System.Drawing.Size(80, 20);
            this.marginupdate.TabIndex = 2;
            this.marginupdate.Text = "Highest";
            this.marginupdate.UseVisualStyleBackColor = true;
            this.marginupdate.Click += new System.EventHandler(this.marginupdate_Click);
            // 
            // marginlistbox
            // 
            this.marginlistbox.FormattingEnabled = true;
            this.marginlistbox.Location = new System.Drawing.Point(6, 45);
            this.marginlistbox.Name = "marginlistbox";
            this.marginlistbox.ScrollAlwaysVisible = true;
            this.marginlistbox.Size = new System.Drawing.Size(246, 160);
            this.marginlistbox.TabIndex = 4;
            this.marginlistbox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClicked);
            this.marginlistbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxSnap_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(549, 32);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.oSBuddyExchangeToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(37, 29);
            this.toolStripDropDownButton1.Text = "Options";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // oSBuddyExchangeToolStripMenuItem
            // 
            this.oSBuddyExchangeToolStripMenuItem.Name = "oSBuddyExchangeToolStripMenuItem";
            this.oSBuddyExchangeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.oSBuddyExchangeToolStripMenuItem.Text = "OSBuddy Exchange";
            this.oSBuddyExchangeToolStripMenuItem.Click += new System.EventHandler(this.oSBuddyExchangeToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AutoToolTip = false;
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoritesToolStripMenuItem,
            this.alterationsToolStripMenuItem,
            this.poisonsToolStripMenuItem,
            this.setsToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(38, 29);
            this.toolStripDropDownButton2.Text = "Programs";
            this.toolStripDropDownButton2.ToolTipText = "Programs";
            // 
            // favoritesToolStripMenuItem
            // 
            this.favoritesToolStripMenuItem.Name = "favoritesToolStripMenuItem";
            this.favoritesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.favoritesToolStripMenuItem.Text = "Favorites";
            this.favoritesToolStripMenuItem.Click += new System.EventHandler(this.favoritesToolStripMenuItem_Click);
            // 
            // alterationsToolStripMenuItem
            // 
            this.alterationsToolStripMenuItem.Name = "alterationsToolStripMenuItem";
            this.alterationsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.alterationsToolStripMenuItem.Text = "Alterations";
            this.alterationsToolStripMenuItem.Click += new System.EventHandler(this.alterationsToolStripMenuItem_Click);
            // 
            // poisonsToolStripMenuItem
            // 
            this.poisonsToolStripMenuItem.Name = "poisonsToolStripMenuItem";
            this.poisonsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.poisonsToolStripMenuItem.Text = "Poisons";
            this.poisonsToolStripMenuItem.Click += new System.EventHandler(this.poisonsToolStripMenuItem_Click);
            // 
            // setsToolStripMenuItem
            // 
            this.setsToolStripMenuItem.Name = "setsToolStripMenuItem";
            this.setsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.setsToolStripMenuItem.Text = "Sets";
            this.setsToolStripMenuItem.Click += new System.EventHandler(this.setsToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constructionToolStripMenuItem,
            this.craftingToolStripMenuItem,
            this.farmingToolStripMenuItem,
            this.fletchingToolStripMenuItem,
            this.herbloreToolStripMenuItem,
            this.magicToolStripMenuItem,
            this.prayerToolStripMenuItem,
            this.runecraftingToolStripMenuItem,
            this.smithingToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(38, 29);
            this.toolStripDropDownButton3.Text = "Skilling";
            this.toolStripDropDownButton3.ToolTipText = "Skilling";
            // 
            // constructionToolStripMenuItem
            // 
            this.constructionToolStripMenuItem.Name = "constructionToolStripMenuItem";
            this.constructionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.constructionToolStripMenuItem.Text = "Construction";
            this.constructionToolStripMenuItem.Click += new System.EventHandler(this.constructionToolStripMenuItem_Click);
            // 
            // craftingToolStripMenuItem
            // 
            this.craftingToolStripMenuItem.Name = "craftingToolStripMenuItem";
            this.craftingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.craftingToolStripMenuItem.Text = "Crafting";
            this.craftingToolStripMenuItem.Click += new System.EventHandler(this.craftingToolStripMenuItem_Click);
            // 
            // farmingToolStripMenuItem
            // 
            this.farmingToolStripMenuItem.Name = "farmingToolStripMenuItem";
            this.farmingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.farmingToolStripMenuItem.Text = "Farming";
            this.farmingToolStripMenuItem.Click += new System.EventHandler(this.farmingToolStripMenuItem_Click);
            // 
            // fletchingToolStripMenuItem
            // 
            this.fletchingToolStripMenuItem.Name = "fletchingToolStripMenuItem";
            this.fletchingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fletchingToolStripMenuItem.Text = "Fletching";
            this.fletchingToolStripMenuItem.Click += new System.EventHandler(this.fletchingToolStripMenuItem_Click);
            // 
            // herbloreToolStripMenuItem
            // 
            this.herbloreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barbarianMixToolStripMenuItem,
            this.decantToolStripMenuItem,
            this.herbCleaningToolStripMenuItem,
            this.potionsToolStripMenuItem,
            this.unfinishedToolStripMenuItem});
            this.herbloreToolStripMenuItem.Name = "herbloreToolStripMenuItem";
            this.herbloreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.herbloreToolStripMenuItem.Text = "Herblore";
            // 
            // barbarianMixToolStripMenuItem
            // 
            this.barbarianMixToolStripMenuItem.Name = "barbarianMixToolStripMenuItem";
            this.barbarianMixToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.barbarianMixToolStripMenuItem.Text = "Barbarian Mix";
            this.barbarianMixToolStripMenuItem.Click += new System.EventHandler(this.barbarianMixToolStripMenuItem_Click);
            // 
            // decantToolStripMenuItem
            // 
            this.decantToolStripMenuItem.Name = "decantToolStripMenuItem";
            this.decantToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.decantToolStripMenuItem.Text = "Decant";
            this.decantToolStripMenuItem.Click += new System.EventHandler(this.decantToolStripMenuItem_Click);
            // 
            // herbCleaningToolStripMenuItem
            // 
            this.herbCleaningToolStripMenuItem.Name = "herbCleaningToolStripMenuItem";
            this.herbCleaningToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.herbCleaningToolStripMenuItem.Text = "Herb Cleaning";
            this.herbCleaningToolStripMenuItem.Click += new System.EventHandler(this.herbCleaningToolStripMenuItem_Click);
            // 
            // potionsToolStripMenuItem
            // 
            this.potionsToolStripMenuItem.Name = "potionsToolStripMenuItem";
            this.potionsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.potionsToolStripMenuItem.Text = "Potions";
            this.potionsToolStripMenuItem.Click += new System.EventHandler(this.potionsToolStripMenuItem_Click);
            // 
            // unfinishedToolStripMenuItem
            // 
            this.unfinishedToolStripMenuItem.Name = "unfinishedToolStripMenuItem";
            this.unfinishedToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.unfinishedToolStripMenuItem.Text = "Unfinished";
            this.unfinishedToolStripMenuItem.Click += new System.EventHandler(this.unfinishedToolStripMenuItem_Click);
            // 
            // magicToolStripMenuItem
            // 
            this.magicToolStripMenuItem.Name = "magicToolStripMenuItem";
            this.magicToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.magicToolStripMenuItem.Text = "Magic";
            this.magicToolStripMenuItem.Click += new System.EventHandler(this.magicToolStripMenuItem_Click);
            // 
            // prayerToolStripMenuItem
            // 
            this.prayerToolStripMenuItem.Name = "prayerToolStripMenuItem";
            this.prayerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.prayerToolStripMenuItem.Text = "Prayer";
            this.prayerToolStripMenuItem.Click += new System.EventHandler(this.prayerToolStripMenuItem_Click);
            // 
            // runecraftingToolStripMenuItem
            // 
            this.runecraftingToolStripMenuItem.Name = "runecraftingToolStripMenuItem";
            this.runecraftingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runecraftingToolStripMenuItem.Text = "Runecrafting";
            this.runecraftingToolStripMenuItem.Click += new System.EventHandler(this.runecraftingToolStripMenuItem_Click);
            // 
            // smithingToolStripMenuItem
            // 
            this.smithingToolStripMenuItem.Name = "smithingToolStripMenuItem";
            this.smithingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.smithingToolStripMenuItem.Text = "Smithing";
            this.smithingToolStripMenuItem.Click += new System.EventHandler(this.smithingToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.priceLimit);
            this.groupBox1.Controls.Add(this.members);
            this.groupBox1.Location = new System.Drawing.Point(12, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 68);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Money Available";
            // 
            // priceLimit
            // 
            this.priceLimit.Location = new System.Drawing.Point(111, 39);
            this.priceLimit.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.priceLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.priceLimit.Name = "priceLimit";
            this.priceLimit.Size = new System.Drawing.Size(151, 20);
            this.priceLimit.TabIndex = 1;
            this.priceLimit.Value = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            // 
            // members
            // 
            this.members.AutoSize = true;
            this.members.Checked = true;
            this.members.CheckState = System.Windows.Forms.CheckState.Checked;
            this.members.Location = new System.Drawing.Point(9, 19);
            this.members.Name = "members";
            this.members.Size = new System.Drawing.Size(125, 17);
            this.members.TabIndex = 0;
            this.members.Text = "Allow Members Items";
            this.members.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // refreshItemToolStripMenuItem
            // 
            this.refreshItemToolStripMenuItem.Name = "refreshItemToolStripMenuItem";
            this.refreshItemToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // favoriteToolStripMenuItem
            // 
            this.favoriteToolStripMenuItem.Name = "favoriteToolStripMenuItem";
            this.favoriteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MarketAbuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MarketAbuse";
            this.Text = "MarketAbuse";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox directLookupTextbox;
        private System.Windows.Forms.Label avgsell;
        private System.Windows.Forms.Label avgoverall;
        private System.Windows.Forms.Label avgbuy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox itemlistbox;
        private System.Windows.Forms.TextBox itemLookupTextbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label margin;
        private System.Windows.Forms.Label marginValue;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button marginupdate;
        private System.Windows.Forms.ListBox marginlistbox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oSBuddyExchangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem alterationsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown priceLimit;
        public System.Windows.Forms.CheckBox members;
        private System.Windows.Forms.Label sellquantity;
        private System.Windows.Forms.Label buyquantity;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem craftingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fletchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herbloreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smithingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favoriteToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem favoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poisonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem farmingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runecraftingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constructionToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem unfinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herbCleaningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem potionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barbarianMixToolStripMenuItem;
    }
}

