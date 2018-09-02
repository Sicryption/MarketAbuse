using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketAbuseRevamped
{
	internal class CreationSet
	{
		public List<Creation> Creations = new List<Creation>();

		public CreationSet(params List<Creation>[] creations)
		{
			for (int i = 0; i < creations.Length; i++)
			{
				List<Creation> second = creations[i];
				this.Creations = this.Creations.Concat(second).ToList<Creation>();
			}
		}

		public CreationSet(params CreationSet[] creations)
		{
			for (int i = 0; i < creations.Length; i++)
			{
				CreationSet creationSet = creations[i];
				this.Creations = this.Creations.Concat(creationSet.Creations).ToList<Creation>();
			}
		}
	}
}
