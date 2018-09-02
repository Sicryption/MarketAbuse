using System;

namespace MarketAbuseRevamped
{
	public class Item
	{
		public string name;
		private int buyPrice;
		public int id, sellPrice, buyQuantity, sellQuantity, quantity = 1, shopPrice, lowAlch, highAlch, karamjaStore, generalStore;
		public bool members, favorited;

		public int margin
		{
			get
			{
				return sellPrice - BuyPrice;
			}
		}

		public int BuyPrice
		{
			get
			{
				int result;
				if (name != "Old school bond")
					return buyPrice;
				else
					return buyPrice + buyPrice / 10;
			}
			set
			{
				buyPrice = value;
			}
		}

		public Item(string pname, int pid, int sp, bool mem)
		{
			name = pname;
			id = pid;
			shopPrice = sp;
			members = mem;
			generalStore = (int)(sp / 2.5);
			lowAlch = (int)(sp * 0.4);
			highAlch = (int)(sp * 0.6);
			karamjaStore = (int)(lowAlch * 1.75);
		}

		public override string ToString()
		{
			return name;
		}
	}
}
