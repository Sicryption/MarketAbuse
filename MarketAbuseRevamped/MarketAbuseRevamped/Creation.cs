using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketAbuseRevamped
{
	public class Creation
	{
		public enum CreationFormType
		{
			Normal,
			HighAlch,
			LowAlch,
			GereralStore,
			KaramjaStore,
			Shop
		}

		public Skills.Skill Skill;

		public double Experience;

		public List<Item> Input;

		public List<Item> Output;

		private CreationFormType creationType;

		public Creation(List<Item> input, List<Item> output, CreationFormType type = CreationFormType.Normal)
		{
			Input = input;
			Output = output;
			creationType = type;
		}

		public Creation(List<Item> input, List<Item> output)
		{
			Input = input;
			Output = output;
		}

		public Creation(List<Item> input, List<Item> output, Skills.Skill skill, double experience)
		{
			Input = input;
			Output = output;
			Skill = skill;
			Experience = experience;
		}

		public override string ToString()
		{
			if (creationType > Creation.CreationFormType.Normal)
				return Input[0].name;
			else
			{
				string text = "";
				List<Item> output = Output;
				for (int i = 0; i < output.Count(); i += + 1)
				{
					text += output[i].name;
					if (i != output.Count() - 1)
						text += " + ";
				}
				return text;
			}
		}

		public double GPPEREXP()
		{
			int num = 0;
			foreach (Item current in Input)
			{
				num += current.BuyPrice * current.quantity;
			}
			return num / Experience;
		}

		public int margin()
		{
			int num = 0;
			foreach (Item current in Input)
			{
				num += current.BuyPrice * current.quantity;
			}
			int num2 = 0;
			foreach (Item current2 in Output)
			{
				num2 += current2.sellPrice * current2.quantity;
			}
			return num2 - num;
		}

		public int instaBuyMargin()
		{
			int num = 0;
			foreach (Item current in Input)
			{
				num += current.sellPrice * current.quantity;
			}
			int num2 = 0;
			foreach (Item current2 in Output)
			{
				num2 += current2.sellPrice * current2.quantity;
			}
			return num2 - num;
		}

		public int instaSellMargin()
		{
			int num = 0;
			foreach (Item current in Input)
			{
				num += current.BuyPrice * current.quantity;
			}
			int num2 = 0;
			foreach (Item current2 in Output)
			{
				num2 += current2.BuyPrice * current2.quantity;
			}
			return num2 - num;
		}

		public int instaTransactionMargin()
		{
			int num = 0;
			foreach (Item current in Input)
			{
				num += current.sellPrice * current.quantity;
			}
			int num2 = 0;
			foreach (Item current2 in Output)
			{
				num2 += current2.BuyPrice * current2.quantity;
			}
			return num2 - num;
		}

		public string GenerateID()
		{
			string text = "";
			foreach (Item current in Input)
			{
				text = string.Concat(new object[]
				{
					text,
					"Input[",
					current.id,
					"*",
					current.quantity,
					"]"
				});
			}
			foreach (Item current2 in Output)
			{
				text = string.Concat(new object[]
				{
					text,
					"Output[",
					current2.id,
					"*",
					current2.quantity,
					"]"
				});
			}
			return text;
		}
	}
}
