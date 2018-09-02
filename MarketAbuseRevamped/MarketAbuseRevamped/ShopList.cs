using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketAbuseRevamped
{
	internal class ShopList
	{
		public static List<Shop> Shops = new List<Shop>
		{
			ShopList.CS("Aaron's Archery Appendages", "Ranging Guild", "Armour salesman", "You need 40 Ranged to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Studded body", 850, 10),
				ShopList.CSI("Coif", 200, 10),
				ShopList.CSI("Hardleather body", 170, 10),
				ShopList.CSI("Leather cowl", 24, 10),
				ShopList.CSI("Leather body", 21, 10),
				ShopList.CSI("Leather vambraces", 18, 10),
				ShopList.CSI("Studded chaps", 750, 15),
				ShopList.CSI("Leather chaps", 20, 20)
			})),
			ShopList.CS("Aemad's Adventuring Supplies", "Ardougne", "Aemad/Korton", "Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Iron axe", 72, 2),
				ShopList.CSI("Cooked meat", 5, 2),
				ShopList.CSI("Tinderbox", 5, 2),
				ShopList.CSI("Bronze pickaxe", 1, 2),
				ShopList.CSI("Rope", 23, 20),
				ShopList.CSI("Ball of wool", 2, 30),
				ShopList.CSI("Papyrus", 13, 50),
				ShopList.CSI("Vial of water", 12, 500),
				ShopList.CSI("Bronze arrow", 1, 500)
			})),
			ShopList.CS("Agmundi Quality Clothes", "Keldagrim", "Agmundi", "You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI(5040, 975, 3),
				ShopList.CSI(5028, 910, 3),
				ShopList.CSI(5028, 845, 3),
				ShopList.CSI(5026, 812, 3),
				ShopList.CSI("Blue skirt", 812, 3),
				ShopList.CSI("Pink skirt", 812, 3),
				ShopList.CSI(5032, 780, 3),
				ShopList.CSI(5034, 715, 3),
				ShopList.CSI(5046, 507, 3),
				ShopList.CSI(5044, 468, 3)
			})),
			ShopList.CS("Ak-Haranu's Exotic Shop", "Port Phasmatys", "Ak-Haranu", "You must have completed the Ghosts Ahoy quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bolt rack", 50, 500)
			})),
			ShopList.CS("Al-Kharid General Store", "Al Kharid", "Shopkeeper", "Any item can be sold to this store and then be bought by another player.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Security book", 2, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Alain's Farming Patch", "Taverley", "Alain", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Aleck's Hunter Emporium", "Yanille", "Aleck", "In order to gain access to this shop, you must talk to Leon about the Hunter skill first!", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Teasing stick", 60, 5),
				ShopList.CSI("Butterfly net", 24, 5),
				ShopList.CSI("Rabbit snare", 18, 10),
				ShopList.CSI("Unlit torch", 4, 20),
				ShopList.CSI("Box trap", 38, 25),
				ShopList.CSI("Magic box", 720, 30),
				ShopList.CSI("Bird snare", 6, 50),
				ShopList.CSI("Noose wand", 4, 50),
				ShopList.CSI("Butterfly jar", 1, 100)
			})),
			ShopList.CS("Ali's Discount Basic Rune Shop", "Al Kharid", "Ali Morrisane", "Must have completed the runes part of Ali's merchant task.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Air rune", 4, 20),
				ShopList.CSI("Earth rune", 4, 20),
				ShopList.CSI("Fire rune", 4, 20),
				ShopList.CSI("Water rune", 4, 20)
			})),
			ShopList.CS("Ali's Discount Blackjack (o) Shop", "Al Kharid", "Ali Morrisane", "Must have completed the blackjack part of Ali's merchant task.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Maple blackjack(o)", 1600, 25),
				ShopList.CSI("Maple blackjack", 1200, 25),
				ShopList.CSI("Willow blackjack(o)", 800, 25),
				ShopList.CSI("Willow blackjack", 600, 25),
				ShopList.CSI("Oak blackjack(o)", 400, 25)
			})),
			ShopList.CS("Ali's Discount Blackjack (d) Shop", "Al Kharid", "Ali Morrisane", "Must have completed the blackjack part of Ali's merchant task.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Maple blackjack(d)", 1600, 25),
				ShopList.CSI("Maple blackjack", 1200, 25),
				ShopList.CSI("Willow blackjack(d)", 800, 25),
				ShopList.CSI("Willow blackjack", 600, 25),
				ShopList.CSI("Oak blackjack(d)", 400, 25)
			})),
			ShopList.CS("Ali's Discount Desert Clothing Shop", "Al Kharid", "Ali Morrisane", "Must have completed the clothing part of Ali's merchant task.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Desert top", 35, 25),
				ShopList.CSI("Desert legs", 25, 25),
				ShopList.CSI("Desert robes", 25, 25),
				ShopList.CSI("Fez", 20, 25),
				ShopList.CSI("Desert boots", 15, 25)
			})),
			ShopList.CS("Ali's Discount Menaphite Clothing Shop", "Al Kharid", "Ali Morrisane", "Must have completed the clothing part of Ali's merchant task.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Menaphite purple robe", 40, 25),
				ShopList.CSI("Menaphite red robe", 40, 25),
				ShopList.CSI("Menaphite purple hat", 35, 25),
				ShopList.CSI("Menaphite red hat", 35, 25),
				ShopList.CSI("Menaphite purple kilt", 20, 25),
				ShopList.CSI("Menaphite purple top", 20, 25),
				ShopList.CSI("Menaphite red kilt", 20, 25),
				ShopList.CSI("Menaphite red top", 20, 25)
			})),
			ShopList.CS("Ali's Discount Rune Shop", "Al Kharid", "Ali Morrisane", "Must have completed the clothing part of Ali's merchant task.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cosmic rune", 62, 10),
				ShopList.CSI("Blood rune", 500, 100),
				ShopList.CSI("Soul rune", 375, 100),
				ShopList.CSI("Law rune", 300, 100),
				ShopList.CSI("Death rune", 225, 100),
				ShopList.CSI("Nature rune", 225, 100),
				ShopList.CSI("Chaos rune", 94, 100),
				ShopList.CSI("Body rune", 3, 100),
				ShopList.CSI("Mind rune", 3, 100)
			})),
			ShopList.CS("Ali's Discount Wares", "Al Kharid", "Ali Morrisane", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Desert boots", 20, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Desert shirt", 40, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Knife", 6, 5),
				ShopList.CSI("Waterskin(4)", 27, 10),
				ShopList.CSI("Bronze pickaxe", 1, 11),
				ShopList.CSI("Fake beard", 1, 11),
				ShopList.CSI("Tinderbox", 1, 11),
				ShopList.CSI("Karidian disguise", 1, 12),
				ShopList.CSI("Raw chicken", 1, 15),
				ShopList.CSI("Bucket", 2, 19),
				ShopList.CSI("Papyrus", 10, 50)
			})),
			ShopList.CS("Ali's Water Cart", "Nardah", "Ali the Carter", "This shop is accessed through conversation only. This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Waterskin(4)", 1000, -1)
			})),
			ShopList.CS("Alice's Farming Shop", "Port Phasmatys, North West", "Alice", "You must have completed the Priest in Peril quest to access this this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Watermelon", 48, 0),
				ShopList.CSI("Strawberry", 17, 0),
				ShopList.CSI("Wildblood hops", 15, 0),
				ShopList.CSI("Krandorian hops", 10, 0),
				ShopList.CSI("Sweetcorn", 9, 0),
				ShopList.CSI("Yanillian hops", 7, 0),
				ShopList.CSI("Jute fibre", 6, 0),
				ShopList.CSI("Asgarnian hops", 5, 0),
				ShopList.CSI("Barley", 4, 0),
				ShopList.CSI("Hammerstone hops", 4, 0),
				ShopList.CSI("Tomato", 4, 0),
				ShopList.CSI("Onion", 3, 0),
				ShopList.CSI("Cabbage", 1, 0),
				ShopList.CSI("Potato", 1, 0),
				ShopList.CSI("Plant cure", 40, 100),
				ShopList.CSI("Compost", 20, 500),
				ShopList.CSI("Gardening trowel", 12, 500),
				ShopList.CSI("Watering can", 8, 500),
				ShopList.CSI("Rake", 6, 500),
				ShopList.CSI("Seed dibber", 6, 500),
				ShopList.CSI("Secateurs", 5, 500),
				ShopList.CSI("Spade", 3, 500),
				ShopList.CSI("Basket", 1, 500),
				ShopList.CSI("Empty sack", 1, 500),
				ShopList.CSI("Empty plant pot", 1, 500)
			})),
			ShopList.CS("Ardougne Baker's Stall", "Ardougne", "Baker", "You can steal items from this merchant's stall as well.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake", 50, 3),
				ShopList.CSI("Chocolate bar", 10, 7),
				ShopList.CSI("Bread", 12, 10)
			})),
			ShopList.CS("Ardougne Fur Stall", "Ardougne", "Fur trader", "You can steal items from this merchant's stall as well.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Kyatt fur", 192, 0),
				ShopList.CSI("Graahk fur", 144, 0),
				ShopList.CSI("Tatty kyatt fur", 144, 0),
				ShopList.CSI("Tatty graahk fur", 108, 0),
				ShopList.CSI("Larupia fur", 96, 0),
				ShopList.CSI("Tatty larupia fur", 72, 0),
				ShopList.CSI("Desert devil fur", 20, 0),
				ShopList.CSI("Feldip weasel fur", 16, 0),
				ShopList.CSI("Common kebbit fur", 14, 0),
				ShopList.CSI("Polar kebbit fur", 12, 0),
				ShopList.CSI("Grey wolf fur", 60, 3),
				ShopList.CSI("Bear Fur", 12, 3)
			})),
			ShopList.CS("Ardougne Gem Stall", "Ardougne", "Gem merchant", "You can steal items from this merchant's stall as well.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Diamond", 3000, 0),
				ShopList.CSI("Ruby", 1530, 0),
				ShopList.CSI("Emerald", 750, 0),
				ShopList.CSI("Sapphire", 390, 0)
			})),
			ShopList.CS("Ardougne Silver Stall", "Ardougne", "Silver merchant", "You can steal items from this merchant's stall as well.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Silver bar", 150, 1),
				ShopList.CSI("Silver ore", 75, 1),
				ShopList.CSI("Unstrung symbol", 200, 2)
			})),
			ShopList.CS("Ardougne Spice Stall", "Ardougne", "Spice seller", "You can steal items from this merchant's stall as well.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Spice", 230, 1),
				ShopList.CSI("Knife", 6, 1),
				ShopList.CSI("Garlic", 3, 2)
			})),
			ShopList.CS("Arhein Store", "Catherby", "Arhein", "Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rope", 23, 2),
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Knife", 7, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Bronze pickaxe", 1, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Pot", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Bucket", 2, 10)
			})),
			ShopList.CS("Armour Shop", "Jatizso", "Raum Urda-Stein", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril platebody", 5720, 4),
				ShopList.CSI("Mithril platelegs", 2860, 4),
				ShopList.CSI("Mithril plateskirt", 2860, 4),
				ShopList.CSI("Mithril kiteshield", 2431, 4),
				ShopList.CSI("Mithril chainbody", 2145, 4),
				ShopList.CSI("Mithril sq shield", 1716, 4),
				ShopList.CSI("Mithril full helm", 1573, 4),
				ShopList.CSI("Mithril med helm", 858, 4)
			})),
			ShopList.CS("Armour Store", "Keldagrim, Blast Furnace", "Jorzik", "You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune platebody", 65000, 0),
				ShopList.CSI("Rune platelegs", 64000, 0),
				ShopList.CSI("Rune plateskirt", 64000, 0),
				ShopList.CSI("Rune kiteshield", 54400, 0),
				ShopList.CSI("Rune chainbody", 50000, 0),
				ShopList.CSI("Rune sq shield", 38400, 0),
				ShopList.CSI("Rune full helm", 35200, 0),
				ShopList.CSI("Rune med helm", 19200, 0),
				ShopList.CSI("Adamant platebody", 12800, 0),
				ShopList.CSI("Adamant platelegs", 6400, 0),
				ShopList.CSI("Adamant plateskirt", 6400, 0),
				ShopList.CSI("Adamant kiteshield", 5440, 0),
				ShopList.CSI("Mithril platebody", 5200, 0),
				ShopList.CSI("Adamant chainbody", 4800, 0),
				ShopList.CSI("Adamant sq shield", 3840, 0),
				ShopList.CSI("Adamant full helm", 3520, 0),
				ShopList.CSI("Mithril platelegs", 2600, 0),
				ShopList.CSI("Mithril plateskirt", 2600, 0),
				ShopList.CSI("Mithril kiteshield", 2210, 0),
				ShopList.CSI("Mithril chainbody", 1950, 0),
				ShopList.CSI("Adamant med helm", 1920, 0),
				ShopList.CSI("Mithril sq shield", 1560, 0),
				ShopList.CSI("Mithril full helm", 1430, 0),
				ShopList.CSI("Mithril med helm", 780, 0)
			})),
			ShopList.CS("Armoury", "King Lathas Training Camp", "Shopkeeper", "You must have completed the Biohazard quest in order to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant 2h sword", 9600, 1),
				ShopList.CSI("Mithril 2h sword", 4200, 1),
				ShopList.CSI("Black 2h sword", 2880, 1),
				ShopList.CSI("Mithril battleaxe", 2535, 1),
				ShopList.CSI("Steel 2h sword", 1500, 2),
				ShopList.CSI("Iron battleaxe", 273, 2),
				ShopList.CSI("Longbow", 120, 2),
				ShopList.CSI("Crossbow", 105, 2),
				ShopList.CSI("Iron 2h sword", 420, 3),
				ShopList.CSI("Steel axe", 300, 3),
				ShopList.CSI("Bronze 2h sword", 120, 4),
				ShopList.CSI("Shortbow", 75, 4),
				ShopList.CSI("Iron axe", 84, 5),
				ShopList.CSI("Bronze bolts", 4, 200),
				ShopList.CSI("Bronze arrow", 1, 200),
				ShopList.CSI("Mithril arrowtips", 24, 800),
				ShopList.CSI("Steel arrowtips", 9, 800),
				ShopList.CSI("Iron arrowtips", 3, 800),
				ShopList.CSI("Bronze arrowtips", 1, 800)
			})),
			ShopList.CS("Arnold's Eclectic Supplies", "Piscatoris Fishing Colony", "Arnold", "You must complete the Swan Song quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Monkfish", 241, 0),
				ShopList.CSI("Raw monkfish", 241, 1),
				ShopList.CSI("Bread", 12, 1),
				ShopList.CSI("Bucket of milk", 6, 1),
				ShopList.CSI("Knife", 6, 1),
				ShopList.CSI("Harpoon", 5, 2),
				ShopList.CSI("Small fishing net", 5, 2),
				ShopList.CSI("Glassblowing pipe", 2, 2),
				ShopList.CSI("Needle", 1, 3),
				ShopList.CSI("Pot", 1, 4),
				ShopList.CSI("Beer", 2, 10),
				ShopList.CSI("Thread", 1, 15)
			})),
			ShopList.CS("Aubury's Rune Shop", "Varrock", "Aubury", "While talking to Aubury you may request to be teleported to the Rune Essence mine. When you reach level 99 in the Runecrafting skill, you may buy an Achievment cape from Aubury here for 99,000gp", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Death rune", 180, 250),
				ShopList.CSI("Chaos rune", 90, 250),
				ShopList.CSI("Air rune", 4, 5000),
				ShopList.CSI("Earth rune", 4, 5000),
				ShopList.CSI("Fire rune", 4, 5000),
				ShopList.CSI("Water rune", 4, 5000),
				ShopList.CSI("Body rune", 3, 5000),
				ShopList.CSI("Mind rune", 3, 5000)
			})),
			ShopList.CS("Aurel's Supplies", "Burgh de Rott", "Aurel", "You must have started the Myreque Quest Part 2 in order to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw mackerel", 17, 10),
				ShopList.CSI("Bronze axe", 16, 10),
				ShopList.CSI("Thin snail", 5, 10),
				ShopList.CSI("Tinderbox", 1, 10)
			})),
			ShopList.CS("Authentic Throwing Weapons", "Ranging Guild", "Tribal Weapon Saleasman", "You need 40 Ranged to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune thrownaxe", 572, 400),
				ShopList.CSI("Rune javelin", 520, 400),
				ShopList.CSI("Adamant thrownaxe", 228, 500),
				ShopList.CSI("Adamant javelin", 28, 500),
				ShopList.CSI("Mithril thrownaxe", 91, 600),
				ShopList.CSI("Mithril javelin", 83, 600),
				ShopList.CSI("Steel thrownaxe", 33, 700),
				ShopList.CSI("Steel javelin", 31, 700),
				ShopList.CSI("Iron thrownaxe", 9, 800),
				ShopList.CSI("Iron javelin", 7, 800),
				ShopList.CSI("Bronze javelin", 5, 900),
				ShopList.CSI("Bronze thrownaxe", 3, 900)
			})),
			ShopList.CS("Ava's Odds and Ends", "Draynor Manor", "Ava", "You must have completed the Animal Magnetism quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Steel arrow", 15, 10),
				ShopList.CSI("Steel arrowtips", 7, 20),
				ShopList.CSI("Iron arrowtips", 2, 30),
				ShopList.CSI("Iron arrow", 3, 40),
				ShopList.CSI("Feather", 2, 1000)
			})),
			ShopList.CS("Baba Yaga's Magic Shop", "Lunar Isle", "Baba Yaga", "To be able to use this store, you must have begun the Lunar Diplomacy quest. It is more expensive than other rune stores for the elemental runes, as well as the price raises more rapidly when buying in bulk.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Staff of air", 1500, 2),
				ShopList.CSI("Staff of earth", 1500, 2),
				ShopList.CSI("Staff of fire", 1500, 2),
				ShopList.CSI("Staff of water", 1500, 2),
				ShopList.CSI("Battlestaff", 7000, 5),
				ShopList.CSI("Blood rune", 300, 250),
				ShopList.CSI("Soul rune", 300, 250),
				ShopList.CSI("Law rune", 240, 250),
				ShopList.CSI("Death rune", 180, 250),
				ShopList.CSI("Nature rune", 180, 250),
				ShopList.CSI("Chaos rune", 90, 250),
				ShopList.CSI("Astral rune", 50, 250),
				ShopList.CSI("Air rune", 4, 5000),
				ShopList.CSI("Earth rune", 4, 5000),
				ShopList.CSI("Fire rune", 4, 5000),
				ShopList.CSI("Water rune", 4, 5000),
				ShopList.CSI("Body rune", 3, 5000),
				ShopList.CSI("Mind rune", 3, 5000)
			})),
			ShopList.CS("Bandit Bargains", "Desert Bandit Camp", "Bandit shopkeeper", "This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Waterskin(0)", 125, 5),
				ShopList.CSI("Desert robe", 40, 5),
				ShopList.CSI("Desert shirt", 40, 5),
				ShopList.CSI("Waterskin(4)", 30, 5),
				ShopList.CSI("Desert boots", 20, 5),
				ShopList.CSI("Bucket of water", 6, 5),
				ShopList.CSI("Knife", 6, 5),
				ShopList.CSI("Bowl", 4, 5),
				ShopList.CSI("Bowl of water", 4, 5),
				ShopList.CSI("Bucket", 2, 5),
				ShopList.CSI("Jug", 1, 5),
				ShopList.CSI("Jug of water", 1, 5)
			})),
			ShopList.CS("Bandit Duty Free", "Wilderness, Bandit Camp", "Noterazzo", "The Wilderness is dangerous and players can attack you. Be careful.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Bronze pickaxe", 1, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Bronze axe", 14, 10)
			})),
			ShopList.CS("Barkers' Haberdashery", "Canifis", "Barker", "You must have completed the Priest in Peril quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Grey boots", 650, 5),
				ShopList.CSI("Grey gloves", 650, 5),
				ShopList.CSI("Grey hat", 650, 5),
				ShopList.CSI("Grey robe bottoms", 650, 5),
				ShopList.CSI("Grey robe top", 650, 5),
				ShopList.CSI("Red boots", 650, 5),
				ShopList.CSI("Red gloves", 650, 5),
				ShopList.CSI("Red hat", 650, 5),
				ShopList.CSI("Red robe bottoms", 650, 5),
				ShopList.CSI("Red robe top", 650, 5),
				ShopList.CSI("Teal boots", 650, 5),
				ShopList.CSI("Teal gloves", 650, 5),
				ShopList.CSI("Teal hat", 650, 5),
				ShopList.CSI("Teal robe bottoms", 650, 5),
				ShopList.CSI("Teal robe top", 650, 5),
				ShopList.CSI("Yellow boots", 650, 5),
				ShopList.CSI("Yellow gloves", 650, 5),
				ShopList.CSI("Yellow hat", 650, 5),
				ShopList.CSI("Yellow robe bottoms", 650, 5),
				ShopList.CSI("Yellow robe top", 650, 5),
				ShopList.CSI("Blue cape", 41, 5),
				ShopList.CSI("Green cape", 41, 5),
				ShopList.CSI("Yellow cape", 41, 5),
				ShopList.CSI("Black cape", 9, 5),
				ShopList.CSI("Red cape", 2, 5)
			})),
			ShopList.CS("Battle Runes", "Wilderness, North of Edgeville", "Mage of Zamorak", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Blood rune", 400, 500),
				ShopList.CSI("Death rune", 180, 500),
				ShopList.CSI("Chaos rune", 90, 500),
				ShopList.CSI("Air rune", 4, 1000),
				ShopList.CSI("Earth rune", 4, 1000),
				ShopList.CSI("Fire rune", 4, 1000),
				ShopList.CSI("Water rune", 4, 1000),
				ShopList.CSI("Mind rune", 3, 1000)
			})),
			ShopList.CS("Bedabin Village Bartering", "Bedabin Camp", "Bedabin Nomad", "There are many Nomads to trade with, however they all have the same items. This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Desert robe", 40, 5),
				ShopList.CSI("Desert shirt", 40, 5),
				ShopList.CSI("Waterskin(4)", 30, 5),
				ShopList.CSI("Desert boots", 20, 5),
				ShopList.CSI("Waterskin(0)", 15, 5),
				ShopList.CSI("Bucket of water", 6, 5),
				ShopList.CSI("Knife", 6, 5),
				ShopList.CSI("Bowl", 4, 5),
				ShopList.CSI("Bowl of water", 4, 5),
				ShopList.CSI("Bucket", 2, 5),
				ShopList.CSI("Jug", 1, 5),
				ShopList.CSI("Jug of water", 1, 5)
			})),
			ShopList.CS("Betty's Magic Emporium", "Port Sarim", "Betty", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Blue wizard hat", 2, 1),
				ShopList.CSI("Wizard hat", 2, 1),
				ShopList.CSI("Death rune", 180, 250),
				ShopList.CSI("Chaos rune", 90, 250),
				ShopList.CSI("Eye of newt", 3, 300),
				ShopList.CSI("Air rune", 4, 5000),
				ShopList.CSI("Earth rune", 4, 5000),
				ShopList.CSI("Fire rune", 4, 5000),
				ShopList.CSI("Water rune", 4, 5000),
				ShopList.CSI("Body rune", 3, 5000),
				ShopList.CSI("Mind rune", 3, 5000)
			})),
			ShopList.CS("Blackjack Seller", "Pollnivneach", "Market Seller", "This shop is accessed through conversation only. You must have completed the Feud quest to access this shop. This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Willow blackjack", 600, -1)
			})),
			ShopList.CS("Blades by Urbi", "Sophanem", "Urbi", "You can only gain access to this shop upon completion of the Contact! quest.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Dragon dagger", 45000, 0),
				ShopList.CSI("Steel dagger", 187, 0),
				ShopList.CSI("Rune dagger", 12000, 1),
				ShopList.CSI("Adamant dagger", 1200, 1),
				ShopList.CSI("Steel scimitar", 600, 1),
				ShopList.CSI("Mithril dagger", 487, 1),
				ShopList.CSI("Iron scimitar", 168, 1),
				ShopList.CSI("Iron dagger", 52, 1),
				ShopList.CSI("Bronze scimitar", 48, 1),
				ShopList.CSI("Bronze dagger", 15, 1),
				ShopList.CSI("Pottery statuette", 14, 7),
				ShopList.CSI("Stone statuette", 26, 22),
				ShopList.CSI("Stone scarab", 22, 43)
			})),
			ShopList.CS("Blue Moon Inn", "Varrock", "Bartender", "This shop is accessed through conversation only.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("Blurberry Bar", "Grand Tree, 2nd Floor", "Barman", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Premade blurb' sp.", 30, 10),
				ShopList.CSI("Premade choc s'dy", 30, 10),
				ShopList.CSI("Premade dr' dragon", 30, 10),
				ShopList.CSI("Premade fr' blast", 30, 10),
				ShopList.CSI("Premade p' punch", 30, 10),
				ShopList.CSI("Premade sgg", 30, 10),
				ShopList.CSI("Premade wiz blz'd", 30, 10)
			})),
			ShopList.CS("Bob's Brilliant Axes", "Lumbridge", "Bob", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril battleaxe", 1690, 1),
				ShopList.CSI("Steel battleaxe", 650, 2),
				ShopList.CSI("Steel axe", 200, 3),
				ShopList.CSI("Iron battleaxe", 182, 5),
				ShopList.CSI("Iron axe", 56, 5),
				ShopList.CSI("Bronze pickaxe", 1, 5),
				ShopList.CSI("Bronze axe", 16, 10)
			})),
			ShopList.CS("Bolkoy's Village Shop", "Tree Gnome Village", "Bolkoy", "Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cooked meat", 5, 2),
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Bronze pickaxe", 1, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Bronze arrow", 1, 30)
			})),
			ShopList.CS("Bolongo's Farming Patch", "Gnome Stronghold", "Bolongo", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Brian's Archery Supplies", "Rimmington", "Brian", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Maple longbow", 640, 2),
				ShopList.CSI("Maple shortbow", 400, 2),
				ShopList.CSI("Willow longbow", 320, 3),
				ShopList.CSI("Willow shortbow", 200, 3),
				ShopList.CSI("Oak longbow", 160, 4),
				ShopList.CSI("Oak shortbow", 100, 4),
				ShopList.CSI("Adamant arrow", 80, 800),
				ShopList.CSI("Mithril arrow", 32, 1000),
				ShopList.CSI("Steel arrow", 12, 1500)
			})),
			ShopList.CS("Brian's Battleaxe Bazaar", "Port Sarim", "Brian", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant battleaxe", 4160, 1),
				ShopList.CSI("Mithril battleaxe", 1690, 1),
				ShopList.CSI("Black battleaxe", 1248, 1),
				ShopList.CSI("Steel battleaxe", 650, 2),
				ShopList.CSI("Iron battleaxe", 182, 3),
				ShopList.CSI("Bronze battleaxe", 52, 4)
			})),
			ShopList.CS("Brimhaven Agility Ticket Exchange", "", "", "", false, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Burthorpe Supplies", "Burthorpe", "Wistan", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Knife", 7, 2),
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Empty cup", 2, 20)
			})),
			ShopList.CS("Candle Shop", "Catherby", "Candle maker", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Candle", 3, 10)
			})),
			ShopList.CS("Carefree Crafting Stall", "Keldagrim", "Nolar", "You must have started the Giant Dwarf quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Necklace mould", 7, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Ring mould", 7, 4)
			})),
			ShopList.CS("Cassie's Shield Shop", "Falador", "Cassie", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril sq shield", 1560, 0),
				ShopList.CSI("Steel kiteshield", 850, 0),
				ShopList.CSI("Steel sq shield", 576, 0),
				ShopList.CSI("Iron kiteshield", 238, 0),
				ShopList.CSI("Iron sq shield", 168, 2),
				ShopList.CSI("Bronze kiteshield", 68, 3),
				ShopList.CSI("Bronze sq shield", 48, 3),
				ShopList.CSI("Wooden shield", 20, 5)
			})),
			ShopList.CS("Castle Wars Ticket Exchange", "", "", "", false, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Construction Supplies", "Varrock", "Sawmill operator", "The Sawmill operator can also turn your logs into planks.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bolt of cloth", 650, 1000),
				ShopList.CSI("Saw", 13, 1000),
				ShopList.CSI("Iron nails", 5, 1000),
				ShopList.CSI("Steel nails", 3, 1000),
				ShopList.CSI("Bronze nails", 2, 1000)
			})),
			ShopList.CS("Crossbow Shop", "Under White Wolf Mountain", "Holoy", "You must have completed the Fishing Contest quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune crossbow", 58320, 0),
				ShopList.CSI("Runite limbs", 57600, 0),
				ShopList.CSI("Adamant crossbow", 6361, 0),
				ShopList.CSI("Adamantite limbs", 5760, 0),
				ShopList.CSI("Mith crossbow", 2818, 0),
				ShopList.CSI("Steel crossbow", 1296, 0),
				ShopList.CSI("Yew stock", 601, 0),
				ShopList.CSI("Iron crossbow", 565, 0),
				ShopList.CSI("Mahogany stock", 478, 0),
				ShopList.CSI("Bronze crossbow", 262, 0),
				ShopList.CSI("Mithril limbs", 2340, 5),
				ShopList.CSI("Steel limbs", 900, 5),
				ShopList.CSI("Maple stock", 360, 5),
				ShopList.CSI("Teak stock", 277, 5),
				ShopList.CSI("Iron limbs", 252, 5),
				ShopList.CSI("Willow stock", 190, 5),
				ShopList.CSI("Oak stock", 97, 5),
				ShopList.CSI("Bronze limbs", 72, 5),
				ShopList.CSI("Wooden stock", 72, 5)
			})),
			ShopList.CS("Crystal Equipment", "Isafdar Woods", "Islwyn", "You must have completed the Roving Elves quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("New crystal bow", 900000, -1),
				ShopList.CSI("New crystal shield", 750000, -1)
			})),
			ShopList.CS("Culinaromancers' Cooking Chest", "Lumbridge, Castle Basement", "Crate (Buy Food)", "To gain access to this chest, you must have completed the Recipe for Disaster quest. Each sub-quest you do, opens up new items available from this chest.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Pizza base", 5, 1),
				ShopList.CSI("Pot of flour", 13, 10),
				ShopList.CSI("Pat of butter", 5, 10),
				ShopList.CSI("Grapes", 1, 10),
				ShopList.CSI("Spice", 300, 50),
				ShopList.CSI("Cake tin", 13, 50),
				ShopList.CSI("Chocolate bar", 13, 50),
				ShopList.CSI("Bucket of milk", 7, 50),
				ShopList.CSI("Bowl", 5, 50),
				ShopList.CSI("Cheese", 5, 50),
				ShopList.CSI("Egg", 5, 50),
				ShopList.CSI("Tomato", 5, 50),
				ShopList.CSI("Pie dish", 3, 50),
				ShopList.CSI("Bucket", 2, 50),
				ShopList.CSI("Empty cup", 2, 50),
				ShopList.CSI("Pot of cream", 2, 50),
				ShopList.CSI("Cooking apple", 1, 50),
				ShopList.CSI("Jug", 1, 50),
				ShopList.CSI("Pot", 1, 50)
			})),
			ShopList.CS("Culinaromancers' Item Chest", "Lumbridge, Castle Basement", "Crate (Buy Items)", "To gain access to this chest, you must have completed the first part of the Recipe for Disaster quest. Each sub-quest you do, opens up new items available from this chest.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Meat tenderiser", 53950, 5),
				ShopList.CSI("Cleaver", 33280, 5),
				ShopList.CSI("Rolling pin", 18720, 5),
				ShopList.CSI("Kitchen knife", 10400, 5),
				ShopList.CSI("Skewer", 4160, 5),
				ShopList.CSI("Spatula", 2496, 5),
				ShopList.CSI("Frying pan", 2158, 5),
				ShopList.CSI("Spork", 422, 5),
				ShopList.CSI("Egg whisk", 65, 5),
				ShopList.CSI("Wooden spoon", 45, 5)
			})),
			ShopList.CS("Daga's Scimitar Smithy", "Marim", "Daga", "You must have started the Monkey Madness quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Dragon scimitar", 100000, 4),
				ShopList.CSI("Mithril scimitar", 1040, 6),
				ShopList.CSI("Steel scimitar", 400, 8),
				ShopList.CSI("Iron scimitar", 112, 10),
				ShopList.CSI("Bronze scimitar", 32, 10)
			})),
			ShopList.CS("Dancing Donkey Inn", "Varrock", "Bartender", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("Dantaera's Farming Patch", "Catherby", "Dantaera", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Dargaud's Bow and Arrows", "Ranging Guild", "Bow and Arrow salesman", "You need 40 Ranged to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune brutal", 450, 0),
				ShopList.CSI("Comp ogre bow", 180, 0),
				ShopList.CSI("Adamant brutal", 95, 0),
				ShopList.CSI("Mithril brutal", 50, 0),
				ShopList.CSI("Black brutal", 35, 0),
				ShopList.CSI("Steel brutal", 20, 0),
				ShopList.CSI("Iron brutal", 10, 0),
				ShopList.CSI("Bronze brutal", 5, 0),
				ShopList.CSI("Willow longbow", 320, 20),
				ShopList.CSI("Willow shortbow", 200, 20),
				ShopList.CSI("Oak longbow", 160, 20),
				ShopList.CSI("Oak shortbow", 100, 20),
				ShopList.CSI("Longbow", 80, 20),
				ShopList.CSI("Shortbow", 50, 20),
				ShopList.CSI("Rune arrowtips", 200, 150),
				ShopList.CSI("Adamant arrowtips", 50, 200),
				ShopList.CSI("Mithril arrowtips", 16, 200),
				ShopList.CSI("Steel arrowtips", 6, 300),
				ShopList.CSI("Rune arrow", 400, 400),
				ShopList.CSI("Iron arrowtips", 2, 400),
				ShopList.CSI("Adamant arrow", 80, 450),
				ShopList.CSI("Mithril arrow", 45, 500),
				ShopList.CSI("Steel arrow", 12, 500),
				ShopList.CSI("Iron arrow", 3, 500),
				ShopList.CSI("Bronze arrowtips", 1, 500),
				ShopList.CSI("Arrow shaft", 4, 1000),
				ShopList.CSI("Bronze arrow", 1, 1000)
			})),
			ShopList.CS("Darren's Wilderness Cape Shop", "Wilderness, Near Agilty Area", "Darren", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-14 cape", 50, 100),
				ShopList.CSI("Team-24 cape", 50, 100),
				ShopList.CSI("Team-34 cape", 50, 100),
				ShopList.CSI("Team-4 cape", 50, 100),
				ShopList.CSI("Team-44 cape", 50, 100)
			})),
			ShopList.CS("Davon's Amulet Store", "Brimhaven", "Davon", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Amulet of power", 4230, 0),
				ShopList.CSI("Amulet of strength", 2430, 0),
				ShopList.CSI("Amulet of defence", 1530, 0),
				ShopList.CSI("Amulet of magic", 1080, 0),
				ShopList.CSI("Holy symbol", 360, 0)
			})),
			ShopList.CS("Dead Man's Chest", "Brimhaven", "Bartender", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Grog", 3, -1),
				ShopList.CSI("Beer", 1, -1)
			})),
			ShopList.CS("Diango's Toy Store", "Draynor Village", "Diango", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Black toy horsey", 150, 5),
				ShopList.CSI("Brown toy horsey", 150, 5),
				ShopList.CSI("Grey toy horsey", 150, 5),
				ShopList.CSI("White toy horsey", 150, 5)
			})),
			ShopList.CS("Dodgy Mike's Second Hand Clothing", "Mos Le'Harmless", "Dodgy Mike", "You must have the Little book o' Piracy from the Cabin Fever quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI(7132, 350, 10),
				ShopList.CSI(7116, 350, 10),
				ShopList.CSI(7126, 350, 10),
				ShopList.CSI(7138, 350, 10),
				ShopList.CSI(7128, 300, 10),
				ShopList.CSI(7122, 300, 10),
				ShopList.CSI(7110, 300, 10),
				ShopList.CSI(7134, 300, 10),
				ShopList.CSI("Pirate boots", 350, 15),
				ShopList.CSI(7130, 102, 20),
				ShopList.CSI(7136, 102, 20),
				ShopList.CSI(7124, 102, 20),
				ShopList.CSI(7112, 102, 20)
			})),
			ShopList.CS("Dommiks Crafting Store", "Al Kharid", "Dommik", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Amulet mould", 5, 2),
				ShopList.CSI("Necklace mould", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Holy mould", 5, 3),
				ShopList.CSI("Needle", 1, 3),
				ShopList.CSI("Ring mould", 5, 4),
				ShopList.CSI("Bracelet mould", 5, 5),
				ShopList.CSI("Sickle mould", 10, 6),
				ShopList.CSI("Tiara mould", 100, 10),
				ShopList.CSI("Bolt mould", 25, 10),
				ShopList.CSI("Thread", 1, 100)
			})),
			ShopList.CS("Dorgesh-Kaan General Supplies", "Dorgesh-Kaan", "Lurgon", "You must have completed Death to the Dorgeshuun to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Glassblowing pipe", 2, 1),
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Rope", 23, 3),
				ShopList.CSI("Unlit torch", 5, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Draynor Seed Market", "Draynor Village", "Olivia", "You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Watermelon seed", 67, 0),
				ShopList.CSI("Strawberry seed", 21, 0),
				ShopList.CSI("Wildblood seed", 16, 0),
				ShopList.CSI("Krandorian seed", 9, 0),
				ShopList.CSI("Sweetcorn seed", 9, 0),
				ShopList.CSI("Tomato seed", 4, 0),
				ShopList.CSI("Yanillian seed", 7, 5),
				ShopList.CSI("Jute seed", 6, 5),
				ShopList.CSI("Cabbage seed", 3, 5),
				ShopList.CSI("Asgarnian seed", 3, 10),
				ShopList.CSI("Onion seed", 3, 10),
				ShopList.CSI("Rosemary seed", 4, 20),
				ShopList.CSI("Barley seed", 2, 20),
				ShopList.CSI("Hammerstone seed", 2, 20),
				ShopList.CSI("Marigold seed", 2, 20),
				ShopList.CSI("Potato seed", 2, 20)
			})),
			ShopList.CS("Dreven's Farming Patch", "Champion's Guild", "Dreven", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Drogo's Mining Emporium", "Dwarven Mines", "Drogo Dwarf", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Gold bar", 300, 0),
				ShopList.CSI("Coal", 45, 0),
				ShopList.CSI("Iron bar", 28, 0),
				ShopList.CSI("Iron ore", 17, 0),
				ShopList.CSI("Bronze bar", 8, 0),
				ShopList.CSI("Copper ore", 3, 0),
				ShopList.CSI("Tin ore", 3, 0),
				ShopList.CSI("Bronze pickaxe", 1, 4),
				ShopList.CSI("Hammer", 1, 4)
			})),
			ShopList.CS("Dwarven Shopping Store", "Dwarven Mines", "Dwarf", "Any item can be sold to this store and then be bought by another player.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Hammer", 1, 5)
			})),
			ShopList.CS("Edgeville General Store", "Edgeville", "Shopkeeper", "Any item can be sold to this store and then be bought by another player.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Security book", 2, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Edmond's Wilderness Cape Shop", "Wilderness - slightly east of hobgoblin mine", "Edmond", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-18 cape", 50, 100),
				ShopList.CSI("Team-28 cape", 50, 100),
				ShopList.CSI("Team-38 cape", 50, 100),
				ShopList.CSI("Team-48 cape", 50, 100),
				ShopList.CSI("Team-8 cape", 50, 100)
			})),
			ShopList.CS("Edward's Wilderness Cape Shop", "Wilderness, Rogue's Castle", "Edward", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-15 cape", 50, 100),
				ShopList.CSI("Team-25 cape", 50, 100),
				ShopList.CSI("Team-35 cape", 50, 100),
				ShopList.CSI("Team-45 cape", 50, 100),
				ShopList.CSI("Team-5 cape", 50, 100)
			})),
			ShopList.CS("Ellena's Farming Patch", "Catherby, East", "Ellena", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Elstan's Farming Patch", "Falador, South East", "Elstan", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Etceteria Fish", "Etceteria", "Fishmonger", "You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw shark", 390, 0),
				ShopList.CSI("Raw swordfish", 260, 0),
				ShopList.CSI("Raw lobster", 195, 0),
				ShopList.CSI("Raw bass", 156, 0),
				ShopList.CSI("Raw tuna", 112, 0),
				ShopList.CSI("Raw salmon", 65, 0),
				ShopList.CSI("Raw cod", 32, 0),
				ShopList.CSI("Raw pike", 32, 0),
				ShopList.CSI("Raw trout", 26, 0),
				ShopList.CSI("Raw mackerel", 22, 0),
				ShopList.CSI("Raw anchovies", 19, 0),
				ShopList.CSI("Raw herring", 19, 0),
				ShopList.CSI("Raw shrimps", 6, 0),
				ShopList.CSI("Lobster pot", 26, 2),
				ShopList.CSI("Harpoon", 6, 2),
				ShopList.CSI("Big fishing net", 26, 5),
				ShopList.CSI("Fishing rod", 6, 5),
				ShopList.CSI("Small fishing net", 6, 5),
				ShopList.CSI("Raw sardine", 13, 200),
				ShopList.CSI("Feather", 2, 1000),
				ShopList.CSI("Fishing bait", 3, 1200)
			})),
			ShopList.CS("Falador General Store", "Falador", "Shopkeeper", "Any item can be sold to this store and then be bought by another player.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Security book", 2, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Fancy Clothes Store", "Varrock", "Fancy dress shop owner", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Chef's hat", 2, 0),
				ShopList.CSI("Red cape", 41, 1),
				ShopList.CSI("Brown apron", 2, 1),
				ShopList.CSI("Blue skirt", 2, 2),
				ShopList.CSI("Grey wolf fur", 65, 3),
				ShopList.CSI("Fur", 13, 3),
				ShopList.CSI(428, 6, 3),
				ShopList.CSI(426, 6, 3),
				ShopList.CSI("Black skirt", 2, 3),
				ShopList.CSI("Right eye patch", 2, 3),
				ShopList.CSI("Wizard hat", 2, 3),
				ShopList.CSI("Needle", 1, 3),
				ShopList.CSI("Red cape", 2, 4),
				ShopList.CSI("Pink skirt", 2, 5),
				ShopList.CSI("Leather boots", 7, 10),
				ShopList.CSI("Leather gloves", 7, 10),
				ShopList.CSI("Thread", 1, 100)
			})),
			ShopList.CS("Fayeth's Farming Patch", "Lumbridge", "Fayeth", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Compost", 35, -1),
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Fernahei's Fishing Hut", "Shilo Village", "Fernahei", "You must have completed the Shilo Village quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw salmon", 50, 0),
				ShopList.CSI("Raw pike", 25, 0),
				ShopList.CSI("Raw trout", 20, 0),
				ShopList.CSI("Fishing rod", 5, 5),
				ShopList.CSI("Fly fishing rod", 5, 5),
				ShopList.CSI("Fishing bait", 3, 200),
				ShopList.CSI("Feather", 2, 800)
			})),
			ShopList.CS("Fine Fashions", "Grand Tree, 2nd Floor", "Rometti", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Blue boots", 200, 5),
				ShopList.CSI("Green boots", 200, 5),
				ShopList.CSI("Purple boots", 200, 5),
				ShopList.CSI("Red boots", 200, 5),
				ShopList.CSI("Yellow boots", 200, 5),
				ShopList.CSI("Blue robe bottoms", 180, 5),
				ShopList.CSI("Blue robe top", 180, 5),
				ShopList.CSI("Green robe bottoms", 180, 5),
				ShopList.CSI("Green robe top", 180, 5),
				ShopList.CSI("Purple robe bottoms", 180, 5),
				ShopList.CSI("Purple robe top", 180, 5),
				ShopList.CSI("Red robe bottoms", 180, 5),
				ShopList.CSI("Red robe top", 180, 5),
				ShopList.CSI("Yellow robe bottoms", 180, 5),
				ShopList.CSI("Yellow robe top", 180, 5),
				ShopList.CSI("Blue hat", 160, 5),
				ShopList.CSI("Green hat", 160, 5),
				ShopList.CSI("Purple hat", 160, 5),
				ShopList.CSI("Red hat", 160, 5),
				ShopList.CSI("Yellow hat", 160, 5)
			})),
			ShopList.CS("Fishing Guild Shop", "Fishing Guild", "Roachey", "You must have 67 Fishing to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw swordfish", 200, 0),
				ShopList.CSI("Swordfish", 200, 0),
				ShopList.CSI("Lobster", 150, 0),
				ShopList.CSI("Raw lobster", 150, 0),
				ShopList.CSI("Bass", 120, 0),
				ShopList.CSI("Raw bass", 120, 0),
				ShopList.CSI("Raw tuna", 100, 0),
				ShopList.CSI("Tuna", 100, 0),
				ShopList.CSI("Cod", 25, 0),
				ShopList.CSI("Raw cod", 25, 0),
				ShopList.CSI("Mackerel", 17, 0),
				ShopList.CSI("Raw mackerel", 17, 0),
				ShopList.CSI("Feather", 2, 1500),
				ShopList.CSI("Fishing bait", 3, 2000)
			})),
			ShopList.CS("Flossi Dalksson's Store", "Jatizso", "Flossi Dalksson", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw shark", 330, 0),
				ShopList.CSI("Raw lobster", 165, 5),
				ShopList.CSI("Raw tuna", 110, 20),
				ShopList.CSI("Raw salmon", 55, 20),
				ShopList.CSI("Raw cod", 27, 20)
			})),
			ShopList.CS("Flying Horse Inn", "Ardougne", "Bartender", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("Flynn's Mace Market", "Falador", "Flynn", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant mace", 1440, 2),
				ShopList.CSI("Mithril mace", 585, 3),
				ShopList.CSI("Steel mace", 225, 4),
				ShopList.CSI("Iron mace", 63, 4),
				ShopList.CSI("Bronze mace", 18, 5)
			})),
			ShopList.CS("Food Store", "Port Sarim", "Wydin", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bread", 12, 0),
				ShopList.CSI("Chocolate bar", 10, 1),
				ShopList.CSI("Redberries", 3, 1),
				ShopList.CSI("Potato", 1, 1),
				ShopList.CSI("Raw beef", 1, 1),
				ShopList.CSI("Raw chicken", 1, 1),
				ShopList.CSI("Pot of flour", 10, 3),
				ShopList.CSI("Cheese", 4, 3),
				ShopList.CSI("Tomato", 4, 3),
				ShopList.CSI("Banana", 2, 3),
				ShopList.CSI("Cabbage", 1, 3)
			})),
			ShopList.CS("Francis's Farming Patch", "Entrana", "Francis", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Fremennik Fish Monger", "Rellekka", "Fish monger", "You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw shark", 390, 0),
				ShopList.CSI("Raw swordfish", 260, 0),
				ShopList.CSI("Raw bass", 156, 0),
				ShopList.CSI("Raw lobster", 45, 0),
				ShopList.CSI("Raw cod", 32, 0),
				ShopList.CSI("Raw pike", 32, 0),
				ShopList.CSI("Raw trout", 26, 0),
				ShopList.CSI("Raw mackerel", 22, 0),
				ShopList.CSI("Raw anchovies", 19, 0),
				ShopList.CSI("Raw herring", 19, 0),
				ShopList.CSI("Raw shrimps", 6, 0),
				ShopList.CSI("Raw salmon", 65, 2),
				ShopList.CSI("Lobster pot", 26, 2),
				ShopList.CSI("Harpoon", 6, 2),
				ShopList.CSI("Big fishing net", 26, 5),
				ShopList.CSI("Fishing rod", 6, 5),
				ShopList.CSI("Fly fishing rod", 6, 5),
				ShopList.CSI("Small fishing net", 6, 5),
				ShopList.CSI("Raw tuna", 130, 8),
				ShopList.CSI("Raw sardine", 13, 200),
				ShopList.CSI("Feather", 2, 1000),
				ShopList.CSI("Fishing bait", 3, 1500)
			})),
			ShopList.CS("Fremennik Fur Trader", "Rellekka", "Fur trader", "You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Kyatt fur", 196, 0),
				ShopList.CSI("Graahk fur", 144, 0),
				ShopList.CSI("Tatty kyatt fur", 144, 0),
				ShopList.CSI("Tatty graahk fur", 108, 0),
				ShopList.CSI("Larupia fur", 96, 0),
				ShopList.CSI("Tatty larupia fur", 72, 0),
				ShopList.CSI("Desert devil fur", 20, 0),
				ShopList.CSI("Feldip weasel fur", 16, 0),
				ShopList.CSI("Common kebbit fur", 14, 0),
				ShopList.CSI("Polar kebbit fur", 12, 0),
				ShopList.CSI("Grey wolf fur", 60, 3),
				ShopList.CSI("Fur", 12, 3)
			})),
			ShopList.CS("Frenita's Cookery Shop", "Yanille", "Frenita", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug", 1, 1),
				ShopList.CSI("Cake tin", 10, 2),
				ShopList.CSI("Chocolate bar", 10, 2),
				ShopList.CSI("Bowl", 4, 2),
				ShopList.CSI("Cooking apple", 1, 2),
				ShopList.CSI("Tinderbox", 1, 4),
				ShopList.CSI("Pie dish", 3, 5),
				ShopList.CSI("Potato", 1, 5),
				ShopList.CSI("Pot of flour", 10, 8),
				ShopList.CSI("Pot", 1, 8),
				ShopList.CSI("Empty cup", 2, 20)
			})),
			ShopList.CS("Frincos Fabulous Herb Store", "Entrana", "Frincos", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Pestle and mortar", 4, 3),
				ShopList.CSI("Eye of newt", 3, 50),
				ShopList.CSI("Vial", 2, 50)
			})),
			ShopList.CS("Funch's Fine Groceries", "Grand Tree, 2nd Floor", "Heckel Funch", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket of milk", 6, 5),
				ShopList.CSI("Knife", 6, 5),
				ShopList.CSI("Dwellberries", 4, 5),
				ShopList.CSI("Cocktail guide", 2, 5),
				ShopList.CSI("Pot of cream", 2, 5),
				ShopList.CSI("Brandy", 5, 10),
				ShopList.CSI("Gin", 5, 10),
				ShopList.CSI("Vodka", 5, 10),
				ShopList.CSI("Whisky", 5, 10),
				ShopList.CSI("Chocolate dust", 2, 10),
				ShopList.CSI("Cocktail shaker", 2, 10),
				ShopList.CSI("Pineapple", 1, 10),
				ShopList.CSI("Chocolate bar", 10, 20),
				ShopList.CSI("Equa leaves", 2, 20),
				ShopList.CSI("Lemon", 2, 20),
				ShopList.CSI("Lime", 2, 20),
				ShopList.CSI("Orange", 2, 20),
				ShopList.CSI("Cocktail Glass", 1, 20)
			})),
			ShopList.CS("Gaius' Two Handed Shop", "Taverley", "Gauis", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant 2h sword", 6400, 0),
				ShopList.CSI("Mithril 2h sword", 2600, 1),
				ShopList.CSI("Black 2h sword", 1920, 1),
				ShopList.CSI("Steel 2h sword", 1000, 2),
				ShopList.CSI("Iron 2h sword", 280, 3),
				ShopList.CSI("Bronze 2h sword", 80, 4)
			})),
			ShopList.CS("Garden Centre", "Falador", "Garden Supplier", "This shop supplies and sells plants used for gardens in your Player Owned House.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Tall box hedge", 100000, 20),
				ShopList.CSI("Bagged magic tree", 50000, 20),
				ShopList.CSI("Tall fancy hedge", 50000, 20),
				ShopList.CSI("Fancy hedge", 25000, 20),
				ShopList.CSI("Bagged yew tree", 20000, 20),
				ShopList.CSI("Topiary hedge", 20000, 20),
				ShopList.CSI("Bagged bluebells", 15000, 20),
				ShopList.CSI("Bagged maple tree", 15000, 20),
				ShopList.CSI("Bagged roses", 15000, 20),
				ShopList.CSI("Small box hedge", 15000, 20),
				ShopList.CSI("Bagged daffodils", 10000, 20),
				ShopList.CSI("Bagged marigolds", 10000, 20),
				ShopList.CSI("Bagged plant 3", 10000, 20),
				ShopList.CSI("Bagged willow tree", 10000, 20),
				ShopList.CSI("Nice hedge", 10000, 20),
				ShopList.CSI("Bagged flower", 5000, 20),
				ShopList.CSI("Bagged oak tree", 5000, 20),
				ShopList.CSI("Bagged plant 2", 5000, 20),
				ShopList.CSI("Bagged sunflower", 5000, 20),
				ShopList.CSI("Thorny hedge", 5000, 20),
				ShopList.CSI("Bagged nice tree", 2000, 20),
				ShopList.CSI("Bagged dead tree", 1000, 20),
				ShopList.CSI("Bagged plant 1", 1000, 20)
			})),
			ShopList.CS("Garth's Farming Patch", "Brimhaven, West", "Garth", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Gem Trader", "Al Kharid", "Gem trader", "This store carries no stock unless a player has sold gems to the store.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Diamond", 2000, 0),
				ShopList.CSI("Ruby", 1000, 0),
				ShopList.CSI("Emerald", 515, 0),
				ShopList.CSI("Sapphire", 257, 0),
				ShopList.CSI("Uncut diamond", 200, 0),
				ShopList.CSI("Uncut ruby", 100, 0),
				ShopList.CSI("Uncut emerald", 51, 0),
				ShopList.CSI("Uncut sapphire", 25, 0)
			})),
			ShopList.CS("General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Knife", 12, 2),
				ShopList.CSI("Bucket", 4, 2),
				ShopList.CSI("Chisel", 2, 2),
				ShopList.CSI("Jug", 2, 2),
				ShopList.CSI("Needle", 2, 2),
				ShopList.CSI("Tinderbox", 2, 2),
				ShopList.CSI("Hammer", 2, 5),
				ShopList.CSI("Thread", 2, 50)
			})),
			ShopList.CS("Gerrant's Fishy Business", "Port Sarim", "Gerrant", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw swordfish", 200, 0),
				ShopList.CSI("Raw lobster", 150, 0),
				ShopList.CSI("Raw tuna", 100, 0),
				ShopList.CSI("Raw salmon", 50, 0),
				ShopList.CSI("Raw pike", 25, 0),
				ShopList.CSI("Raw trout", 20, 0),
				ShopList.CSI("Raw anchovies", 15, 0),
				ShopList.CSI("Raw herring", 15, 0),
				ShopList.CSI("Raw shrimps", 5, 0),
				ShopList.CSI("Lobster pot", 20, 2),
				ShopList.CSI("Harpoon", 5, 2),
				ShopList.CSI("Fishing rod", 5, 5),
				ShopList.CSI("Fly fishing rod", 5, 5),
				ShopList.CSI("Small fishing net", 5, 5),
				ShopList.CSI("Raw sardine", 10, 200),
				ShopList.CSI("Feather", 2, 1000),
				ShopList.CSI("Fishing bait", 3, 1500)
			})),
			ShopList.CS("Gertrude's Cats", "Varrock", "Gertrude", "This shop is accessed through conversation only. You must have completed the Gertrude's Cat quest to use this shop.", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Gianne's Restaurant", "Grand Tree, 2nd Floor", "Gnome Waiter", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Chocolate bomb", 165, 3),
				ShopList.CSI("Tangled toad's legs", 160, 3),
				ShopList.CSI("Veg ball", 150, 3),
				ShopList.CSI("Worm hole", 150, 3),
				ShopList.CSI("Cheese+tom batta", 120, 3),
				ShopList.CSI("Fruit batta", 120, 3),
				ShopList.CSI("Toad batta", 120, 3),
				ShopList.CSI("Vegetable batta", 120, 3),
				ShopList.CSI("Worm batta", 120, 3),
				ShopList.CSI("Chocchip crunchies", 85, 3),
				ShopList.CSI("Spicy crunchies", 85, 3),
				ShopList.CSI("Toad crunchies", 85, 3),
				ShopList.CSI("Worm crunchies", 85, 3)
			})),
			ShopList.CS("Gileth's Farming Patch", "Tree Gnome Maze, West", "Gileth", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Grand Tree Groceries", "Grand Tree, 2nd Floor", "Hudo", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Spider on stick", 50, 0),
				ShopList.CSI("Spider on shaft", 40, 0),
				ShopList.CSI("Dwellberries", 4, 3),
				ShopList.CSI("Cabbage", 1, 3),
				ShopList.CSI("Potato", 1, 3),
				ShopList.CSI("Batta tin", 10, 5),
				ShopList.CSI("Crunchy tray", 10, 5),
				ShopList.CSI("Gnomebowl mould", 10, 5),
				ShopList.CSI("Pot of flour", 10, 5),
				ShopList.CSI("Bucket of milk", 6, 5),
				ShopList.CSI("Knife", 6, 5),
				ShopList.CSI("Cheese", 4, 5),
				ShopList.CSI("Onion", 3, 5),
				ShopList.CSI("Cocktail shaker", 2, 5),
				ShopList.CSI("Equa leaves", 2, 5),
				ShopList.CSI("Gianne's cook book", 2, 5),
				ShopList.CSI("Gnome spice", 2, 5),
				ShopList.CSI("Pot of cream", 2, 5),
				ShopList.CSI("Gianne dough", 2, 8),
				ShopList.CSI("Tomato", 4, 10),
				ShopList.CSI("Chocolate dust", 2, 10),
				ShopList.CSI("Lemon", 2, 10),
				ShopList.CSI("Lime", 2, 10),
				ShopList.CSI("Orange", 2, 10),
				ShopList.CSI("Pineapple", 1, 10),
				ShopList.CSI("Chocolate bar", 10, 20)
			})),
			ShopList.CS("Green Gemstone Gems", "Keldagrim", "Hervi", "You must have started the Giant Dwarf quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Diamond", 3000, 0),
				ShopList.CSI("Ruby", 1530, 1),
				ShopList.CSI("Emerald", 765, 1),
				ShopList.CSI("Sapphire", 397, 3)
			})),
			ShopList.CS("Grum's Gold Exchange", "Port Sarim", "Grum", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Diamond necklace", 3675, 0),
				ShopList.CSI("Diamond amulet", 3525, 0),
				ShopList.CSI("Diamond ring", 3525, 0),
				ShopList.CSI("Ruby necklace", 2175, 0),
				ShopList.CSI("Ruby amulet", 2025, 0),
				ShopList.CSI("Ruby ring", 2025, 0),
				ShopList.CSI("Emerald necklace", 1425, 0),
				ShopList.CSI("Emerald amulet", 1275, 0),
				ShopList.CSI("Emerald ring", 1275, 0),
				ShopList.CSI("Sapphire necklace", 1050, 0),
				ShopList.CSI("Sapphire amulet", 900, 0),
				ShopList.CSI("Sapphire ring", 900, 0),
				ShopList.CSI("Gold necklace", 450, 0),
				ShopList.CSI("Gold amulet", 350, 0),
				ShopList.CSI("Gold ring", 350, 0)
			})),
			ShopList.CS("Gulluck and Sons", "Grand Tree, 3rd Floor", "Gulluck", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant 2h sword", 6400, 1),
				ShopList.CSI("Mithril 2h sword", 2600, 1),
				ShopList.CSI("Black 2h sword", 1920, 1),
				ShopList.CSI("Mithril battleaxe", 1690, 1),
				ShopList.CSI("Pearl bolts", 13, 1),
				ShopList.CSI("Steel 2h sword", 1000, 2),
				ShopList.CSI("Steel battleaxe", 650, 2),
				ShopList.CSI("Longbow", 80, 2),
				ShopList.CSI("Crossbow", 70, 2),
				ShopList.CSI("Iron 2h sword", 280, 3),
				ShopList.CSI("Steel axe", 200, 3),
				ShopList.CSI("Bronze 2h sword", 80, 4),
				ShopList.CSI("Shortbow", 50, 4),
				ShopList.CSI("Iron battleaxe", 182, 5),
				ShopList.CSI("Iron axe", 56, 5),
				ShopList.CSI("Mithril arrowtips", 16, 140),
				ShopList.CSI("Bronze bolts", 3, 150),
				ShopList.CSI("Steel arrowtips", 6, 160),
				ShopList.CSI("Iron arrowtips", 2, 180),
				ShopList.CSI("Bronze arrow", 1, 200),
				ShopList.CSI("Bronze arrowtips", 1, 200)
			})),
			ShopList.CS("Gunslik's Assorted Items", "Keldagrim", "Gunslik", "You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Hammer", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pestle and mortar", 5, 3),
				ShopList.CSI("Rope", 23, 10),
				ShopList.CSI("Leather gloves", 7, 10),
				ShopList.CSI("Unlit torch", 5, 10),
				ShopList.CSI("Candle", 3, 10),
				ShopList.CSI("Vial", 2, 10),
				ShopList.CSI("Charcoal", 58, 50)
			})),
			ShopList.CS("Hair of the Dog Tavern", "Canifis", "Roavar", "This shop is accessed through conversation only. You must have completed the Priest in Peril quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Moonlight mead", 5, -1)
			})),
			ShopList.CS("Hamab's Crafting Emporium", "Marim", "Hamab", "You must have started the Monkey Madness quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Necklace mould", 5, 2),
				ShopList.CSI("Ring mould", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Needle", 1, 3),
				ShopList.CSI("Ball of wool", 2, 100),
				ShopList.CSI("Thread", 1, 100)
			})),
			ShopList.CS("Happy Heroes' H'emporium", "Heroes' Guild", "Helemos", "You need to complete the Heroes Quest to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Dragon battleaxe", 200000, 1),
				ShopList.CSI("Dragon mace", 50000, 1)
			})),
			ShopList.CS("Harpoon Joe's House of 'Rum'", "Mos Le'Harmless", "Harpoon Joe", "You must have the Little book o' Piracy from the Cabin Fever quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug of wine", 1, 1),
				ShopList.CSI("Beer", 2, 3),
				ShopList.CSI("Stew", 20, 5)
			})),
			ShopList.CS("Harrys Fishing Shop", "Catherby", "Harry", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw shark", 300, 0),
				ShopList.CSI("Raw swordfish", 200, 0),
				ShopList.CSI("Raw lobster", 150, 0),
				ShopList.CSI("Raw bass", 120, 0),
				ShopList.CSI("Raw tuna", 100, 0),
				ShopList.CSI("Raw cod", 25, 0),
				ShopList.CSI("Raw mackerel", 20, 0),
				ShopList.CSI("Raw anchovies", 15, 0),
				ShopList.CSI("Raw herring", 15, 0),
				ShopList.CSI("Raw sardine", 10, 0),
				ShopList.CSI("Raw shrimps", 5, 0),
				ShopList.CSI("Lobster pot", 20, 2),
				ShopList.CSI("Harpoon", 5, 2),
				ShopList.CSI("Big fishing net", 20, 5),
				ShopList.CSI("Fishing rod", 5, 5),
				ShopList.CSI("Small fishing net", 5, 5),
				ShopList.CSI("Fishing bait", 3, 1200)
			})),
			ShopList.CS("Helmet Shop", "Barbarian Village", "Peksa", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant full helm", 3564, 0),
				ShopList.CSI("Adamant med helm", 1920, 1),
				ShopList.CSI("Mithril full helm", 1430, 1),
				ShopList.CSI("Mithril med helm", 780, 1),
				ShopList.CSI("Steel full helm", 550, 2),
				ShopList.CSI("Steel med helm", 300, 3),
				ShopList.CSI("Iron full helm", 154, 3),
				ShopList.CSI("Iron med helm", 84, 3),
				ShopList.CSI("Bronze full helm", 44, 4),
				ShopList.CSI("Bronze med helm", 24, 5)
			})),
			ShopList.CS("Herquin's Gems", "Falador", "Herquin", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Diamond", 2000, 0),
				ShopList.CSI("Ruby", 1000, 0),
				ShopList.CSI("Emerald", 500, 0),
				ShopList.CSI("Sapphire", 257, 0),
				ShopList.CSI("Uncut diamond", 200, 0),
				ShopList.CSI("Uncut ruby", 100, 0),
				ShopList.CSI("Uncut emerald", 50, 0),
				ShopList.CSI("Uncut sapphire", 25, 0)
			})),
			ShopList.CS("Heskel's Farming Patch", "Falador", "Heskel", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Hicktons Archery Emporium", "Catherby", "Hickton", "When you reach level 99 in the fletching skill, you can purchase an Achievement cape from Hickton for 99,000gp.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune brutal", 450, 0),
				ShopList.CSI("Rune arrow", 400, 0),
				ShopList.CSI("Comp ogre bow", 180, 0),
				ShopList.CSI("Adamant brutal", 95, 0),
				ShopList.CSI("Adamant arrow", 80, 0),
				ShopList.CSI("Mithril brutal", 50, 0),
				ShopList.CSI("Black brutal", 35, 0),
				ShopList.CSI("Mithril arrow", 32, 0),
				ShopList.CSI("Steel brutal", 20, 0),
				ShopList.CSI("Steel arrow", 12, 0),
				ShopList.CSI("Iron brutal", 10, 0),
				ShopList.CSI("Bronze brutal", 5, 0),
				ShopList.CSI("Studded body", 850, 2),
				ShopList.CSI("Studded chaps", 750, 2),
				ShopList.CSI("Longbow", 80, 2),
				ShopList.CSI("Crossbow", 70, 2),
				ShopList.CSI("Oak longbow", 160, 4),
				ShopList.CSI("Oak shortbow", 100, 4),
				ShopList.CSI("Shortbow", 50, 4),
				ShopList.CSI("Rune arrowtips", 200, 100),
				ShopList.CSI("Adamant arrowtips", 40, 200),
				ShopList.CSI("Bronze bolts", 3, 200),
				ShopList.CSI("Mithril arrowtips", 16, 400),
				ShopList.CSI("Steel arrowtips", 6, 600),
				ShopList.CSI("Iron arrow", 3, 800),
				ShopList.CSI("Iron arrowtips", 2, 800),
				ShopList.CSI("Bronze arrow", 1, 1000),
				ShopList.CSI("Bronze arrowtips", 1, 1000)
			})),
			ShopList.CS("Horvik's Armour Shop", "Jatizso", "Raum Urda-Stein", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril platebody", 5200, 1),
				ShopList.CSI("Black platebody", 3840, 1),
				ShopList.CSI("Steel platebody", 2000, 1),
				ShopList.CSI("Mithril chainbody", 1950, 1),
				ShopList.CSI("Studded body", 850, 1),
				ShopList.CSI("Studded chaps", 750, 1),
				ShopList.CSI("Iron platebody", 560, 1),
				ShopList.CSI("Iron platelegs", 280, 1),
				ShopList.CSI("Steel chainbody", 750, 3),
				ShopList.CSI("Iron chainbody", 210, 3),
				ShopList.CSI("Bronze platebody", 160, 3),
				ShopList.CSI("Bronze chainbody", 60, 5)
			})),
			ShopList.CS("Ian's Wilderness Cape Shop", "Wilderness, Forgotten Cemetery", "Ian", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-12 cape", 50, 100),
				ShopList.CSI("Team-2 cape", 50, 100),
				ShopList.CSI("Team-22 cape", 50, 100),
				ShopList.CSI("Team-32 cape", 50, 100),
				ShopList.CSI("Team-42 cape", 50, 100)
			})),
			ShopList.CS("Ifaba's General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Pot", 1, 3)
			})),
			ShopList.CS("Initiate Rank Armory", "Falador", "Sir Tiffy Cashien", "You must have completed the Recruitment Drive quest to use this shop. You may purchase Initiate Armour. Additionally, if you have completed the Slug Menace you may also purchase Proselyte.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Proselyte harness f", 25000, -1),
				ShopList.CSI("Proselyte harness m", 25000, -1),
				ShopList.CSI("Initiate harness m", 20000, -1),
				ShopList.CSI("Proselyte hauberk", 12000, -1),
				ShopList.CSI("Initiate hauberk", 10000, -1),
				ShopList.CSI("Proselyte cuisse", 10000, -1),
				ShopList.CSI("Proselyte tasset", 10000, -1),
				ShopList.CSI("Initiate cuisse", 8000, -1),
				ShopList.CSI("Proselyte sallet", 8000, -1),
				ShopList.CSI("Initiate sallet", 6000, -1)
			})),
			ShopList.CS("Irksol", "Zanaris Marketplace", "Irksol", "You must have completed the Lost City quest to access this shop. You need to pay one cut diamond to enter the marketplace area.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Ruby ring", 1012, 5)
			})),
			ShopList.CS("Island Fishmonger", "Miscellania", "Fishmonger", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Lobster pot", 26, 2),
				ShopList.CSI("Harpoon", 6, 2),
				ShopList.CSI("Fishing rod", 6, 5),
				ShopList.CSI("Small fishing net", 6, 5)
			})),
			ShopList.CS("Island Fishmonger", "Miscellania", "Fishmonger", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw shark", 390, 0),
				ShopList.CSI("Raw swordfish", 260, 0),
				ShopList.CSI("Raw lobster", 195, 0),
				ShopList.CSI("Raw bass", 156, 0),
				ShopList.CSI("Raw tuna", 112, 0),
				ShopList.CSI("Raw salmon", 65, 0),
				ShopList.CSI("Raw cod", 32, 0),
				ShopList.CSI("Raw pike", 32, 0),
				ShopList.CSI("Raw trout", 26, 0),
				ShopList.CSI("Raw mackerel", 22, 0),
				ShopList.CSI("Raw anchovies", 19, 0),
				ShopList.CSI("Raw herring", 19, 0),
				ShopList.CSI("Raw shrimps", 6, 0),
				ShopList.CSI("Big fishing net", 26, 5),
				ShopList.CSI("Raw sardine", 13, 200),
				ShopList.CSI("Feather", 2, 1000),
				ShopList.CSI("Fishing bait", 3, 1200)
			})),
			ShopList.CS("Island Greengrocer", "Miscellania", "Greengrocer", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Garlic", 3, 2),
				ShopList.CSI("Tomato", 4, 10),
				ShopList.CSI("Onion", 3, 10),
				ShopList.CSI("Cabbage", 1, 10),
				ShopList.CSI("Potato", 1, 10)
			})),
			ShopList.CS("Island Greengrocer", "Miscellania", "Greengrocer", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Garlic", 3, 2),
				ShopList.CSI("Tomato", 4, 10),
				ShopList.CSI("Onion", 3, 10),
				ShopList.CSI("Cabbage", 1, 10),
				ShopList.CSI("Potato", 1, 10)
			})),
			ShopList.CS("Jakut", "Zanaris Marketplace", "Jakut", "You must have completed the Lost City quest to access this shop. You need to pay one cut diamond to enter the marketplace area.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Dragon longsword", 100000, 2),
				ShopList.CSI("Dragon dagger", 30000, 2)
			})),
			ShopList.CS("Jamila's Craft Stall", "Sophanem", "Jamila", "This shop can only be accessed upon completion of the Contact! quest.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Amulet mould", 7, 2),
				ShopList.CSI("Necklace mould", 7, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Holy mould", 7, 3),
				ShopList.CSI("Needle", 1, 3),
				ShopList.CSI("Ring mould", 7, 4),
				ShopList.CSI("Sickle mould", 15, 6),
				ShopList.CSI("Tiara mould", 150, 10),
				ShopList.CSI("Thread", 1, 100)
			})),
			ShopList.CS("Jatix Herblore Shop", "Taverley", "Jatix", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Pestle and mortar", 4, 3),
				ShopList.CSI("Eye of newt", 3, 800),
				ShopList.CSI("Vial", 12, 1000)
			})),
			ShopList.CS("Jiminua's Jungle Store", "Tai Bwo Wannai, North", "Jimanua", "Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Knife", 9, 2),
				ShopList.CSI("Cooked meat", 6, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bronze axe", 24, 3),
				ShopList.CSI("Pestle and mortar", 6, 3),
				ShopList.CSI("Bronze pickaxe", 1, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Iron axe", 84, 5),
				ShopList.CSI("Antipoison(3)", 432, 10),
				ShopList.CSI("Rope", 27, 10),
				ShopList.CSI("Bread", 18, 10),
				ShopList.CSI("Bronze bar", 12, 10),
				ShopList.CSI("Leather boots", 9, 10),
				ShopList.CSI("Leather gloves", 9, 10),
				ShopList.CSI("Unlit torch", 6, 10),
				ShopList.CSI("Candle", 4, 10),
				ShopList.CSI("Spade", 4, 10),
				ShopList.CSI("Vial", 3, 10),
				ShopList.CSI("Chisel", 1, 10),
				ShopList.CSI("Hammer", 1, 10),
				ShopList.CSI("Leather body", 31, 23),
				ShopList.CSI("Charcoal", 67, 50),
				ShopList.CSI("Machete", 60, 50),
				ShopList.CSI("Papyrus", 15, 50),
				ShopList.CSI("Vial of water", 3, 50)
			})),
			ShopList.CS("Karamja General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Karamja's Wines, Spirits, and Beers", "Karamja, North", "Zambo", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug of wine", 3, 1),
				ShopList.CSI("Beer", 2, 3)
			})),
			ShopList.CS("Kebab Shop", "Pollnivneach", "Ali the Kebab Seller", "This shop is accessed through conversation only. This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Super kebab", 5, -1),
				ShopList.CSI("Kebab", 3, -1)
			})),
			ShopList.CS("Kebab Shop", "Pollnivneach", "Ali the Kebab Seller", "This shop is accessed through conversation only. This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Kebab", 1, -1)
			})),
			ShopList.CS("Kebab Store", "Keldagrim", "Kyut", "This shop is accessed through conversation only. You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Kebab", 1, -1)
			})),
			ShopList.CS("Keepa Kettilon's store", "Jatizso", "Keepa Kettilon", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Shark", 330, 0),
				ShopList.CSI("Swordfish", 220, 0),
				ShopList.CSI("Lobster", 165, 10),
				ShopList.CSI("Tuna", 110, 20),
				ShopList.CSI("Salmon", 55, 20),
				ShopList.CSI("Cod", 27, 20)
			})),
			ShopList.CS("Keldagrim Stonemason", "Keldagrim", "Stonemason", "Must have at least started the Giant Dwarf quest in order to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Magic stone", 975000, 10),
				ShopList.CSI("Marble block", 325000, 20),
				ShopList.CSI("Gold leaf", 130000, 20),
				ShopList.CSI("Limestone brick", 26, 1000)
			})),
			ShopList.CS("Keldagrim's Best Bread", "Keldagrim", "Randivor", "You must have started the Giant Dwarf quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake", 75, 3),
				ShopList.CSI("Bread", 18, 10)
			})),
			ShopList.CS("Khazard General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Knife", 8, 2),
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Bronze pickaxe", 1, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Rope", 25, 30),
				ShopList.CSI("Pot of flour", 14, 30),
				ShopList.CSI("Swamp paste", 42, 500)
			})),
			ShopList.CS("King's Axe Inn", "Keldagrim", "Barman", "This shop is accessed through conversation only. You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug of wine", 10, -1),
				ShopList.CSI("Dwarven stout", 2, -1),
				ShopList.CSI("Beer", 1, -1)
			})),
			ShopList.CS("Kragen's Farming Patch", "Ardougne, North", "Kragen", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Lady of the Waves Tickets", "Shilo Village", "Seravel", "This shop is accessed through conversation only. You must have completed the Shilo Village quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Ship ticket", 25, -1)
			})),
			ShopList.CS("Larry's Wilderness Cape Shop", "Wilderness, Near Bone Yard", "Larry", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-13 cape", 50, 100),
				ShopList.CSI("Team-23 cape", 50, 100),
				ShopList.CSI("Team-3 cape", 50, 100),
				ShopList.CSI("Team-33 cape", 50, 100),
				ShopList.CSI("Team-43 cape", 50, 100)
			})),
			ShopList.CS("Laughing Miner Pub", "Keldagrim", "Barmaid", "This shop is accessed through conversation only. You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Stew", 20, -1),
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("Legend's Guild General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Attack potion(3)", 18, 3),
				ShopList.CSI("Apple pie", 46, 5),
				ShopList.CSI("Swordfish", 310, 20),
				ShopList.CSI("Steel arrow", 18, 500)
			})),
			ShopList.CS("Legend's Guild Shop of Useful Items", "Legends Guild, Top Floor", "Siegfried Erkle", "You need to complete the Legends Quest to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Shield right half", 750000, 1),
				ShopList.CSI("Mithril seeds", 300, 6)
			})),
			ShopList.CS("Leprechaun Larry's Farming Supplies", "Top of the Troll Stronghold", "Tool Leprechaun", "You must have completed My Arm's Big Adventure to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Secateurs", 6, 1),
				ShopList.CSI("Compost", 26, 2),
				ShopList.CSI("Gardening trowel", 15, 2),
				ShopList.CSI("Watering can", 15, 2),
				ShopList.CSI("Seed dibber", 7, 4),
				ShopList.CSI("Plant cure", 52, 5),
				ShopList.CSI("Rake", 7, 6),
				ShopList.CSI("Cocktail glass", 1, 602)
			})),
			ShopList.CS("Lletya Archery store", "Lletya, Tirannwn", "Dalldav", "You must have started the Mourning's End Part 1 quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Willow longbow", 416, 5),
				ShopList.CSI("Willow shortbow", 260, 5),
				ShopList.CSI("Oak longbow", 28, 5),
				ShopList.CSI("Oak shortbow", 130, 5),
				ShopList.CSI("Crossbow", 91, 5),
				ShopList.CSI("Rune arrow", 520, 400),
				ShopList.CSI("Adamant arrow", 104, 450),
				ShopList.CSI("Mithril arrow", 41, 500),
				ShopList.CSI("Steel arrow", 15, 500),
				ShopList.CSI("Bronze bolts", 1, 1500),
				ShopList.CSI("Iron arrow", 3, 2000)
			})),
			ShopList.CS("Lletya Food Store", "Port Sarim", "Wydin", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug of wine", 1, 3),
				ShopList.CSI("Cake", 65, 5),
				ShopList.CSI("Bread", 15, 10),
				ShopList.CSI("Cheese", 5, 10),
				ShopList.CSI("Lobster", 195, 15)
			})),
			ShopList.CS("Lletya General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Hammer", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Knife", 7, 4),
				ShopList.CSI("Spade", 3, 5)
			})),
			ShopList.CS("Lletya Seamstress", "Lletya, Tirannwn", "Oronwen", "You must have started the Mourning's End Part 1 quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Needle", 1, 3),
				ShopList.CSI("Ball of wool", 2, 5),
				ShopList.CSI("Thread", 1, 8),
				ShopList.CSI("Blue dye", 6, 10),
				ShopList.CSI("Green dye", 6, 10),
				ShopList.CSI("Orange dye", 6, 10),
				ShopList.CSI("Purple dye", 6, 10),
				ShopList.CSI("Red dye", 6, 10),
				ShopList.CSI("Yellow dye", 6, 10)
			})),
			ShopList.CS("Louies' Armoured Legs Bazaar", "Al Kharid", "Louie Legs", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant platelegs", 6464, 0),
				ShopList.CSI("Mithril platelegs", 2600, 1),
				ShopList.CSI("Black platelegs", 1920, 1),
				ShopList.CSI("Steel platelegs", 650, 2),
				ShopList.CSI("Iron platelegs", 280, 3),
				ShopList.CSI("Bronze platelegs", 80, 5)
			})),
			ShopList.CS("Lowe's Archery Emporium", "Varrock", "Lowe", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Maple longbow", 640, 1),
				ShopList.CSI("Maple shortbow", 400, 1),
				ShopList.CSI("Willow longbow", 320, 2),
				ShopList.CSI("Willow shortbow", 200, 2),
				ShopList.CSI("Crossbow", 70, 2),
				ShopList.CSI("Oak longbow", 160, 3),
				ShopList.CSI("Oak shortbow", 100, 3),
				ShopList.CSI("Longbow", 80, 4),
				ShopList.CSI("Shortbow", 50, 4),
				ShopList.CSI("Adamant arrow", 80, 600),
				ShopList.CSI("Mithril arrow", 32, 800),
				ShopList.CSI("Steel arrow", 12, 1000),
				ShopList.CSI("Iron arrow", 8, 1500),
				ShopList.CSI("Bronze bolts", 1, 1500),
				ShopList.CSI("Bronze arrow", 6, 2000)
			})),
			ShopList.CS("Lumbridge General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Security book", 2, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Lundail's Arena-side Rune Shop", "Mage Arena", "Lundail", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cosmic rune", 50, 20),
				ShopList.CSI("Body rune", 3, 140),
				ShopList.CSI("Mind rune", 3, 140),
				ShopList.CSI("Air rune", 4, 200),
				ShopList.CSI("Earth rune", 4, 200),
				ShopList.CSI("Fire rune", 4, 200),
				ShopList.CSI("Water rune", 4, 200),
				ShopList.CSI("Law rune", 240, 250),
				ShopList.CSI("Death rune", 180, 250),
				ShopList.CSI("Nature rune", 180, 250),
				ShopList.CSI("Chaos rune", 90, 250)
			})),
			ShopList.CS("Lyra's Farming Patch", "Port Phasmatys, North West", "Lyra", "You must have completed the Priest in Peril quest to access this this shop. This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Mage Arena Staffs", "Mage Arena", "Chamber guardian", "You need to complete the Mage Arena task before you can access this shop. Step into the 'Sparkling Pool' to get to the shop area.", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Magic Guild Store", "Magic Guild, 2nd Floor", "Robe Store owner", "You need 66 Magic to access this store. When you reach level 99 in the Magic skill you can purchase an Achievement cape from the Robe Store Owner for 99,000gp", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mystic robe top", 120000, 1000),
				ShopList.CSI("Mystic robe bottom", 80000, 1000),
				ShopList.CSI("Mystic hat", 15000, 1000),
				ShopList.CSI("Mystic boots", 10000, 1000),
				ShopList.CSI("Mystic gloves", 10000, 1000)
			})),
			ShopList.CS("Magic Guild Store", "Magic Guild, 2nd Floor", "Robe Store owner", "You need 66 Magic to access this store. When you reach level 99 in the Magic skill you can purchase an Achievement cape from the Robe Store Owner for 99,000gp", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Staff of air", 1500, 2),
				ShopList.CSI("Staff of earth", 1500, 2),
				ShopList.CSI("Staff of fire", 1500, 2),
				ShopList.CSI("Staff of water", 1500, 2),
				ShopList.CSI("Battlestaff", 7000, 5),
				ShopList.CSI("Blood rune", 400, 250),
				ShopList.CSI("Soul rune", 300, 250),
				ShopList.CSI("Law rune", 240, 250),
				ShopList.CSI("Death rune", 180, 250),
				ShopList.CSI("Nature rune", 180, 250),
				ShopList.CSI("Chaos rune", 90, 250),
				ShopList.CSI("Air rune", 4, 5000),
				ShopList.CSI("Earth rune", 4, 5000),
				ShopList.CSI("Fire rune", 4, 5000),
				ShopList.CSI("Water rune", 4, 5000),
				ShopList.CSI("Body rune", 3, 5000),
				ShopList.CSI("Mind rune", 3, 5000)
			})),
			ShopList.CS("Martin Thwait's Lost and Found", "Burthorpe, Rouge's Den", "Martin Thwait", "When you reach level 99 in the Thieving skill, you can buy an Achievement cape from Martin for 99,000gp. You need 50 Thieving and 50 Agility to trade him.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Steel claws", 175, 1),
				ShopList.CSI("Iron claws", 50, 2),
				ShopList.CSI("Bronze claws", 15, 3),
				ShopList.CSI("Steel knife", 11, 5),
				ShopList.CSI("Iron knife", 3, 10),
				ShopList.CSI("Bronze knife", 1, 15),
				ShopList.CSI("Knife", 6, 20),
				ShopList.CSI("Lockpick", 20, 25),
				ShopList.CSI("Chisel", 1, 30),
				ShopList.CSI("Rope", 18, 50)
			})),
			ShopList.CS("Miltog's Lamps", "Dorgesh-Kaan", "Miltog", "You must have completed Death to the Dorgeshuun to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bullseye lantern", 630, 0),
				ShopList.CSI("Light orb", 525, 0),
				ShopList.CSI("Oil lantern", 187, 0),
				ShopList.CSI("Oil lamp", 42, 0),
				ShopList.CSI("Mining helmet", 900, 1),
				ShopList.CSI("Bullseye lantern", 600, 1),
				ShopList.CSI("Oil lantern", 180, 2),
				ShopList.CSI("Oil lamp", 37, 4),
				ShopList.CSI("Tinderbox", 1, 10),
				ShopList.CSI("Unlit torch", 6, 15)
			})),
			ShopList.CS("Miscellanian Clothes Shop", "Miscellania Dungeons", "Halla", "You must have started the Throne Of Miscellania quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI(5036, 750, 3),
				ShopList.CSI(5038, 750, 3),
				ShopList.CSI(5040, 750, 3),
				ShopList.CSI(5024, 650, 3),
				ShopList.CSI(5026, 650, 3),
				ShopList.CSI(5028, 650, 3),
				ShopList.CSI(5048, 625, 3),
				ShopList.CSI(5050, 625, 3),
				ShopList.CSI(5052, 600, 3),
				ShopList.CSI(5042, 390, 3),
				ShopList.CSI(5044, 360, 3),
				ShopList.CSI(5046, 360, 3),
				ShopList.CSI(3793, 500, 5),
				ShopList.CSI(3771, 500, 5),
				ShopList.CSI(3775, 250, 5),
				ShopList.CSI(3767, 250, 5),
				ShopList.CSI(3769, 250, 5),
				ShopList.CSI(3773, 250, 5)
			})),
			ShopList.CS("Miscellanian Food Shop", "Miscellania Dungeon", "Osvald", "Must have started the Throne of Miscellania quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Chocolate bar", 10, 2),
				ShopList.CSI("Bread", 12, 5),
				ShopList.CSI("Pot of flour", 10, 5),
				ShopList.CSI("Bucket of milk", 6, 5),
				ShopList.CSI("Cheese", 4, 5),
				ShopList.CSI("Onion", 3, 5),
				ShopList.CSI("Cabbage", 1, 5),
				ShopList.CSI("Potato", 1, 5)
			})),
			ShopList.CS("Miscellanian General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Moon Clan Fine Clothes", "Lunar Isle", "Rimae Sirsalis", "To be able to access this shop, you must have begun the Lunar Diplomacy quest. You cannot sell items back to this shop", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Needle", 1, 50),
				ShopList.CSI("Thread", 1, 500)
			})),
			ShopList.CS("Moonclan General store", "Lunar Isle", "Melena Moonlander", "To access this shop, you must have begun the Lunar Diplomacy quest.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Security book", 2, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Multi Cannon Parts For Sale", "Ice Mountain", "Nulodion", "Instead of buying each seperate part, a full cannon set can be bought from Nulodion for only 750,000gp.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cannon barrels", 200625, 5),
				ShopList.CSI("Cannon base", 200625, 5),
				ShopList.CSI("Cannon furnace", 200625, 5),
				ShopList.CSI("Cannon stand", 200625, 5)
			})),
			ShopList.CS("Nardah General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Nardah Hunter Shop", "Nardah", "Artimeus", "The best route to take to get to this shop would be to ride the carpet from Shantay pass to Pollnivneach, then from Pollniveach to Nardah.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Teasing stick", 60, 5),
				ShopList.CSI("Butterfly net", 24, 5),
				ShopList.CSI("Rabbit snare", 18, 10),
				ShopList.CSI("Unlit torch", 4, 20),
				ShopList.CSI("Box trap", 38, 25),
				ShopList.CSI("Magic box", 720, 30),
				ShopList.CSI("Bird snare", 6, 50),
				ShopList.CSI("Noose wand", 4, 50),
				ShopList.CSI("Butterfly jar", 1, 100)
			})),
			ShopList.CS("Nardok's Bone Weapons", "Dorgeshuun Mines", "Nardok", "You must have completed The Lost Tribe quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bone dagger", 2000, 5),
				ShopList.CSI("Dorgeshuun crossbow", 2000, 5),
				ShopList.CSI("Bone club", 600, 10),
				ShopList.CSI("Bone spear", 600, 10),
				ShopList.CSI("Bone bolts", 3, 1000)
			})),
			ShopList.CS("Nathifa's Bake Stall", "Sophanem", "Nathifa", "This shop can only be accessed once you have completed the Contact! quest.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake", 50, 3),
				ShopList.CSI("Bread", 12, 10),
				ShopList.CSI("Waterskin(4)", 30, 50)
			})),
			ShopList.CS("Neil's Wilderness Cape Shop", "Wilderness, Bandit Camp", "Neil", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-17 cape", 50, 100),
				ShopList.CSI("Team-27 cape", 50, 100),
				ShopList.CSI("Team-37 cape", 50, 100),
				ShopList.CSI("Team-47 cape", 50, 100),
				ShopList.CSI("Team-7 cape", 50, 100)
			})),
			ShopList.CS("Neitiznot Supplies", "Neitiznot", "Jorfridr Mordstatter", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bronze axe", 15, 10),
				ShopList.CSI("Hammer", 1, 10),
				ShopList.CSI("Knife", 1, 10),
				ShopList.CSI("Needle", 1, 10),
				ShopList.CSI("Thread", 1, 10),
				ShopList.CSI("Ball of wool", 2, 100)
			})),
			ShopList.CS("Nurmof's Pickaxe Shop", "Dwarven Mines", "Nurmof", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune pickaxe", 32000, 1),
				ShopList.CSI("Adamant pickaxe", 3200, 2),
				ShopList.CSI("Mithril pickaxe", 1300, 3),
				ShopList.CSI("Steel pickaxe", 500, 4),
				ShopList.CSI("Iron pickaxe", 140, 5),
				ShopList.CSI("Bronze pickaxe", 1, 6)
			})),
			ShopList.CS("Obli's General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cooked meat", 6, 2),
				ShopList.CSI("Bronze pickaxe", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bronze axe", 24, 3),
				ShopList.CSI("Pestle and mortar", 6, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Iron axe", 84, 5),
				ShopList.CSI("Rope", 27, 10),
				ShopList.CSI("Bread", 18, 10),
				ShopList.CSI("Bronze bar", 12, 10),
				ShopList.CSI("Leather boots", 9, 10),
				ShopList.CSI("Leather gloves", 9, 10),
				ShopList.CSI("Unlit torch", 6, 10),
				ShopList.CSI("Candle", 4, 10),
				ShopList.CSI("Spade", 4, 10),
				ShopList.CSI("Vial", 3, 10),
				ShopList.CSI("Chisel", 1, 10),
				ShopList.CSI("Hammer", 1, 10),
				ShopList.CSI("Leather body", 31, 23),
				ShopList.CSI("Charcoal", 67, 50),
				ShopList.CSI("Machete", 60, 50),
				ShopList.CSI("Papyrus", 15, 50),
				ShopList.CSI("Vial of water", 3, 50)
			})),
			ShopList.CS("Ore Seller", "Keldagrim, Blast Furnace", "Ordan", "You must have completed/started the Giant Dwarf quest to access this shop. Items are randomly stocked by the dwarves in this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril ore", 243, 100),
				ShopList.CSI("Gold ore", 225, 100),
				ShopList.CSI("Silver ore", 112, 100),
				ShopList.CSI("Coal", 67, 100),
				ShopList.CSI("Iron ore", 25, 100),
				ShopList.CSI("Copper ore", 4, 100),
				ShopList.CSI("Tin ore", 4, 100)
			})),
			ShopList.CS("Ore Store", "Jatizso", "Hring Hring", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamantite ore", 440, 0),
				ShopList.CSI("Mithril ore", 178, 0),
				ShopList.CSI("Gold ore", 165, 5),
				ShopList.CSI("Silver ore", 82, 5),
				ShopList.CSI("Coal", 49, 10),
				ShopList.CSI("Iron ore", 18, 10),
				ShopList.CSI("Tin ore", 3, 10),
				ShopList.CSI("Copper ore", 3, 20)
			})),
			ShopList.CS("Oziach", "Edgeville", "Oziach", "Must have completed the Dragon Slayer quest to use this shop.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune platebody", 84500, 2),
				ShopList.CSI("Green d'hide body", 10140, 2)
			})),
			ShopList.CS("Paramaya Inn", "Shilo Village", "Kaleb Paramaya", "You must have completed the Shilo Village quest to access this shop. This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1),
				ShopList.CSI("Jug of wine", 1, -1)
			})),
			ShopList.CS("Party Hall Drinks", "Seer's Party Hall, Top Floor", "Lucy/Meagan", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("Pelters Veg Stall", "Varrock", "Crate (Buy From)", "None", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Pelters Veg Stall", "Varrock", "Crate (Buy From)", "None", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Pelters Veg Stall", "Varrock", "Crate (Buy From)", "None", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Pickaxe-Is-Mine", "Keldagrim", "Tati", "You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune pickaxe", 41600, 1),
				ShopList.CSI("Adamant pickaxe", 4160, 2),
				ShopList.CSI("Mithril pickaxe", 1690, 3),
				ShopList.CSI("Steel pickaxe", 650, 4),
				ShopList.CSI("Bronze pickaxe", 1, 6)
			})),
			ShopList.CS("Pie Shop", "Cooks' Guild", "Romily Weaklax", "You must have level 32 Cooking and wear a Chef's hat to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Admiral pie", 310, 0),
				ShopList.CSI("Wild pie", 182, 0),
				ShopList.CSI("Summer pie", 140, 0),
				ShopList.CSI("Mud pie", 54, 0),
				ShopList.CSI("Fish pie", 100, 1),
				ShopList.CSI("Garden pie", 24, 2),
				ShopList.CSI("Apple pie", 30, 3),
				ShopList.CSI("Meat pie", 15, 4),
				ShopList.CSI("Redberry pie", 12, 5),
				ShopList.CSI("Pie recipe book", 5, 50)
			})),
			ShopList.CS("Pollnivneach General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Desert boots", 20, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Desert shirt", 40, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Cheese", 4, 5),
				ShopList.CSI("Tomato", 4, 5),
				ShopList.CSI("Lime", 2, 5),
				ShopList.CSI("Orange", 2, 5),
				ShopList.CSI("Jug of water", 1, 5),
				ShopList.CSI("Bowl of water", 4, 7),
				ShopList.CSI("Bucket of water", 6, 8),
				ShopList.CSI("Fake beard", 1, 11),
				ShopList.CSI("Bucket", 2, 12),
				ShopList.CSI("Kharidian headpiece", 1, 12),
				ShopList.CSI("Waterskin(4)", 27, 20)
			})),
			ShopList.CS("Port Khazard Bar", "Port Khazard", "Bartender", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("Port Phasmatys General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Bucket", 2, 100),
				ShopList.CSI("Pot", 1, 100)
			})),
			ShopList.CS("Quality Armour Shop", "Jatizso", "Raum Urda-Stein", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Black kiteshield", 2121, 0),
				ShopList.CSI("Steel sq shield", 780, 0),
				ShopList.CSI("Adamant chainbody", 6240, 1),
				ShopList.CSI("Mithril chainbody", 2535, 1),
				ShopList.CSI("Adamant med helm", 2496, 1),
				ShopList.CSI("Black chainbody", 1872, 1),
				ShopList.CSI("Mithril med helm", 1014, 1),
				ShopList.CSI("Steel chainbody", 975, 3),
				ShopList.CSI("Steel med helm", 390, 3)
			})),
			ShopList.CS("Quality Weapons Shop", "Keldagrim", "Santiri", "You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune longsword", 41600, 1),
				ShopList.CSI("Mithril battleaxe", 2197, 1),
				ShopList.CSI("Maple longbow", 832, 1),
				ShopList.CSI("Maple shortbow", 520, 1),
				ShopList.CSI("Adamant sword", 2704, 2),
				ShopList.CSI("Black longsword", 1248, 2),
				ShopList.CSI("Steel battleaxe", 845, 2),
				ShopList.CSI("Steel scimitar", 520, 2),
				ShopList.CSI("Mithril sword", 1098, 3),
				ShopList.CSI("Adamant arrow", 104, 600),
				ShopList.CSI("Mithril arrow", 41, 800)
			})),
			ShopList.CS("Quartermaster's Store", "Tyras Camp, Isafdar", "Quartermaster", "You must have started the Regicide quest to access this shop. Dragon halberds can only be bought after the Regicide Quest.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 3),
				ShopList.CSI("Tinderbox", 1, 3),
				ShopList.CSI("Dragon halberd", 325000, 5),
				ShopList.CSI("Pot", 1, 5),
				ShopList.CSI("Rune halberd", 83200, 7),
				ShopList.CSI("Adamant halberd", 8320, 7),
				ShopList.CSI("Mithril halberd", 3380, 7),
				ShopList.CSI("Black halberd", 2496, 10),
				ShopList.CSI("Steel halberd", 1300, 10),
				ShopList.CSI("Iron halberd", 364, 10),
				ShopList.CSI("Bronze halberd", 104, 10),
				ShopList.CSI("Bread", 15, 10)
			})),
			ShopList.CS("Raetul and Co's Cloth Store", "Sophanem", "Linen Worker", "You must have started the Icthlarin's Little Helper quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Silk", 30, 7),
				ShopList.CSI("Desert robe", 40, 9),
				ShopList.CSI("Thread", 1, 10),
				ShopList.CSI("Desert shirt", 40, 12),
				ShopList.CSI("Linen", 30, 14),
				ShopList.CSI("Needle", 1, 15)
			})),
			ShopList.CS("Ranael's Super Skirt Store", "Al Kharid", "Ranael", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant plateskirt", 6400, 1),
				ShopList.CSI("Mithril plateskirt", 2600, 1),
				ShopList.CSI("Black plateskirt", 1920, 1),
				ShopList.CSI("Steel plateskirt", 1000, 2),
				ShopList.CSI("Iron plateskirt", 280, 3),
				ShopList.CSI("Bronze plateskirt", 80, 5)
			})),
			ShopList.CS("Rasolo the Wandering Merchant", "West of Glarials tomb", "Rasolo", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Dragon dagger", 60000, 1),
				ShopList.CSI("Flamtaer hammer", 20000, 1),
				ShopList.CSI("Grey boots", 1000, 1),
				ShopList.CSI("Keg of beer", 500, 1),
				ShopList.CSI("Blue hat", 320, 1),
				ShopList.CSI("Black toy horsey", 200, 1),
				ShopList.CSI("Machete", 80, 1),
				ShopList.CSI("Swamp paste", 60, 1),
				ShopList.CSI("Waterskin(4)", 60, 1),
				ShopList.CSI("Desert boots", 40, 1),
				ShopList.CSI("Limestone brick", 40, 1),
				ShopList.CSI("Olive oil(3)", 40, 1),
				ShopList.CSI("Papyrus", 20, 1),
				ShopList.CSI("Sickle mould", 20, 1),
				ShopList.CSI("Holy mould", 10, 1),
				ShopList.CSI("Shantay pass", 10, 1),
				ShopList.CSI("Cocktail guide", 4, 1),
				ShopList.CSI("Greenman's ale", 4, 1),
				ShopList.CSI("Poison", 2, 1),
				ShopList.CSI("Spinach roll", 2, 1)
			})),
			ShopList.CS("Razmire Builders Merchant", "Mort'ton", "Razmire Keelgan", "You must cure Razmire in the Shades of Mort'ton quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plank", 1, 10),
				ShopList.CSI("Swamp paste", 31, 1000),
				ShopList.CSI("Limestone brick", 21, 1000),
				ShopList.CSI("Limestone", 10, 1000),
				ShopList.CSI("Timber beam", 1, 1000)
			})),
			ShopList.CS("Razmire General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Flamtaer hammer", 10000, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot of flour", 10, 100),
				ShopList.CSI("Vial of water", 2, 100),
				ShopList.CSI("Olive oil(3)", 26, 150)
			})),
			ShopList.CS("Reldak's Leather Armour", "Dorgesh-Kaan", "Reldak", "You must have completed Death to the Dorgeshuun to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Frog-leather body", 1000, 50),
				ShopList.CSI("Frog-leather chaps", 900, 50),
				ShopList.CSI("Frog-leather boots", 200, 50)
			})),
			ShopList.CS("Rellekka Longhall Bar", "Rellekka", "Thora the Barkeep", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Keg of beer", 325, 5),
				ShopList.CSI("Beer", 26, 5),
				ShopList.CSI("Beer", 2, 5)
			})),
			ShopList.CS("Rhazien's Farming Patch", "Etceteria", "Rhazien", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Rhonen's Farming Patch", "McGrubor's Woods", "Rhonen", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Richard's Farming Shop", "Ardougne, North", "Richard", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Watermelon", 48, 0),
				ShopList.CSI("Strawberry", 17, 0),
				ShopList.CSI("Wildblood hops", 15, 0),
				ShopList.CSI("Krandorian hops", 10, 0),
				ShopList.CSI("Sweetcorn", 9, 0),
				ShopList.CSI("Yanillian hops", 7, 0),
				ShopList.CSI("Jute fibre", 6, 0),
				ShopList.CSI("Asgarnian hops", 5, 0),
				ShopList.CSI("Barley", 4, 0),
				ShopList.CSI("Hammerstone hops", 4, 0),
				ShopList.CSI("Tomato", 4, 0),
				ShopList.CSI("Onion", 3, 0),
				ShopList.CSI("Cabbage", 1, 0),
				ShopList.CSI("Potato", 1, 0),
				ShopList.CSI("Plant cure", 40, 100),
				ShopList.CSI("Compost", 20, 500),
				ShopList.CSI("Gardening trowel", 12, 500),
				ShopList.CSI("Watering can", 8, 500),
				ShopList.CSI("Rake", 6, 500),
				ShopList.CSI("Seed dibber", 6, 500),
				ShopList.CSI("Secateurs", 5, 500),
				ShopList.CSI("Spade", 3, 500),
				ShopList.CSI("Basket", 1, 500),
				ShopList.CSI("Empty sack", 1, 500),
				ShopList.CSI("Empty plant pot", 1, 500)
			})),
			ShopList.CS("Richard's Wilderness Cape Shop", "Wilderness", "Richard", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-16 cape", 50, 100),
				ShopList.CSI("Team-26 cape", 50, 100),
				ShopList.CSI("Team-36 cape", 50, 100),
				ShopList.CSI("Team-46 cape", 50, 100),
				ShopList.CSI("Team-6 cape", 50, 100)
			})),
			ShopList.CS("Rimmington General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Security book", 2, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Rok's Chocs Box", "Nardah", "Rokuh", "This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Chocolate bar", 10, 25),
				ShopList.CSI("Choc-ice", 30, 30)
			})),
			ShopList.CS("Rommik's Crafting Supplies", "Rimmington", "Rommik", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Amulet mould", 5, 2),
				ShopList.CSI("Necklace mould", 5, 2),
				ShopList.CSI("Ring mould", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Holy mould", 5, 3),
				ShopList.CSI("Needle", 1, 3),
				ShopList.CSI("Sickle mould", 10, 6),
				ShopList.CSI("Tiara mould", 100, 10),
				ShopList.CSI("Thread", 1, 100)
			})),
			ShopList.CS("Rufus' Meat Emporium", "Canifis", "Rufus", "You must have completed the Priest in Peril quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw shark", 390, 1),
				ShopList.CSI("Raw salmon", 66, 4),
				ShopList.CSI("Raw pike", 33, 4),
				ShopList.CSI("Raw trout", 26, 5),
				ShopList.CSI("Raw bear meat", 1, 10),
				ShopList.CSI("Raw beef", 1, 10),
				ShopList.CSI("Raw chicken", 1, 10),
				ShopList.CSI("Raw rat meat", 1, 10)
			})),
			ShopList.CS("Rusty Anchor Inn", "Port Sarim", "Bartender", "This shop is accessed through conversation only.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("Sam's Wilderness Cape Shop", "Wilderness, Dark Fortress Area", "Sam", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-10 cape", 50, 100),
				ShopList.CSI("Team-20 cape", 50, 100),
				ShopList.CSI("Team-30 cape", 50, 100),
				ShopList.CSI("Team-40 cape", 50, 100),
				ShopList.CSI("Team-50 cape", 50, 100)
			})),
			ShopList.CS("Sarah's Farming Shop", "Falador, South", "Sarah", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Watermelon", 48, 0),
				ShopList.CSI("Strawberry", 17, 0),
				ShopList.CSI("Wildblood hops", 15, 0),
				ShopList.CSI("Krandorian hops", 10, 0),
				ShopList.CSI("Sweetcorn", 9, 0),
				ShopList.CSI("Yanillian hops", 7, 0),
				ShopList.CSI("Jute fibre", 6, 0),
				ShopList.CSI("Asgarnian hops", 5, 0),
				ShopList.CSI("Barley", 4, 0),
				ShopList.CSI("Hammerstone hops", 4, 0),
				ShopList.CSI("Tomato", 4, 0),
				ShopList.CSI("Onion", 3, 0),
				ShopList.CSI("Cabbage", 1, 0),
				ShopList.CSI("Potato", 1, 0),
				ShopList.CSI("Plant cure", 40, 100),
				ShopList.CSI("Compost", 20, 500),
				ShopList.CSI("Gardening trowel", 12, 500),
				ShopList.CSI("Watering can", 8, 500),
				ShopList.CSI("Rake", 6, 500),
				ShopList.CSI("Seed dibber", 6, 500),
				ShopList.CSI("Secateurs", 5, 500),
				ShopList.CSI("Spade", 3, 500),
				ShopList.CSI("Basket", 1, 500),
				ShopList.CSI("Empty sack", 1, 500),
				ShopList.CSI("Empty plant pot", 1, 500)
			})),
			ShopList.CS("Scavvo's Rune Store", "Champions Guild, 2nd Floor", "Scavvo", "You need 32 quest points to access this store.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune platelegs", 64000, 1),
				ShopList.CSI("Rune plateskirt", 64000, 1),
				ShopList.CSI("Rune chainbody", 50000, 1),
				ShopList.CSI("Rune longsword", 32000, 1),
				ShopList.CSI("Rune sword", 2800, 1),
				ShopList.CSI("Rune mace", 14400, 1),
				ShopList.CSI("Green d'hide chaps", 3900, 1),
				ShopList.CSI("Green d'hide vamb", 2500, 1),
				ShopList.CSI("Coif", 200, 2)
			})),
			ShopList.CS("Seddu's Adventurer's Shop", "Nardah", "Seddu", "This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune platelegs", 60800, 1),
				ShopList.CSI("Rune plateskirt", 60800, 1),
				ShopList.CSI("Rune chainbody", 47500, 1),
				ShopList.CSI("Green d'hide chaps", 3705, 1),
				ShopList.CSI("Green d'hide vamb", 2375, 1),
				ShopList.CSI("Steel kiteshield", 807, 1),
				ShopList.CSI("Black med helm", 547, 1)
			})),
			ShopList.CS("Selena's Farming Patch", "Yanille", "Selena", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Shantay Pass Shop", "Shantay Pass", "Shantay", "You can buy a Shanty pass quickly from Shantay by talking to him.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bowl", 4, 0),
				ShopList.CSI("Bucket", 2, 0),
				ShopList.CSI("Jug", 1, 0),
				ShopList.CSI("Bronze bar", 8, 5),
				ShopList.CSI("Desert robe", 40, 10),
				ShopList.CSI("Desert shirt", 40, 10),
				ShopList.CSI("Desert boots", 20, 10),
				ShopList.CSI("Bucket of water", 6, 10),
				ShopList.CSI("Knife", 6, 10),
				ShopList.CSI("Bowl of water", 4, 10),
				ShopList.CSI("Hammer", 1, 10),
				ShopList.CSI("Jug of water", 1, 10),
				ShopList.CSI("Rope", 18, 20),
				ShopList.CSI("Waterskin(4)", 30, 100),
				ShopList.CSI("Waterskin(0)", 15, 100),
				ShopList.CSI("Shantay pass", 5, 500),
				ShopList.CSI("Feather", 2, 500)
			})),
			ShopList.CS("Shop of Distaste", "Dueling Arena", "Fadli", "None", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Sigmund The Merchant", "Rellekka", "Sigmund the Merchant", "You must have completed the Fremennik Trials quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cooked meat", 5, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pestle and mortar", 5, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Bread", 17, 5),
				ShopList.CSI("Rope", 23, 10),
				ShopList.CSI("Bucket of water", 7, 10),
				ShopList.CSI("Egg", 5, 10),
				ShopList.CSI("Candle", 3, 10),
				ShopList.CSI("Spade", 3, 10),
				ShopList.CSI("Bucket", 2, 10),
				ShopList.CSI("Vial", 2, 10),
				ShopList.CSI("Vial of water", 2, 10),
				ShopList.CSI("Cabbage", 1, 10),
				ShopList.CSI("Chisel", 1, 10),
				ShopList.CSI("Hammer", 1, 10),
				ShopList.CSI("Potato", 1, 10)
			})),
			ShopList.CS("Silver Cog Silver Stall", "Keldagrim", "Gulldamar", "You must have started the Giant Dwarf quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Silver bar", 225, 1),
				ShopList.CSI("Silver ore", 112, 1),
				ShopList.CSI("Unstrung symbol", 300, 2)
			})),
			ShopList.CS("Simon's Wilderness Cape Shop", "Wilderness, Chaos Temple", "Simon", "The Wilderness is dangerous and players can attack you. Be careful.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-19 cape", 50, 100),
				ShopList.CSI("Team-29 cape", 50, 100),
				ShopList.CSI("Team-39 cape", 50, 100),
				ShopList.CSI("Team-49 cape", 50, 100),
				ShopList.CSI("Team-9 cape", 50, 100)
			})),
			ShopList.CS("Skulgrimen's Battle Gear", "Rellekka", "Skulgrimen", "You must have completed the Fremennik Trials quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune warhammer", 53950, 0),
				ShopList.CSI("Adamant warhammer", 5356, 1),
				ShopList.CSI("Mithril warhammer", 2158, 2),
				ShopList.CSI("Black warhammer", 1274, 3),
				ShopList.CSI("Steel warhammer", 832, 3),
				ShopList.CSI("Iron warhammer", 224, 4),
				ShopList.CSI("Archer helm", 78000, 5),
				ShopList.CSI("Berserker helm", 78000, 5),
				ShopList.CSI("Farseer helm", 78000, 5),
				ShopList.CSI("Warrior helm", 78000, 5),
				ShopList.CSI("Bronze warhammer", 61, 5)
			})),
			ShopList.CS("Slayer Equipment", "Burthorpe", "Turael", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Slayer's staff", 21000, 50),
				ShopList.CSI("Mirror shield", 5000, 50),
				ShopList.CSI("Spiny helmet", 650, 50),
				ShopList.CSI("Rock hammer", 500, 50),
				ShopList.CSI("Earmuffs", 200, 50),
				ShopList.CSI("Facemask", 200, 50),
				ShopList.CSI("Insulated boots", 200, 50),
				ShopList.CSI("Nose peg", 200, 50),
				ShopList.CSI("Slayer bell", 150, 50),
				ShopList.CSI("Bag of salt", 12, 5000)
			})),
			ShopList.CS("Smithing Smith's Shop", "Mos Le'Harmless", "Smith", "You must have the Little book o' Piracy from the Cabin Fever quest to use this shop. By talking to Smithing Smith's Shop you can buy Gentleman Mallerd's Rapier (25,600gp), Unlucky Jenkins' Lucky Cutlass (2,560gp) and Brass Hand Harry's Cutlass (1,040gp).", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril scimitar", 1040, 1),
				ShopList.CSI("Steel scimitar", 400, 2),
				ShopList.CSI("Iron scimitar", 112, 3),
				ShopList.CSI("Bronze scimitar", 32, 5),
				ShopList.CSI("Hammer", 1, 5)
			})),
			ShopList.CS("Snop Dal's Ogre General Supplies", "Gu'Tanoth", "Ogre trader", "You must have started the Watchtower quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Hammer", 1, 5)
			})),
			ShopList.CS("Snop Grud's Herblore Stall", "Gu'Tanoth", "Ogre merchant", "You must have started the Watchtower quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Pestle and mortar", 5, 3),
				ShopList.CSI("Eye of newt", 5, 50),
				ShopList.CSI("Vial", 2, 50)
			})),
			ShopList.CS("Solihib's Food Stall", "Marim", "Solihib", "You must have started the Monkey Madness quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Banana stew", 300, 10),
				ShopList.CSI("Monkey bar", 50, 20),
				ShopList.CSI("Monkey nuts", 3, 200),
				ShopList.CSI("Banana", 2, 1000)
			})),
			ShopList.CS("Tamayu's Spear Stall", "Tai Bwo Wannai", "Tamayu", "You must complete the Tai Bwo Wannai Trio access to use this shop.", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Taria's Farming Patch", "Rimmington", "Taria", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("The Asp and Snake Bar", "Pollnivneach", "Ali the Barman", "This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Brandy", 5, 4),
				ShopList.CSI("Vodka", 5, 5),
				ShopList.CSI("Jug of wine", 1, 5),
				ShopList.CSI("Whisky", 5, 10),
				ShopList.CSI("Grog", 3, 12),
				ShopList.CSI("Beer", 2, 83)
			})),
			ShopList.CS("The Big Heist Lodge", "Desert Bandit Camp", "Bartender", "This shop is in the desert, be sure that you have your desert survival equipment.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bandit's brew", 650, 10)
			})),
			ShopList.CS("The Dragon Inn", "Yanille", "Bartender", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Greenman's ale", 10, -1),
				ShopList.CSI("Beer", 2, -1),
				ShopList.CSI("Dragon bitter", 2, -1)
			})),
			ShopList.CS("The Esoterican Arms", "Miscellania Dungeon", "Runa", "Must have started the Royal Trouble quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cup of tea", 10, 5),
				ShopList.CSI("Jug of wine", 1, 5),
				ShopList.CSI("Beer", 2, 10),
				ShopList.CSI("Cider", 2, 10)
			})),
			ShopList.CS("The Forester's Arms", "Seer's Village", "Barmaid", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Stew", 20, -1),
				ShopList.CSI("Meat pie", 16, -1),
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("The Jolly Boar Inn", "Varrock, North East", "Bartender", "This shop is accessed through conversation only.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Beer", 2, -1)
			})),
			ShopList.CS("The Lighthouse Store", "Lighthouse", "Jossik", "You must have completed the Horror from the Deep quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket of water", 6, 5),
				ShopList.CSI("Brandy", 5, 5),
				ShopList.CSI("Gin", 5, 5),
				ShopList.CSI("Vodka", 5, 5),
				ShopList.CSI("Whisky", 5, 5),
				ShopList.CSI("Candle", 3, 5),
				ShopList.CSI("Grog", 3, 5),
				ShopList.CSI("Bucket", 2, 5),
				ShopList.CSI("Dwarven stout", 2, 5),
				ShopList.CSI("Greenman's ale", 2, 5),
				ShopList.CSI("Wizard's mind bomb", 2, 5),
				ShopList.CSI("Jug", 1, 5),
				ShopList.CSI("Jug of water", 1, 5),
				ShopList.CSI("Poison", 1, 5),
				ShopList.CSI("Tinderbox", 1, 5),
				ShopList.CSI("Rope", 19, 10),
				ShopList.CSI("Knife", 6, 10),
				ShopList.CSI("Pestle and mortar", 4, 10),
				ShopList.CSI("Spade", 3, 10),
				ShopList.CSI("Chisel", 1, 10),
				ShopList.CSI("Hammer", 1, 10),
				ShopList.CSI("Pot", 1, 10),
				ShopList.CSI("Vial", 2, 100),
				ShopList.CSI("Vial of water", 2, 100)
			})),
			ShopList.CS("The Other Inn", "Mos Le'Harmless", "Mama", "You must have the Little book o' Piracy from the Cabin Fever quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Jug of wine", 1, 1),
				ShopList.CSI("Beer", 2, 3),
				ShopList.CSI("Stew", 20, 5)
			})),
			ShopList.CS("The Rising Sun Inn", "Falador", "Barmaid", "This shop is accessed through conversation only.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Asgarnian ale", 3, -1),
				ShopList.CSI("Dwarven stout", 3, -1),
				ShopList.CSI("Wizard's mind bomb", 3, -1)
			})),
			ShopList.CS("The Shrimp and Parrot", "Brimhaven", "Alfonse the waiter", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Swordfish", 260, 2),
				ShopList.CSI("Cooked karambwan", 340, 3),
				ShopList.CSI("Lobster", 190, 4),
				ShopList.CSI("Tuna", 130, 5),
				ShopList.CSI("Cod", 32, 5),
				ShopList.CSI("Herring", 19, 5)
			})),
			ShopList.CS("The Spice Is Right", "Sophanem", "Embalmer", "No stocks of Curry leaves, Piles of salt, or Buckets of sap. Sell the extras you have left over here.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bucket of sap", 45, 0),
				ShopList.CSI("Pile of salt", 30, 0),
				ShopList.CSI("Curry leaf", 28, 0),
				ShopList.CSI("Pot", 1, 5),
				ShopList.CSI("Gnome spice", 3, 10),
				ShopList.CSI("Antipoison(3)", 432, 20)
			})),
			ShopList.CS("The Toad and Chicken", "Burthorpe", "Tostig", "This shop is also accessible in the Burthorpe Games Room.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Asgarnian ale", 2, 12),
				ShopList.CSI("Dwarven stout", 2, 12),
				ShopList.CSI("Wizard's mind bomb", 2, 12)
			})),
			ShopList.CS("Thessalia Fine Clothes", "Varrock", "Thessalia", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Brown apron", 2, 1),
				ShopList.CSI("Blue skirt", 2, 2),
				ShopList.CSI(428, 5, 3),
				ShopList.CSI(426, 5, 3),
				ShopList.CSI("Black skirt", 2, 3),
				ShopList.CSI("White apron", 2, 3),
				ShopList.CSI("Red cape", 2, 4),
				ShopList.CSI("Silk", 30, 5),
				ShopList.CSI("Pink skirt", 2, 5),
				ShopList.CSI("Leather boots", 6, 10),
				ShopList.CSI("Leather gloves", 6, 10),
				ShopList.CSI("Leather body", 21, 12)
			})),
			ShopList.CS("Tiadeche's Karambwan Stall", "Tai Bwo Wannai", "Tiadeche", "You must complete the Tai Bwo Wannai Trio quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI(3157, 2, 2),
				ShopList.CSI("Raw karambwan", 100, 10)
			})),
			ShopList.CS("Tony's Pizza Bases", "Wilderness, Bandit Camp", "Fat Tony", "The Wilderness is dangerous and players can attack you. Be careful.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Pizza base", 4, 30)
			})),
			ShopList.CS("Torrell's Farming Patch", "Ardougne, South", "Torrell", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Trader Stan's Trading Post", "Karamja", "Charter Crewmember", "This shop's stock is shared between all the different charter ship stops around the map.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rope", 45, 2),
				ShopList.CSI("Cake tin", 25, 2),
				ShopList.CSI("Knife", 15, 2),
				ShopList.CSI("Bowl", 10, 2),
				ShopList.CSI("Chisel", 2, 2),
				ShopList.CSI("Jug", 2, 2),
				ShopList.CSI("Shears", 2, 2),
				ShopList.CSI("Tinderbox", 2, 2),
				ShopList.CSI("Bucket", 5, 3),
				ShopList.CSI("Right eye patch", 5, 5),
				ShopList.CSI("Security book", 5, 5),
				ShopList.CSI("Hammer", 2, 5),
				ShopList.CSI("Pot", 2, 5),
				ShopList.CSI("Bucket of sand", 5, 10),
				ShopList.CSI("Orange", 5, 10),
				ShopList.CSI("Soda ash", 5, 10),
				ShopList.CSI("Banana", 5, 15),
				ShopList.CSI("Glassblowing pipe", 5, 15),
				ShopList.CSI("Pineapple", 5, 15),
				ShopList.CSI("Tyras helm", 1375, 20),
				ShopList.CSI("Lobster pot", 50, 20),
				ShopList.CSI("Raw rabbit", 50, 20),
				ShopList.CSI("Fishing rod", 12, 20),
				ShopList.CSI("Seaweed", 5, 20),
				ShopList.CSI("Swamp paste", 75, 30)
			})),
			ShopList.CS("Treznor's Farming Patch", "Varrock Castle", "Treznor", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Tutab's Magical Market", "Marim", "Tutab", "You must have started the Monkey Madness quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Law rune", 240, 250),
				ShopList.CSI("Air rune", 4, 1000),
				ShopList.CSI("Earth rune", 4, 1000),
				ShopList.CSI("Fire rune", 4, 1000),
				ShopList.CSI("Water rune", 4, 1000)
			})),
			ShopList.CS("Two Feet Charley's Fish Shop", "Mos Le'Harmless", "Charley", "You must have the Little book o' Piracy from the Cabin Fever quest to use this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Raw swordfish", 200, 1),
				ShopList.CSI("Raw lobster", 150, 2),
				ShopList.CSI("Raw bass", 120, 2),
				ShopList.CSI("Raw tuna", 100, 4),
				ShopList.CSI("Raw anchovies", 15, 5),
				ShopList.CSI("Raw cod", 25, 6),
				ShopList.CSI("Raw mackerel", 17, 7),
				ShopList.CSI("Raw herring", 15, 7),
				ShopList.CSI("Raw sardine", 10, 10),
				ShopList.CSI("Raw shrimps", 5, 10)
			})),
			ShopList.CS("Valaine's Shop of Champions", "Champions Guild, 2nd Floor", "Valaine", "You need 32 quest points to access this store.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant platebody", 16640, 1),
				ShopList.CSI("Black platelegs", 2500, 1),
				ShopList.CSI("Black full helm", 1372, 1),
				ShopList.CSI("Blue cape", 41, 2)
			})),
			ShopList.CS("Vanessa's Farming Shop", "Catherby", "Vanessa", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Watermelon", 48, 0),
				ShopList.CSI("Strawberry", 17, 0),
				ShopList.CSI("Wildblood hops", 15, 0),
				ShopList.CSI("Krandorian hops", 10, 0),
				ShopList.CSI("Sweetcorn", 9, 0),
				ShopList.CSI("Yanillian hops", 7, 0),
				ShopList.CSI("Jute fibre", 6, 0),
				ShopList.CSI("Asgarnian hops", 5, 0),
				ShopList.CSI("Barley", 4, 0),
				ShopList.CSI("Hammerstone hops", 4, 0),
				ShopList.CSI("Tomato", 4, 0),
				ShopList.CSI("Onion", 3, 0),
				ShopList.CSI("Cabbage", 1, 0),
				ShopList.CSI("Potato", 1, 0),
				ShopList.CSI("Plant cure", 40, 100),
				ShopList.CSI("Compost", 20, 500),
				ShopList.CSI("Gardening trowel", 12, 500),
				ShopList.CSI("Watering can", 8, 500),
				ShopList.CSI("Rake", 6, 500),
				ShopList.CSI("Seed dibber", 6, 500),
				ShopList.CSI("Secateurs", 5, 500),
				ShopList.CSI("Spade", 3, 500),
				ShopList.CSI("Basket", 1, 500),
				ShopList.CSI("Empty sack", 1, 500),
				ShopList.CSI("Empty plant pot", 1, 500)
			})),
			ShopList.CS("Varrock General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Cake tin", 3, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Security book", 2, 5),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Varrock Swordshop", "Varrock", "Shopkeeper", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant longsword", 3200, 1),
				ShopList.CSI("Adamant sword", 280, 2),
				ShopList.CSI("Mithril longsword", 1300, 2),
				ShopList.CSI("Black longsword", 960, 2),
				ShopList.CSI("Adamant dagger", 800, 2),
				ShopList.CSI("Mithril sword", 845, 3),
				ShopList.CSI("Black sword", 624, 3),
				ShopList.CSI("Steel longsword", 500, 3),
				ShopList.CSI("Mithril dagger", 325, 3),
				ShopList.CSI("Iron longsword", 140, 3),
				ShopList.CSI("Steel sword", 325, 4),
				ShopList.CSI("Black dagger", 240, 4),
				ShopList.CSI("Iron sword", 91, 4),
				ShopList.CSI("Bronze longsword", 40, 4),
				ShopList.CSI("Steel dagger", 125, 5),
				ShopList.CSI("Bronze sword", 26, 5),
				ShopList.CSI("Iron dagger", 35, 6),
				ShopList.CSI("Bronze dagger", 10, 10)
			})),
			ShopList.CS("Vasquen's Farming Patch", "Lumbridge, North", "Vasquen", "This shop is accessed through conversation only.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Plant cure", 25, -1),
				ShopList.CSI("Watering can", 25, -1),
				ShopList.CSI("Gardening trowel", 15, -1),
				ShopList.CSI("Rake", 15, -1),
				ShopList.CSI("Seed dibber", 15, -1)
			})),
			ShopList.CS("Vermundi's Clothes Stall", "Keldagrim", "Vermundi", "You must have started the Giant Dwarf quest to access this shop. You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Trousers", 715, 3),
				ShopList.CSI("Woven top", 650, 3),
				ShopList.CSI("Shirt", 585, 3),
				ShopList.CSI("Skirt", 455, 3),
				ShopList.CSI("Shorts", 364, 3),
				ShopList.CSI("Silk", 39, 5)
			})),
			ShopList.CS("Vigr's Warhammers", "Keldagrim", "Vigr", "You must have started the Giant Dwarf quest to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant warhammer", 5356, 1),
				ShopList.CSI("Mithril warhammer", 2158, 2),
				ShopList.CSI("Black warhammer", 1274, 3),
				ShopList.CSI("Steel warhammer", 832, 3),
				ShopList.CSI("Iron warhammer", 224, 4),
				ShopList.CSI("Bronze warhammer", 61, 5)
			})),
			ShopList.CS("Void Knight Archery Store", "Void Knights' Outpost", "Squire", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune javelin", 400, 5),
				ShopList.CSI("Rune arrowtips", 200, 5),
				ShopList.CSI("Adamant javelin", 160, 5),
				ShopList.CSI("Mithril javelin", 64, 5),
				ShopList.CSI("Adamant arrowtips", 40, 5),
				ShopList.CSI("Mithril arrowtips", 16, 5),
				ShopList.CSI("Steel javelin", 24, 10),
				ShopList.CSI("Iron javelin", 6, 10),
				ShopList.CSI("Steel arrowtips", 6, 10),
				ShopList.CSI("Bronze javelin", 4, 10),
				ShopList.CSI("Iron arrowtips", 2, 10),
				ShopList.CSI("Bronze arrowtips", 1, 10)
			})),
			ShopList.CS("Void Knight General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bronze axe", 20, 3),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Void Knight Magic Store", "Void Knights' Outpost", "Squire", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Death rune", 180, 250),
				ShopList.CSI("Chaos rune", 90, 250),
				ShopList.CSI("Air rune", 4, 5000),
				ShopList.CSI("Earth rune", 4, 5000),
				ShopList.CSI("Fire rune", 4, 5000),
				ShopList.CSI("Water rune", 4, 5000),
				ShopList.CSI("Body rune", 3, 5000),
				ShopList.CSI("Mind rune", 3, 5000)
			})),
			ShopList.CS("Warrior Guild Armoury", "King Lathas Training Camp", "Shopkeeper", "You must have completed the Biohazard quest in order to access this shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant longsword", 3840, 1),
				ShopList.CSI("Mithril 2h sword", 3120, 1),
				ShopList.CSI("Black 2h sword", 2304, 1),
				ShopList.CSI("Mithril battleaxe", 2028, 1),
				ShopList.CSI("Adamant sword", 2496, 2),
				ShopList.CSI("Adamant mace", 1728, 2),
				ShopList.CSI("Steel 2h sword", 1200, 2),
				ShopList.CSI("Black longsword", 1152, 2),
				ShopList.CSI("Adamant dagger", 960, 2),
				ShopList.CSI("Mithril longsword", 1560, 3),
				ShopList.CSI("Mithril sword", 1014, 3),
				ShopList.CSI("Steel chainbody", 900, 3),
				ShopList.CSI("Mithril mace", 702, 3),
				ShopList.CSI("Steel longsword", 600, 3),
				ShopList.CSI("Steel med helm", 360, 3),
				ShopList.CSI("Iron 2h sword", 336, 3),
				ShopList.CSI("Iron chainbody", 252, 3),
				ShopList.CSI("Iron longsword", 168, 3),
				ShopList.CSI("Iron med helm", 100, 3),
				ShopList.CSI("Steel battleaxe", 780, 4),
				ShopList.CSI("Mithril dagger", 390, 4),
				ShopList.CSI("Steel sword", 390, 4),
				ShopList.CSI("Black dagger", 288, 4),
				ShopList.CSI("Steel mace", 270, 4),
				ShopList.CSI("Iron sword", 109, 4),
				ShopList.CSI("Bronze 2h sword", 96, 4),
				ShopList.CSI("Iron mace", 75, 4),
				ShopList.CSI("Bronze longsword", 48, 4),
				ShopList.CSI("Bronze med helm", 28, 4),
				ShopList.CSI("Black sword", 748, 5),
				ShopList.CSI("Iron battleaxe", 218, 5),
				ShopList.CSI("Steel dagger", 150, 5),
				ShopList.CSI("Bronze chainbody", 72, 5),
				ShopList.CSI("Bronze sword", 31, 5),
				ShopList.CSI("Bronze mace", 21, 5),
				ShopList.CSI("Adamant 2h sword", 7680, 6),
				ShopList.CSI("Iron dagger", 42, 6),
				ShopList.CSI("Bronze dagger", 12, 10)
			})),
			ShopList.CS("Warrior Guild Food Shop", "Warrior Guild", "Lidio", "You must have 130 points in combat stats to enter the guild.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bass", 144, 10),
				ShopList.CSI("Stew", 24, 10),
				ShopList.CSI("Trout", 24, 10),
				ShopList.CSI("Potato with cheese", 9, 10)
			})),
			ShopList.CS("Warrior Guild Potion Shop", "Warrior Guild", "Lilly", "You must have 130+ Attack+Strength to enter the guild.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Defence potion(3)", 144, 10),
				ShopList.CSI("Attack potion(3)", 15, 10),
				ShopList.CSI("Strength potion(3)", 14, 10)
			})),
			ShopList.CS("Wayne's Chains! - Chainmail Specialist", "Falador", "Wayne", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Adamant chainbody", 4800, 1),
				ShopList.CSI("Mithril chainbody", 1950, 1),
				ShopList.CSI("Black chainbody", 1440, 1),
				ShopList.CSI("Steel chainbody", 750, 1),
				ShopList.CSI("Iron chainbody", 210, 2),
				ShopList.CSI("Bronze chainbody", 60, 3)
			})),
			ShopList.CS("Weapons Galore", "Jatizso", "Skuli Myrka", "You must have started the Fremennik Isles quest to be able to access this store.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril 2h sword", 2860, 4),
				ShopList.CSI("Mithril battleaxe", 1859, 4),
				ShopList.CSI("Mithril warhammer", 1826, 4),
				ShopList.CSI("Mithril longsword", 1430, 4),
				ShopList.CSI("Mithril claws", 522, 4)
			})),
			ShopList.CS("West Ardougne General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Longbow", 96, 2),
				ShopList.CSI("Leather boots", 7, 2),
				ShopList.CSI("Bucket", 2, 2),
				ShopList.CSI("Bronze pickaxe", 1, 2),
				ShopList.CSI("Hammer", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Rope", 21, 3),
				ShopList.CSI("Pot", 1, 3),
				ShopList.CSI("Bread", 14, 5),
				ShopList.CSI("Salmon", 60, 10),
				ShopList.CSI("Meat pie", 18, 10),
				ShopList.CSI("Cooked meat", 4, 10),
				ShopList.CSI("Bronze arrow", 1, 20)
			})),
			ShopList.CS("White Knight Master Armoury", "King Lathas Training Camp", "Shopkeeper", "You must have completed the Biohazard quest in order to access this shop.", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("William's Wilderness Cape Shop", "Wilderness, North of Red Dragons", "William", "The Wilderness is dangerous and players can attack you. Be careful.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Team-1 cape", 50, 100),
				ShopList.CSI("Team-11 cape", 50, 100),
				ShopList.CSI("Team-21 cape", 50, 100),
				ShopList.CSI("Team-31 cape", 50, 100),
				ShopList.CSI("Team-41 cape", 50, 100)
			})),
			ShopList.CS("Wine Shop", "Draynor Village", "Fortunado", "The 'Bottle of Wine' and 'Jug of Vinegar' are for paying members only. You must have started Rag and Bone Man quest to buy a Jug of Vinegar from this shop. Members can steal items from this merchant's stall.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Bottle of wine", 500, 2),
				ShopList.CSI("Jug", 1, 3),
				ShopList.CSI("Jug of wine", 1, 5)
			})),
			ShopList.CS("Wyson's Woad Leaves", "Falador", "Wyson the garderner", "This shop is accessed through conversation only.", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Woad leaf", 15, -1)
			})),
			ShopList.CS("Ye olde Tea Shoppe", "Varrock", "Tea seller", "You can steal items from this merchant's stall.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cup of tea", 10, 20)
			})),
			ShopList.CS("Yrsa's Accoutrements", "Rellekka", "Yrsa", "You must have completed the Fremennik Trials quest to use this shop.", true, ShopList.CSIL(new ShopItem[0])),
			ShopList.CS("Zaff's Superior Staffs!", "Varrock", "Zaff", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Staff of air", 1500, 2),
				ShopList.CSI("Staff of earth", 1500, 2),
				ShopList.CSI("Staff of fire", 1500, 2),
				ShopList.CSI("Staff of water", 1500, 2),
				ShopList.CSI("Battlestaff", 7000, 5),
				ShopList.CSI("Magic staff", 200, 5),
				ShopList.CSI("Staff", 15, 5)
			})),
			ShopList.CS("Zanaris General Store", "Canifis", "Fidelio", "You must have completed the Priest in Peril quest to access this shop. Any item can be sold to this store and then be bought by another player.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Cake tin", 13, 2),
				ShopList.CSI("Bowl", 5, 2),
				ShopList.CSI("Chisel", 1, 2),
				ShopList.CSI("Jug", 1, 2),
				ShopList.CSI("Shears", 1, 2),
				ShopList.CSI("Tinderbox", 1, 2),
				ShopList.CSI("Bucket", 2, 3),
				ShopList.CSI("Hammer", 1, 5),
				ShopList.CSI("Pot", 1, 5)
			})),
			ShopList.CS("Zeke's Superior Scimitars", "Al Kharid", "Zeke", "None", false, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril scimitar", 1060, 0),
				ShopList.CSI("Iron scimitar", 112, 3),
				ShopList.CSI("Bronze scimitar", 32, 5),
				ShopList.CSI("Steel scimitar", 368, 6)
			})),
			ShopList.CS("Zenesha's Plate Mail Body Shop", "Ardougne", "Zenesha", "None", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Mithril platebody", 5200, 1),
				ShopList.CSI("Black platebody", 3840, 1),
				ShopList.CSI("Steel platebody", 2000, 1),
				ShopList.CSI("Iron platebody", 560, 1),
				ShopList.CSI("Bronze platebody", 160, 3)
			})),
			ShopList.CS("~ Uglug's stuffsies ~", "Jiggig", "Uglug Nar", "You must have started the Zogre Flesh Eaters quest to access use shop.", true, ShopList.CSIL(new ShopItem[]
			{
				ShopList.CSI("Rune brutal", 450, 0),
				ShopList.CSI("Sanfew Serum(3)", 240, 0),
				ShopList.CSI("Comp ogre bow", 180, 0),
				ShopList.CSI("Ogre coffin key", 100, 0),
				ShopList.CSI("Adamant brutal", 95, 0),
				ShopList.CSI("Raw chompy", 85, 0),
				ShopList.CSI("Mithril brutal", 50, 0),
				ShopList.CSI("Black brutal", 35, 0),
				ShopList.CSI("Steel brutal", 20, 0),
				ShopList.CSI("Iron brutal", 10, 0),
				ShopList.CSI("Bronze brutal", 5, 0),
				ShopList.CSI("Knife", 6, 5),
				ShopList.CSI("Cooked chompy", 130, 10),
				ShopList.CSI("Bow string", 10, 10),
				ShopList.CSI("Achey tree logs", 4, 100)
			}))
		};

		public static void Initialize()
		{
		}

		public static List<Shop> CSL(params Shop[] shop)
		{
			return shop.ToList<Shop>();
		}

		public static List<ShopItem> CSIL(params ShopItem[] shop)
		{
			return shop.ToList<ShopItem>();
		}

		public static Shop CS(string name, string Location, string ShopKeeper, string ExtraNotes, bool members, List<ShopItem> items)
		{
			return new Shop(name, Location, ShopKeeper, ExtraNotes, members, items);
		}

		public static ShopItem CSI(string name, int cost, int quant)
		{
			return new ShopItem(CreationLists.GI(name, 1), cost, quant);
		}

		public static ShopItem CSI(int itemid, int cost, int quant)
		{
			return new ShopItem(CreationLists.GI(itemid, 1), cost, quant);
		}

		public static Shop GetShop(ShopItem SI)
		{
			Shop result;
			foreach (Shop current in ShopList.Shops)
			{
				bool flag = current.Items.Contains(SI);
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}
	}
}
