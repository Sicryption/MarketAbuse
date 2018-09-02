using System;

namespace MarketAbuseRevamped
{
	public class ShopItem
	{
		public Item Item;

		public int Cost, Quantity;

		public ShopItem(Item i, int cost, int quantity)
		{
			this.Item = i;
			this.Cost = cost;
			this.Quantity = quantity;
		}

		public int margin()
		{
			return this.Item.sellPrice - this.Cost;
		}

		public override string ToString()
		{
			return this.Item.name;
		}

		public string generateID()
		{
			return this.Item.name + "_" + ShopList.GetShop(this).Name;
		}
	}
}
