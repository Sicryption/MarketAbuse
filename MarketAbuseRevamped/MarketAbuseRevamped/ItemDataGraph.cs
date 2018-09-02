using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarketAbuseRevamped
{
	public class ItemDataGraph : Form
	{
		public Item activeItem = null;

		private IContainer components = null;

		private Chart graph;

		public ItemDataGraph(Item item)
		{
			this.activeItem = item;
			this.InitializeComponent();
		}

		private void ItemDataGraph_Load(object sender, EventArgs e)
		{
			string text = this.DownloadString("https://api.rsbuddy.com/grandExchange?a=graph&start=0&g=1440&i=" + this.activeItem.id);
			MessageBox.Show(text);
		}

		private string DownloadString(string url)
		{
			WebClient webClient = new WebClient();
			string result = webClient.DownloadString(url);
			webClient.Dispose();
			return result;
		}

		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ChartArea chartArea = new ChartArea();
			Legend legend = new Legend();
			Series series = new Series();
			this.graph = new Chart();
			((ISupportInitialize)this.graph).BeginInit();
			base.SuspendLayout();
			chartArea.Name = "ChartArea1";
			this.graph.ChartAreas.Add(chartArea);
			legend.Name = "Legend1";
			this.graph.Legends.Add(legend);
			this.graph.Location = new Point(12, 12);
			this.graph.Name = "graph";
			this.graph.Palette = ChartColorPalette.None;
			series.ChartArea = "ChartArea1";
			series.ChartType = SeriesChartType.Line;
			series.Legend = "Legend1";
			series.Name = "Series1";
			this.graph.Series.Add(series);
			this.graph.Size = new Size(621, 395);
			this.graph.TabIndex = 0;
			this.graph.Text = "chart1";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(645, 419);
			base.Controls.Add(this.graph);
			base.Name = "ItemDataGraph";
			this.Text = "ItemDataGraph";
			base.Load += new EventHandler(this.ItemDataGraph_Load);
			((ISupportInitialize)this.graph).EndInit();
			base.ResumeLayout(false);
		}
	}
}
