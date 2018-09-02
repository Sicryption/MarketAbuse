using System;
using System.Collections.Generic;

namespace MarketAbuseRevamped
{
	public class Shop
	{
		public List<ShopItem> Items;

		public string Name, Location, ShopKeeper, ExtraNotes;
		public bool Members;

		public Shop(string name, string location, string shopkeeper, string extraNotes, bool members, List<ShopItem> items)
		{
			this.Name = name;
			this.Items = items;
			this.Location = location;
			this.ShopKeeper = shopkeeper;
			this.ExtraNotes = extraNotes;
			this.Members = members;
		}
	}
}
