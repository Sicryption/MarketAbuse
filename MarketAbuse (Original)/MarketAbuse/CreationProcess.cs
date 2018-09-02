using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAbuse
{
    public class CreationProcess
    {
        public List<Item> itemsNeeded = new List<Item>();
        public List<Item> completedItems = null;
        public string completedItemsNameList = "";

        string Margin = "1";
        public int totalCost
        {
            get
            {
                int cost = 0;
                foreach (Item i in itemsNeeded)
                    cost += i.buyPrice * i.quantity;
                return cost;
            }
        }
        public int totalMoneyBack
        {
            get
            {
                int cost = 0;
                foreach (Item i in completedItems)
                    cost += i.sellPrice * i.quantity;
                return cost;
            }
        }
        public string margin
        {
            get
            {
                if (Margin != "null")
                    Margin = (totalMoneyBack - totalCost).ToString();
                return Margin;
            }
            set
            {
                Margin = value;
            }
        }
        public override string ToString()
        {
            return completedItemsNameList;
        }
        public CreationProcess(List<Item> itemsneeded, Item completeditem)
        {
            itemsNeeded = itemsneeded;
            completedItems = new List<Item> { completeditem };
            completedItemsNameList = completeditem.name;
        }
        public CreationProcess(List<Item> itemsneeded, List<Item> completeditems)
        {
            itemsNeeded = itemsneeded;
            completedItems = completeditems;
            for(int i = 0; i < completeditems.Count(); i++)
                completedItemsNameList += (i != completeditems.Count() - 1)?completeditems[i].name + " & ":completeditems[i].name;
        }
    }
    public class PossibleCreations
    {
        public static Item GetItem(string itemName, int quantity)
        {
            return MarketAbuse.GetItem(itemName, quantity);
        }

        public static Item GetItem(string itemName)
        {
            return MarketAbuse.GetItem(itemName);
        }

        public static Item GetItem(int id, int quantity = 0)
        {
            return MarketAbuse.GetItem(id, quantity);
        }

        public CreationProcess GetCreationProcess(List<int> itemsNeeded, List<int> completedItems)
        {
            List<List<CreationProcess>> list = new List<List<CreationProcess>>();
            list.AddRange(new List<CreationProcess>[] { Alterations, Construction, Crafting,
                Decant, Farming, Fletching, HerbCleaning, Herblore, Magic,
                Poisons, Prayer, Sets, Smithing, Runecrafting, Unfinished
                });

            foreach(List<CreationProcess> cpList in list)
            {
                foreach(CreationProcess cp in cpList)
                {
                    List<int> needed = new List<int>();
                    foreach (Item i in cp.itemsNeeded)
                        needed.Add(i.id);
                    List<int> completed = new List<int>();
                    foreach (Item i in cp.completedItems)
                        completed.Add(i.id);
                    
                    if (ConvertIntListToString(needed) == ConvertIntListToString(itemsNeeded)
                        && ConvertIntListToString(completedItems) == ConvertIntListToString(completed))
                    {
                        return cp;
                    }
                }
            }
            return null;
        }

        string ConvertIntListToString(List<int> list)
        {
            string s = "";
            foreach (int i in list)
                s += i + ",";
            return s;
        }

        //add any new lists to GetCreationProcess

        #region Alterations
        public List<CreationProcess> Alterations = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Black mask (10)")}
                , GetItem("Black mask")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorakian Hasta")}
                , GetItem("Zamorakian Spear")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorakian Spear"), GetItem("Coins", 300000) }
                , GetItem("Zamorakian Hasta")),
            new CreationProcess(
                new List<Item>() { GetItem("Tanzanite fang") }
                , GetItem("Zulrah's scales", 20000)),
            new CreationProcess(
                new List<Item>() { GetItem("Magic fang") }
                , GetItem("Zulrah's scales", 20000)),
            new CreationProcess(
                new List<Item>() { GetItem("Serpentine visage") }
                , GetItem("Zulrah's scales", 20000)),
            new CreationProcess(
                new List<Item>() { GetItem("Toxic blowpipe (empty)") }
                , GetItem("Zulrah's scales", 20000)),
            new CreationProcess(
                new List<Item>() { GetItem("Serpentine helm (uncharged)") }
                , GetItem("Zulrah's scales", 20000)),
            new CreationProcess(
                new List<Item>() { GetItem("Malediction shard 1"), GetItem("Malediction shard 2"), GetItem("Malediction shard 3")}
                , GetItem("Malediction ward")),
            new CreationProcess(
                new List<Item>() { GetItem("Odium shard 1"), GetItem("Odium shard 2"), GetItem("Odium shard 3") }
                , GetItem("Odium ward")),
            new CreationProcess(
                new List<Item>() { GetItem("Unblessed symbol") }
                , GetItem("Holy symbol")),
            new CreationProcess(
                new List<Item>() { GetItem("Unpowered symbol") }
                , GetItem("Unholy symbol")),
            new CreationProcess(
                new List<Item>() { GetItem("Cowhide"), GetItem("Coins", 1) }
                , GetItem("Leather")),
            new CreationProcess(
                new List<Item>() { GetItem("Cowhide"), GetItem("Coins", 3) }
                , GetItem("Hard leather")),
            new CreationProcess(
                new List<Item>() { GetItem("Green dragonhide"), GetItem("Coins", 20) }
                , GetItem("Green dragon leather")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragonhide"), GetItem("Coins", 20) }
                , GetItem("Blue dragon leather")),
            new CreationProcess(
                new List<Item>() { GetItem("Red dragonhide"), GetItem("Coins", 20) }
                , GetItem("Red dragon leather")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dragonhide"), GetItem("Coins", 20) }
                , GetItem("Black dragon leather")),
            new CreationProcess(
                new List<Item>() { GetItem("Yak-hide"), GetItem("Coins", 5) }
                , GetItem("Cured yak-hide")),
            new CreationProcess(
                new List<Item>() { GetItem("Vial"), GetItem("Coconut") }
                , GetItem("Coconut milk")),
            new CreationProcess(
                new List<Item>() { GetItem("Pineapple") }
                , GetItem("Pineapple ring", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Pineapple") }
                , GetItem("Pineapple chunks")),
            new CreationProcess(
                new List<Item>() { GetItem(9418), GetItem("Rope") }
                , GetItem("Mith grapple")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue partyhat"), GetItem("Sagacious spectacles"), GetItem("Coins", 500) }
                , GetItem("Partyhat & specs")),
            new CreationProcess(
                new List<Item>() { GetItem("Top hat"), GetItem("Monocle"), GetItem("Coins", 500) }
                , GetItem("Top hat & monocle")),
            // Bandana eyepatchs
            new CreationProcess(
                new List<Item>() { GetItem("Big pirate hat"), GetItem("Right eye patch"), GetItem("Coins", 500) }
                , GetItem("Pirate hat & patch")),
            new CreationProcess(
                new List<Item>() { GetItem("Black cavalier"), GetItem("Highwayman mask"), GetItem("Coins", 500) }
                , GetItem("Cavalier mask")),
            new CreationProcess(
                new List<Item>() { GetItem("Partyhat & specs"), GetItem("Coins", 600) }
                , new List<Item>() { GetItem("Blue partyhat"), GetItem("Sagacious spectacles") }),
            new CreationProcess(
                new List<Item>() { GetItem("Top hat & monocle"), GetItem("Coins", 600) }
                , new List<Item>() { GetItem("Top hat"), GetItem("Monocle") }),
            // Bandana eyepatchs
            new CreationProcess(
                new List<Item>() { GetItem("Pirate hat & patch"), GetItem("Coins", 600) }
                , new List<Item>() { GetItem("Big pirate hat"), GetItem("Right eye patch") }),
            new CreationProcess(
                new List<Item>() { GetItem("Cavalier mask"), GetItem("Coins", 600) }
                , new List<Item>() { GetItem("Black cavalier"), GetItem("Highwayman mask") }),
            new CreationProcess(
                new List<Item>() { GetItem("Coins", 200625) }
                , GetItem("Cannon barrels")),
            new CreationProcess(
                new List<Item>() { GetItem("Coins", 200625) }
                , GetItem("Cannon base")),
            new CreationProcess(
                new List<Item>() { GetItem("Coins", 200625) }
                , GetItem("Cannon furnace")),
            new CreationProcess(
                new List<Item>() { GetItem("Coins", 200625) }
                , GetItem("Cannon stand")),
            new CreationProcess(
                new List<Item>() { GetItem("Coins", 750000) }
                , GetItem("Dwarf cannon set")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak Godsword") }
                , new List<Item> () {  GetItem("Zamorak Hilt"), GetItem("Godsword blade") }),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl Godsword") }
                , new List<Item> () {  GetItem("Armadyl Hilt"), GetItem("Godsword blade") }),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin Godsword") }
                , new List<Item> () {  GetItem("Saradomin Hilt"), GetItem("Godsword blade") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos Godsword") }
                , new List<Item> () {  GetItem("Bandos Hilt"), GetItem("Godsword blade") }),
        };
        #endregion

        #region Construction
        public List<CreationProcess> Construction = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Logs"), GetItem("Coins", 100) }
                , GetItem("Plank")),
            new CreationProcess(
                new List<Item>() { GetItem("Oak logs"), GetItem("Coins", 250) }
                , GetItem("Oak plank")),
            new CreationProcess(
                new List<Item>() { GetItem("Teak logs"), GetItem("Coins", 500) }
                , GetItem("Teak plank")),
            new CreationProcess(
                new List<Item>() { GetItem("Mahogany logs"), GetItem("Coins", 1500) }
                , GetItem("Mahogany plank")),
        };
        #endregion
        
        #region Crafting
        public List<CreationProcess> Crafting = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Wool") }
                , GetItem("Ball of wool")),
            new CreationProcess(
                new List<Item>() { GetItem("Flax") }
                , GetItem("Bow string")),
            new CreationProcess(
                new List<Item>() { GetItem("Sinew") }
                , GetItem("Crossbow string")),
            new CreationProcess(
                new List<Item>() { GetItem("Oak roots") }
                , GetItem("Crossbow string")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic roots") }
                , GetItem("Magic string")),
            new CreationProcess(
                new List<Item>() { GetItem("Hair") }
                , GetItem("Rope")),
            new CreationProcess(
                new List<Item>() { GetItem("Jute fibre", 4) }
                , GetItem("Empty sack")),
            new CreationProcess(
                new List<Item>() { GetItem("Willow branch", 6) }
                , GetItem("Basket")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Unfired pot")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Pot")),
            new CreationProcess(
                new List<Item>() { GetItem("Unfired pot") }
                , GetItem("Pot")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Unfired pie dish")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Pie dish")),
            new CreationProcess(
                new List<Item>() { GetItem("Unfired pie dish") }
                , GetItem("Pie dish")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Unfired bowl")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Bowl")),
            new CreationProcess(
                new List<Item>() { GetItem("Unfired bowl") }
                , GetItem("Bowl")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Unfired plant pot")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Empty plant pot")),
            new CreationProcess(
                new List<Item>() { GetItem("Unfired plant pot") }
                , GetItem("Empty plant pot")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Unfired pot lid")),
            new CreationProcess(
                new List<Item>() { GetItem("Soft clay") }
                , GetItem("Pot lid")),
            new CreationProcess(
                new List<Item>() { GetItem("Unfired pot lid") }
                , GetItem("Pot lid")),
            new CreationProcess(
                new List<Item>() { GetItem("Limestone") }
                , GetItem("Limestone brick")),
            new CreationProcess(
                new List<Item>() { GetItem("Leather") }
                , GetItem("Leather gloves")),
            new CreationProcess(
                new List<Item>() { GetItem("Leather") }
                , GetItem("Leather boots")),
            new CreationProcess(
                new List<Item>() { GetItem("Leather") }
                , GetItem("Leather cowl")),
            new CreationProcess(
                new List<Item>() { GetItem("Leather") }
                , GetItem("Leather vambraces")),
            new CreationProcess(
                new List<Item>() { GetItem("Leather") }
                , GetItem("Leather body")),
            new CreationProcess(
                new List<Item>() { GetItem("Leather") }
                , GetItem("Leather chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Hard leather") }
                , GetItem("Hardleather body")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit claws"), GetItem("Leather vambraces") }
                , GetItem("Spiky vambraces")),
            new CreationProcess(
                new List<Item>() { GetItem("Leather") }
                , GetItem("Coif")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel studs"), GetItem("Leather body") }
                , GetItem("Studded body")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel studs"), GetItem("Leather chaps") }
                , GetItem("Studded chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Green dragon leather") }
                , GetItem("Green d'hide vamb")),
            new CreationProcess(
                new List<Item>() { GetItem("Green dragon leather", 2) }
                , GetItem("Green d'hide chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Green dragon leather", 3) }
                , GetItem("Green d'hide body")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit claws"), GetItem("Green d'hide vamb") }
                , GetItem("Green spiky vambs")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragon leather") }
                , GetItem("Blue d'hide vamb")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragon leather", 2) }
                , GetItem("Blue d'hide chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragon leather", 3) }
                , GetItem("Blue d'hide body")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit claws"), GetItem("Blue d'hide vamb") }
                , GetItem("Blue spiky vambs")),
            new CreationProcess(
                new List<Item>() { GetItem("Red dragon leather") }
                , GetItem("Red d'hide vamb")),
            new CreationProcess(
                new List<Item>() { GetItem("Red dragon leather", 2) }
                , GetItem("Red d'hide chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Red dragon leather", 3) }
                , GetItem("Red d'hide body")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit claws"), GetItem("Red d'hide vamb") }
                , GetItem("Red spiky vambs")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dragon leather") }
                , GetItem("Black d'hide vamb")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dragon leather", 2) }
                , GetItem("Black d'hide chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dragon leather", 3) }
                , GetItem("Black d'hide body")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit claws"), GetItem("Black d'hide vamb") }
                , GetItem("Black spiky vambs")),
            new CreationProcess(
                new List<Item>() { GetItem("Snakeskin", 6) }
                , GetItem("Snakeskin boots")),
            new CreationProcess(
                new List<Item>() { GetItem("Snakeskin", 8) }
                , GetItem("Snakeskin vambraces")),
            new CreationProcess(
                new List<Item>() { GetItem("Snakeskin", 5) }
                , GetItem("Snakeskin bandana")),
            new CreationProcess(
                new List<Item>() { GetItem("Snakeskin", 12) }
                , GetItem("Snakeskin chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Snakeskin", 15) }
                , GetItem("Snakeskin body")),
            new CreationProcess( // other broodoo colors
                new List<Item>() { GetItem("Snakeskin", 2), GetItem(6339), GetItem("Bronze nails", 8) }
                , GetItem(6259)),
            new CreationProcess( // other broodoo colors
                new List<Item>() { GetItem("Snakeskin", 2), GetItem(6335), GetItem("Bronze nails", 8) }
                , GetItem(6215)),
            new CreationProcess( // other broodoo colors
                new List<Item>() { GetItem("Snakeskin", 2), GetItem(6337), GetItem("Bronze nails", 8) }
                , GetItem(6237)),
            new CreationProcess( // yak-hide body
                new List<Item>() { GetItem("Cured yak-hide", 2) }
                , GetItem(10822)),
            new CreationProcess( // yak-hide legs
                new List<Item>() { GetItem("Cured yak-hide") }
                , GetItem(10824)),
            // shells + snelms
            new CreationProcess(
                new List<Item>() { GetItem("Circular hide"), GetItem("Dagannoth hide"), GetItem("Coins", 5000) }
                , GetItem("Spined helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Flattened hide"), GetItem("Dagannoth hide", 3), GetItem("Coins", 10000) }
                , GetItem("Spined body")),
            new CreationProcess(
                new List<Item>() { GetItem("Stretched hide"), GetItem("Dagannoth hide", 2), GetItem("Coins", 7500) }
                , GetItem("Spined chaps")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Beer glass")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Empty candle lantern")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Empty oil lamp")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Vial")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Empty fishbowl")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Unpowered orb")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Lantern lens")),
            new CreationProcess(
                new List<Item>() { GetItem("Molten glass") }
                , GetItem("Light orb")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut opal") }
                , GetItem("Opal")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut jade") }
                , GetItem("Jade")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut red topaz") }
                , GetItem("Red topaz")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut sapphire") }
                , GetItem("Sapphire")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut emerald") }
                , GetItem("Emerald")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut ruby") }
                , GetItem("Ruby")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut diamond") }
                , GetItem("Diamond")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut dragonstone") }
                , GetItem("Dragonstone")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut onyx") }
                , GetItem("Onyx")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut onyx"), GetItem("Zenyte shard") }
                , GetItem("Uncut zenyte")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncut zenyte") }
                , GetItem("Zenyte")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar") }
                , GetItem("Gold ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar") }
                , GetItem("Gold necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar") }
                , GetItem("Gold bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Ball of wool") }
                , GetItem("Gold amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Sapphire") }
                , GetItem("Sapphire ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Sapphire") }
                , GetItem("Sapphire necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Sapphire") }
                , GetItem("Sapphire bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Sapphire"), GetItem("Ball of wool") }
                , GetItem("Sapphire amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Emerald") }
                , GetItem("Emerald ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Emerald") }
                , GetItem("Emerald necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Emerald") }
                , GetItem("Emerald bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Emerald"), GetItem("Ball of wool") }
                , GetItem("Emerald amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Ruby") }
                , GetItem("Ruby ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Ruby") }
                , GetItem("Ruby necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Ruby") }
                , GetItem("Ruby bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Ruby"), GetItem("Ball of wool") }
                , GetItem("Ruby amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Diamond") }
                , GetItem("Diamond ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Diamond") }
                , GetItem("Diamond necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Diamond") }
                , GetItem("Diamond bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Diamond"), GetItem("Ball of wool") }
                , GetItem("Diamond amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Dragonstone") }
                , GetItem("Dragonstone ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Dragonstone") }
                , GetItem("Dragon necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Dragonstone") }
                , GetItem("Dragonstone bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Dragonstone"), GetItem("Ball of wool") }
                , GetItem("Dragonstone amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Onyx") }
                , GetItem("Onyx ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Onyx") }
                , GetItem("Onyx necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Onyx") }
                , GetItem("Onyx bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Onyx"), GetItem("Ball of wool") }
                , GetItem("Onyx amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Zenyte") }
                , GetItem("Zenyte ring")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Zenyte") }
                , GetItem("Zenyte necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Zenyte") }
                , GetItem("Zenyte bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold bar"), GetItem("Zenyte"), GetItem("Ball of wool") }
                , GetItem("Zenyte amulet")),
            new CreationProcess(
                new List<Item>() { GetItem("Silver bar") }
                , GetItem("Silver bolts (unf)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Silver bar") }
                , GetItem("Unstrung symbol")),
            new CreationProcess(
                new List<Item>() { GetItem("Unstrung symbol"), GetItem("Ball of wool") }
                , GetItem("Unblessed symbol")),
            new CreationProcess(
                new List<Item>() { GetItem("Silver bar") }
                , GetItem("Unstrung emblem")),
            new CreationProcess(
                new List<Item>() { GetItem("Unstrung emblem"), GetItem("Ball of wool") }
                , GetItem("Unpowered symbol")),
            new CreationProcess(
                new List<Item>() { GetItem("Silver bar") }
                , GetItem("Tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Battlestaff"), GetItem("Water orb") }
                , GetItem("Water battlestaff")),
            new CreationProcess(
                new List<Item>() { GetItem("Battlestaff"), GetItem("Earth orb") }
                , GetItem("Earth battlestaff")),
            new CreationProcess(
                new List<Item>() { GetItem("Battlestaff"), GetItem("Fire orb") }
                , GetItem("Fire battlestaff")),
            new CreationProcess(
                new List<Item>() { GetItem("Battlestaff"), GetItem("Air orb") }
                , GetItem("Air battlestaff")),
            new CreationProcess(
                new List<Item>() { GetItem("Serpentine visage") }
                , GetItem("Serpentine helm (uncharged)")),
            new CreationProcess(
                new List<Item>() { GetItem("Uncharged trident"), GetItem("Magic fang") }
                , GetItem("Uncharged toxic trident")),
            new CreationProcess(
                new List<Item>() { GetItem("Staff of the dead"), GetItem("Magic fang") }
                , GetItem("Toxic staff (uncharged)")),
        };
        #endregion

        #region Decant
        public List<CreationProcess> Decant = new List<CreationProcess>
        {
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(1)", 2) }
                , GetItem("Attack potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(1)", 3) }
                , GetItem("Attack potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(1)", 4) }
                , GetItem("Attack potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(2)", 2) }
                , GetItem("Attack potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(2)"), GetItem("Attack potion(1)") }
                , GetItem("Attack potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(3)"), GetItem("Attack potion(1)") }
                , GetItem("Attack potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(4)") }
                , GetItem("Attack potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(3)") }
                , new List<Item>() { GetItem("Attack potion(2)"), GetItem("Attack potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(2)") }
                , GetItem("Attack potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(1)", 2) }
                , GetItem("Antipoison(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(1)", 3) }
                , GetItem("Antipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(1)", 4) }
                , GetItem("Antipoison(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(2)", 2) }
                , GetItem("Antipoison(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(2)"), GetItem("Antipoison(1)") }
                , GetItem("Antipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(3)"), GetItem("Antipoison(1)") }
                , GetItem("Antipoison(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(4)") }
                , GetItem("Antipoison(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(3)") }
                , new List<Item>() { GetItem("Antipoison(2)"), GetItem("Antipoison(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(2)") }
                , GetItem("Antipoison(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(1)", 2) }
                , GetItem("Strength potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(1)", 3) }
                , GetItem("Strength potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(1)", 4) }
                , GetItem("Strength potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(2)", 2) }
                , GetItem("Strength potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(2)"), GetItem("Strength potion(1)") }
                , GetItem("Strength potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(3)"), GetItem("Strength potion(1)") }
                , GetItem("Strength potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(4)") }
                , GetItem("Strength potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(3)") }
                , new List<Item>() { GetItem("Strength potion(2)"), GetItem("Strength potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(2)") }
                , GetItem("Strength potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (1)", 2) }
                , GetItem("Serum 207 (2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (1)", 3) }
                , GetItem("Serum 207 (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (1)", 4) }
                , GetItem("Serum 207 (4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (2)", 2) }
                , GetItem("Serum 207 (4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (2)"), GetItem("Serum 207 (1)") }
                , GetItem("Serum 207 (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (3)"), GetItem("Serum 207 (1)") }
                , GetItem("Serum 207 (4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (4)") }
                , GetItem("Serum 207 (2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (3)") }
                , new List<Item>() { GetItem("Serum 207 (2)"), GetItem("Serum 207 (1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Serum 207 (2)") }
                , GetItem("Serum 207 (1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(1)", 2) }
                , GetItem("Guthix rest(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(1)", 3) }
                , GetItem("Guthix rest(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(1)", 4) }
                , GetItem("Guthix rest(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(2)", 2) }
                , GetItem("Guthix rest(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(2)"), GetItem("Guthix rest(1)") }
                , GetItem("Guthix rest(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(3)"), GetItem("Guthix rest(1)") }
                , GetItem("Guthix rest(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(4)") }
                , GetItem("Guthix rest(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(3)") }
                , new List<Item>() { GetItem("Guthix rest(2)"), GetItem("Guthix rest(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix rest(2)") }
                , GetItem("Guthix rest(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(1)", 2) }
                , GetItem("Restore potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(1)", 3) }
                , GetItem("Restore potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(1)", 4) }
                , GetItem("Restore potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(2)", 2) }
                , GetItem("Restore potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(2)"), GetItem("Restore potion(1)") }
                , GetItem("Restore potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(3)"), GetItem("Restore potion(1)") }
                , GetItem("Restore potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(4)") }
                , GetItem("Restore potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(3)") }
                , new List<Item>() { GetItem("Restore potion(2)"), GetItem("Restore potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(2)") }
                , GetItem("Restore potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(1)", 2) }
                , GetItem("Guthix balance(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(1)", 3) }
                , GetItem("Guthix balance(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(1)", 4) }
                , GetItem("Guthix balance(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(2)", 2) }
                , GetItem("Guthix balance(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(2)"), GetItem("Guthix balance(1)") }
                , GetItem("Guthix balance(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(3)"), GetItem("Guthix balance(1)") }
                , GetItem("Guthix balance(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(4)") }
                , GetItem("Guthix balance(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(3)") }
                , new List<Item>() { GetItem("Guthix balance(2)"), GetItem("Guthix balance(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix balance(2)") }
                , GetItem("Guthix balance(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(1)", 2) }
                , GetItem("Energy potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(1)", 3) }
                , GetItem("Energy potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(1)", 4) }
                , GetItem("Energy potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(2)", 2) }
                , GetItem("Energy potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(2)"), GetItem("Energy potion(1)") }
                , GetItem("Energy potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(3)"), GetItem("Energy potion(1)") }
                , GetItem("Energy potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(4)") }
                , GetItem("Energy potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(3)") }
                , new List<Item>() { GetItem("Energy potion(2)"), GetItem("Energy potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(2)") }
                , GetItem("Energy potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(1)", 2) }
                , GetItem("Defence potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(1)", 3) }
                , GetItem("Defence potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(1)", 4) }
                , GetItem("Defence potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(2)", 2) }
                , GetItem("Defence potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(2)"), GetItem("Defence potion(1)") }
                , GetItem("Defence potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(3)"), GetItem("Defence potion(1)") }
                , GetItem("Defence potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(4)") }
                , GetItem("Defence potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(3)") }
                , new List<Item>() { GetItem("Defence potion(2)"), GetItem("Defence potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(2)") }
                , GetItem("Defence potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(1)", 2) }
                , GetItem("Agility potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(1)", 3) }
                , GetItem("Agility potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(1)", 4) }
                , GetItem("Agility potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(2)", 2) }
                , GetItem("Agility potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(2)"), GetItem("Agility potion(1)") }
                , GetItem("Agility potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(3)"), GetItem("Agility potion(1)") }
                , GetItem("Agility potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(4)") }
                , GetItem("Agility potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(3)") }
                , new List<Item>() { GetItem("Agility potion(2)"), GetItem("Agility potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(2)") }
                , GetItem("Agility potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(1)", 2) }
                , GetItem("Combat potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(1)", 3) }
                , GetItem("Combat potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(1)", 4) }
                , GetItem("Combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(2)", 2) }
                , GetItem("Combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(2)"), GetItem("Combat potion(1)") }
                , GetItem("Combat potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(3)"), GetItem("Combat potion(1)") }
                , GetItem("Combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(4)") }
                , GetItem("Combat potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(3)") }
                , new List<Item>() { GetItem("Combat potion(2)"), GetItem("Combat potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(2)") }
                , GetItem("Combat potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(1)", 2) }
                , GetItem("Prayer potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(1)", 3) }
                , GetItem("Prayer potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(1)", 4) }
                , GetItem("Prayer potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(2)", 2) }
                , GetItem("Prayer potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(2)"), GetItem("Prayer potion(1)") }
                , GetItem("Prayer potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(3)"), GetItem("Prayer potion(1)") }
                , GetItem("Prayer potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(4)") }
                , GetItem("Prayer potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(3)") }
                , new List<Item>() { GetItem("Prayer potion(2)"), GetItem("Prayer potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(2)") }
                , GetItem("Prayer potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(1)", 2) }
                , GetItem("Super attack(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(1)", 3) }
                , GetItem("Super attack(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(1)", 4) }
                , GetItem("Super attack(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(2)", 2) }
                , GetItem("Super attack(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(2)"), GetItem("Super attack(1)") }
                , GetItem("Super attack(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(3)"), GetItem("Super attack(1)") }
                , GetItem("Super attack(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(4)") }
                , GetItem("Super attack(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(3)") }
                , new List<Item>() { GetItem("Super attack(2)"), GetItem("Super attack(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(2)") }
                , GetItem("Super attack(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(1)", 2) }
                , GetItem("Superantipoison(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(1)", 3) }
                , GetItem("Superantipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(1)", 4) }
                , GetItem("Superantipoison(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(2)", 2) }
                , GetItem("Superantipoison(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(2)"), GetItem("Superantipoison(1)") }
                , GetItem("Superantipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(3)"), GetItem("Superantipoison(1)") }
                , GetItem("Superantipoison(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(4)") }
                , GetItem("Superantipoison(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(3)") }
                , new List<Item>() { GetItem("Superantipoison(2)"), GetItem("Superantipoison(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(2)") }
                , GetItem("Superantipoison(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(1)", 2) }
                , GetItem("Fishing potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(1)", 3) }
                , GetItem("Fishing potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(1)", 4) }
                , GetItem("Fishing potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(2)", 2) }
                , GetItem("Fishing potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(2)"), GetItem("Fishing potion(1)") }
                , GetItem("Fishing potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(3)"), GetItem("Fishing potion(1)") }
                , GetItem("Fishing potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(4)") }
                , GetItem("Fishing potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(3)") }
                , new List<Item>() { GetItem("Fishing potion(2)"), GetItem("Fishing potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(2)") }
                , GetItem("Fishing potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(1)", 2) }
                , GetItem("Super energy(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(1)", 3) }
                , GetItem("Super energy(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(1)", 4) }
                , GetItem("Super energy(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(2)", 2) }
                , GetItem("Super energy(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(2)"), GetItem("Super energy(1)") }
                , GetItem("Super energy(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(3)"), GetItem("Super energy(1)") }
                , GetItem("Super energy(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(4)") }
                , GetItem("Super energy(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(3)") }
                , new List<Item>() { GetItem("Super energy(2)"), GetItem("Super energy(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(2)") }
                , GetItem("Super energy(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(1)", 2) }
                , GetItem("Hunter potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(1)", 3) }
                , GetItem("Hunter potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(1)", 4) }
                , GetItem("Hunter potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(2)", 2) }
                , GetItem("Hunter potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(2)"), GetItem("Hunter potion(1)") }
                , GetItem("Hunter potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(3)"), GetItem("Hunter potion(1)") }
                , GetItem("Hunter potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(4)") }
                , GetItem("Hunter potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(3)") }
                , new List<Item>() { GetItem("Hunter potion(2)"), GetItem("Hunter potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(2)") }
                , GetItem("Hunter potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(1)", 2) }
                , GetItem("Super strength(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(1)", 3) }
                , GetItem("Super strength(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(1)", 4) }
                , GetItem("Super strength(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(2)", 2) }
                , GetItem("Super strength(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(2)"), GetItem("Super strength(1)") }
                , GetItem("Super strength(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(3)"), GetItem("Super strength(1)") }
                , GetItem("Super strength(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(4)") }
                , GetItem("Super strength(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(3)") }
                , new List<Item>() { GetItem("Super strength(2)"), GetItem("Super strength(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(2)") }
                , GetItem("Super strength(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(1)", 2) }
                , GetItem("Super restore(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(1)", 3) }
                , GetItem("Super restore(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(1)", 4) }
                , GetItem("Super restore(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(2)", 2) }
                , GetItem("Super restore(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(2)"), GetItem("Super restore(1)") }
                , GetItem("Super restore(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(3)"), GetItem("Super restore(1)") }
                , GetItem("Super restore(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(4)") }
                , GetItem("Super restore(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(3)") }
                , new List<Item>() { GetItem("Super restore(2)"), GetItem("Super restore(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(2)") }
                , GetItem("Super restore(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(1)", 2) }
                , GetItem("Super defence(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(1)", 3) }
                , GetItem("Super defence(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(1)", 4) }
                , GetItem("Super defence(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(2)", 2) }
                , GetItem("Super defence(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(2)"), GetItem("Super defence(1)") }
                , GetItem("Super defence(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(3)"), GetItem("Super defence(1)") }
                , GetItem("Super defence(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(4)") }
                , GetItem("Super defence(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(3)") }
                , new List<Item>() { GetItem("Super defence(2)"), GetItem("Super defence(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(2)") }
                , GetItem("Super defence(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(1)", 2) }
                , GetItem("Antidote+(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(1)", 3) }
                , GetItem("Antidote+(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(1)", 4) }
                , GetItem("Antidote+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(2)", 2) }
                , GetItem("Antidote+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(2)"), GetItem("Antidote+(1)") }
                , GetItem("Antidote+(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(3)"), GetItem("Antidote+(1)") }
                , GetItem("Antidote+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(4)") }
                , GetItem("Antidote+(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(3)") }
                , new List<Item>() { GetItem("Antidote+(2)"), GetItem("Antidote+(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(2)") }
                , GetItem("Antidote+(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(1)", 2) }
                , GetItem("Antifire potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(1)", 3) }
                , GetItem("Antifire potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(1)", 4) }
                , GetItem("Antifire potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(2)", 2) }
                , GetItem("Antifire potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(2)"), GetItem("Antifire potion(1)") }
                , GetItem("Antifire potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(3)"), GetItem("Antifire potion(1)") }
                , GetItem("Antifire potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(4)") }
                , GetItem("Antifire potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(3)") }
                , new List<Item>() { GetItem("Antifire potion(2)"), GetItem("Antifire potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(2)") }
                , GetItem("Antifire potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(1)", 2) }
                , GetItem("Ranging potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(1)", 3) }
                , GetItem("Ranging potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(1)", 4) }
                , GetItem("Ranging potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(2)", 2) }
                , GetItem("Ranging potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(2)"), GetItem("Ranging potion(1)") }
                , GetItem("Ranging potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(3)"), GetItem("Ranging potion(1)") }
                , GetItem("Ranging potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(4)") }
                , GetItem("Ranging potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(3)") }
                , new List<Item>() { GetItem("Ranging potion(2)"), GetItem("Ranging potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(2)") }
                , GetItem("Ranging potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(1)", 2) }
                , GetItem("Magic potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(1)", 3) }
                , GetItem("Magic potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(1)", 4) }
                , GetItem("Magic potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(2)", 2) }
                , GetItem("Magic potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(2)"), GetItem("Magic potion(1)") }
                , GetItem("Magic potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(3)"), GetItem("Magic potion(1)") }
                , GetItem("Magic potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(4)") }
                , GetItem("Magic potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(3)") }
                , new List<Item>() { GetItem("Magic potion(2)"), GetItem("Magic potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(2)") }
                , GetItem("Magic potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(1)", 2) }
                , GetItem("Stamina potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(1)", 3) }
                , GetItem("Stamina potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(1)", 4) }
                , GetItem("Stamina potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(2)", 2) }
                , GetItem("Stamina potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(2)"), GetItem("Stamina potion(1)") }
                , GetItem("Stamina potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(3)"), GetItem("Stamina potion(1)") }
                , GetItem("Stamina potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(4)") }
                , GetItem("Stamina potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(3)") }
                , new List<Item>() { GetItem("Stamina potion(2)"), GetItem("Stamina potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(2)") }
                , GetItem("Stamina potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(1)", 2) }
                , GetItem("Zamorak brew(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(1)", 3) }
                , GetItem("Zamorak brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(1)", 4) }
                , GetItem("Zamorak brew(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(2)", 2) }
                , GetItem("Zamorak brew(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(2)"), GetItem("Zamorak brew(1)") }
                , GetItem("Zamorak brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(3)"), GetItem("Zamorak brew(1)") }
                , GetItem("Zamorak brew(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(4)") }
                , GetItem("Zamorak brew(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(3)") }
                , new List<Item>() { GetItem("Zamorak brew(2)"), GetItem("Zamorak brew(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(2)") }
                , GetItem("Zamorak brew(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(1)", 2) }
                , GetItem("Antidote++(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(1)", 3) }
                , GetItem("Antidote++(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(1)", 4) }
                , GetItem("Antidote++(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(2)", 2) }
                , GetItem("Antidote++(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(2)"), GetItem("Antidote++(1)") }
                , GetItem("Antidote++(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(3)"), GetItem("Antidote++(1)") }
                , GetItem("Antidote++(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(4)") }
                , GetItem("Antidote++(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(3)") }
                , new List<Item>() { GetItem("Antidote++(2)"), GetItem("Antidote++(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote++(2)") }
                , GetItem("Antidote++(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(1)", 2) }
                , GetItem("Saradomin brew(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(1)", 3) }
                , GetItem("Saradomin brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(1)", 4) }
                , GetItem("Saradomin brew(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(2)", 2) }
                , GetItem("Saradomin brew(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(2)"), GetItem("Saradomin brew(1)") }
                , GetItem("Saradomin brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(3)"), GetItem("Saradomin brew(1)") }
                , GetItem("Saradomin brew(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(4)") }
                , GetItem("Saradomin brew(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(3)") }
                , new List<Item>() { GetItem("Saradomin brew(2)"), GetItem("Saradomin brew(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin brew(2)") }
                , GetItem("Saradomin brew(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (1)", 2) }
                , GetItem("Extended antifire (2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (1)", 3) }
                , GetItem("Extended antifire (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (1)", 4) }
                , GetItem("Extended antifire (4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (2)", 2) }
                , GetItem("Extended antifire (4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (2)"), GetItem("Extended antifire (1)") }
                , GetItem("Extended antifire (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (3)"), GetItem("Extended antifire (1)") }
                , GetItem("Extended antifire (4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (4)") }
                , GetItem("Extended antifire (2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (3)") }
                , new List<Item>() { GetItem("Extended antifire (2)"), GetItem("Extended antifire (1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (2)") }
                , GetItem("Extended antifire (1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(1)", 2) }
                , GetItem("Anti-venom(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(1)", 3) }
                , GetItem("Anti-venom(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(1)", 4) }
                , GetItem("Anti-venom(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(2)", 2) }
                , GetItem("Anti-venom(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(2)"), GetItem("Anti-venom(1)") }
                , GetItem("Anti-venom(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(3)"), GetItem("Anti-venom(1)") }
                , GetItem("Anti-venom(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(4)") }
                , GetItem("Anti-venom(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(3)") }
                , new List<Item>() { GetItem("Anti-venom(2)"), GetItem("Anti-venom(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom(2)") }
                , GetItem("Anti-venom(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(1)", 2) }
                , GetItem("Super combat potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(1)", 3) }
                , GetItem("Super combat potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(1)", 4) }
                , GetItem("Super combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(2)", 2) }
                , GetItem("Super combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(2)"), GetItem("Super combat potion(1)") }
                , GetItem("Super combat potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(3)"), GetItem("Super combat potion(1)") }
                , GetItem("Super combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(4)") }
                , GetItem("Super combat potion(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(3)") }
                , new List<Item>() { GetItem("Super combat potion(2)"), GetItem("Super combat potion(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Super combat potion(2)") }
                , GetItem("Super combat potion(1)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(1)", 2) }
                , GetItem("Anti-venom+(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(1)", 3) }
                , GetItem("Anti-venom+(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(1)", 4) }
                , GetItem("Anti-venom+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(2)", 2) }
                , GetItem("Anti-venom+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(2)"), GetItem("Anti-venom+(1)") }
                , GetItem("Anti-venom+(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(3)"), GetItem("Anti-venom+(1)") }
                , GetItem("Anti-venom+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(4)") }
                , GetItem("Anti-venom+(2)", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(3)") }
                , new List<Item>() { GetItem("Anti-venom+(2)"), GetItem("Anti-venom+(1)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Anti-venom+(2)") }
                , GetItem("Anti-venom+(1)", 2)),
        };
        #endregion

        #region Farming
        public List<CreationProcess> Farming = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Basket"), GetItem("Cooking apple", 5) }
                , GetItem("Apples(5)")),
            new CreationProcess(
                new List<Item>() { GetItem("Basket"), GetItem("Banana", 5) }
                , GetItem("Bananas(5)")),
            new CreationProcess(
                new List<Item>() { GetItem("Basket"), GetItem("Orange", 5) }
                , GetItem("Oranges(5)")),
            new CreationProcess(
                new List<Item>() { GetItem("Basket"), GetItem("Strawberry", 5) }
                , GetItem("Strawberries(5)")),
            new CreationProcess(
                new List<Item>() { GetItem("Basket"), GetItem("Tomato", 5) }
                , GetItem("Tomatoes(5)")),
            new CreationProcess(
                new List<Item>() { GetItem("Empty sack"), GetItem("Cabbage", 10) }
                , GetItem("Cabbages(10)")),
            new CreationProcess(
                new List<Item>() { GetItem("Empty sack"), GetItem("Onion", 10) }
                , GetItem("Onions(10)")),
            new CreationProcess(
                new List<Item>() { GetItem("Empty sack"), GetItem("Potato", 10) }
                , GetItem("Potatoes(10)")),
            new CreationProcess(
                new List<Item>() { GetItem("Compost"), GetItem("Compost potion(1)") }
                , GetItem("Supercompost")),
            new CreationProcess(
                new List<Item>() { GetItem("Compost", 2), GetItem("Compost potion(2)") }
                , GetItem("Supercompost", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Compost", 3), GetItem("Compost potion(3)") }
                , GetItem("Supercompost", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Compost", 4), GetItem("Compost potion(4)") }
                , GetItem("Supercompost", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Empty plant pot") }
                , GetItem("Filled plant pot")),
        };
        #endregion

        #region Fletching
        public List<CreationProcess> Fletching = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Logs") }
                , GetItem("Arrow shaft", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Feather") }
                , GetItem("Headless arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Wolf bones") }
                , GetItem("Wolfbone arrowtips")),
            new CreationProcess(
                new List<Item>() { GetItem("Logs") }
                , GetItem("Shortbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Logs") }
                , GetItem("Longbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Oak logs") }
                , GetItem("Oak shortbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Oak logs") }
                , GetItem("Oak longbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Willow logs") }
                , GetItem("Willow shortbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Willow logs") }
                , GetItem("Willow longbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Maple logs") }
                , GetItem("Maple shortbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Maple logs") }
                , GetItem("Maple longbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Yew logs") }
                , GetItem("Yew shortbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Yew logs") }
                , GetItem("Yew longbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic logs") }
                , GetItem("Magic shortbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic logs") }
                , GetItem("Magic longbow (u)")),
            new CreationProcess(
                new List<Item>() { GetItem("Longbow (u)"), GetItem("Bow string") }
                , GetItem("Longbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Oak longbow (u)"), GetItem("Bow string") }
                , GetItem("Oak longbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Willow longbow (u)"), GetItem("Bow string") }
                , GetItem("Willow longbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Maple longbow (u)"), GetItem("Bow string") }
                , GetItem("Maple longbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Yew longbow (u)"), GetItem("Bow string") }
                , GetItem("Yew longbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic longbow (u)"), GetItem("Bow string") }
                , GetItem("Magic longbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Shortbow (u)"), GetItem("Bow string") }
                , GetItem("Shortbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Oak shortbow (u)"), GetItem("Bow string") }
                , GetItem("Oak shortbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Willow shortbow (u)"), GetItem("Bow string") }
                , GetItem("Willow shortbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Maple shortbow (u)"), GetItem("Bow string") }
                , GetItem("Maple shortbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Yew shortbow (u)"), GetItem("Bow string") }
                , GetItem("Yew shortbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic shortbow (u)"), GetItem("Bow string") }
                , GetItem("Magic shortbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze crossbow (u)"), GetItem("Crossbow string") }
                , GetItem("Bronze crossbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron crossbow (u)"), GetItem("Crossbow string") }
                , GetItem("Iron crossbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel crossbow (u)"), GetItem("Crossbow string") }
                , GetItem("Steel crossbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril crossbow (u)"), GetItem("Crossbow string") }
                , GetItem("Mith crossbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant crossbow (u)"), GetItem("Crossbow string") }
                , GetItem("Adamant crossbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite crossbow (u)"), GetItem("Crossbow string") }
                , GetItem("Rune crossbow")),
            new CreationProcess(
                new List<Item>() { GetItem("Heavy frame"), GetItem("Ballista spring"),
                    GetItem("Ballista limbs"), GetItem("Monkey tail") }
                , GetItem("Heavy ballista")),
            new CreationProcess(
                new List<Item>() { GetItem("Light frame"), GetItem("Ballista spring"),
                    GetItem("Ballista limbs"), GetItem("Monkey tail") }
                , GetItem("Light ballista")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze arrowtips"), GetItem("Headless arrow") }
                , GetItem("Bronze arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron arrowtips"), GetItem("Headless arrow") }
                , GetItem("Iron arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel arrowtips"), GetItem("Headless arrow") }
                , GetItem("Steel arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril arrowtips"), GetItem("Headless arrow") }
                , GetItem("Mithril arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant arrowtips"), GetItem("Headless arrow") }
                , GetItem("Adamant arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune arrowtips"), GetItem("Headless arrow") }
                , GetItem("Rune arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon arrowtips"), GetItem("Headless arrow") }
                , GetItem("Dragon arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Wolfbone arrowtips"), GetItem("Flighted ogre arrow") }
                , GetItem("Ogre arrow")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Bronze bolts (unf)") }
                , GetItem("Bronze bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Iron bolts (unf)") }
                , GetItem("Iron bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Steel bolts (unf)") }
                , GetItem("Steel bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Mithril bolts (unf)") }
                , GetItem("Mithril bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Adamant bolts(unf)") }
                , GetItem("Adamant bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Runite bolts (unf)") }
                , GetItem("Runite bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Silver bolts (unf)") }
                , GetItem("Silver bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Unfinished broad bolts") }
                , GetItem("Broad bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Barb bolttips"), GetItem("Bronze bolts") }
                , GetItem("Barbed bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Opal bolt tips"), GetItem("Bronze bolts") }
                , GetItem("Opal bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Pearl bolt tips"), GetItem("Iron bolts") }
                , GetItem("Pearl bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Topaz bolt tips"), GetItem("Steel bolts") }
                , GetItem("Topaz bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Sapphire bolt tips"), GetItem("Mithril bolts") }
                , GetItem("Sapphire bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Emerald bolt tips"), GetItem("Mithril bolts") }
                , GetItem("Emerald bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Ruby bolt tips"), GetItem("Adamant bolts") }
                , GetItem("Ruby bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Diamond bolt tips"), GetItem("Adamant bolts") }
                , GetItem("Diamond bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon bolt tips"), GetItem("Runite bolts") }
                , GetItem("Dragon bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Onyx bolt tips"), GetItem("Runite bolts") }
                , GetItem("Onyx bolts")),
            new CreationProcess(
                new List<Item>() { GetItem("Mith grapple tip"), GetItem("Mithril bolts") }
                , GetItem(9418)),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Bronze dart tip") }
                , GetItem("Bronze dart")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Iron dart tip") }
                , GetItem("Iron dart")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Steel dart tip") }
                , GetItem("Steel dart")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Mithril dart tip") }
                , GetItem("Mithril dart")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Adamant dart tip") }
                , GetItem("Adamant dart")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Rune dart tip") }
                , GetItem("Rune dart")),
            new CreationProcess(
                new List<Item>() { GetItem("Feather"), GetItem("Dragon dart tip") }
                , GetItem("Dragon dart")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze javelin heads"), GetItem("Javelin shaft") }
                , GetItem("Bronze javelin")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron javelin heads"), GetItem("Javelin shaft") }
                , GetItem("Iron javelin")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel javelin heads"), GetItem("Javelin shaft") }
                , GetItem("Steel javelin")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril javelin heads"), GetItem("Javelin shaft") }
                , GetItem("Mithril javelin")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant javelin heads"), GetItem("Javelin shaft") }
                , GetItem("Adamant javelin")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune javelin heads"), GetItem("Javelin shaft") }
                , GetItem("Rune javelin")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon javelin heads"), GetItem("Javelin shaft") }
                , GetItem("Dragon javelin")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit spike") }
                , GetItem("Kebbit bolts", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Long kebbit spike") }
                , GetItem("Long kebbit bolts", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Tanzanite fang") }
                , GetItem("Toxic blowpipe (empty)")),
        };
        #endregion

        #region HerbCleaning
        public List<CreationProcess> HerbCleaning = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Grimy guam leaf")}
                , GetItem("Guam leaf")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy marrentill")}
                , GetItem("Marrentill")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy tarromin")}
                , GetItem("Tarromin")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy harralander")}
                , GetItem("Harralander")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy ranarr weed")}
                , GetItem("Ranarr weed")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy toadflax")}
                , GetItem("Toadflax")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy irit leaf")}
                , GetItem("Irit leaf")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy avantoe")}
                , GetItem("Avantoe")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy kwuarm")}
                , GetItem("Kwuarm")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy snapdragon")}
                , GetItem("Snapdragon")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy cadantine")}
                , GetItem("Cadantine")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy lantadyme")}
                , GetItem("Lantadyme")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy dwarf weed")}
                , GetItem("Dwarf weed")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy torstol")}
                , GetItem("Torstol")),
        };
        #endregion

        #region Herblore
        public List<CreationProcess> Herblore = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Eye of newt"), GetItem("Guam leaf"), GetItem("Vial of water") }
                , GetItem("Attack potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Eye of newt"), GetItem("Grimy guam leaf"), GetItem("Vial of water") }
                , GetItem("Attack potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Eye of newt"), GetItem("Guam potion (unf)") }
                , GetItem("Attack potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Unicorn horn dust"), GetItem("Marrentill"), GetItem("Vial of water") }
                , GetItem("Antipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Unicorn horn dust"), GetItem("Grimy marrentill"), GetItem("Vial of water") }
                , GetItem("Antipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Unicorn horn dust"), GetItem("Marrentill potion (unf)") }
                , GetItem("Antipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Limpwurt root"), GetItem("Tarromin"), GetItem("Vial of water") }
                , GetItem("Strength potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Limpwurt root"), GetItem("Grimy tarromin"), GetItem("Vial of water") }
                , GetItem("Strength potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Limpwurt root"), GetItem("Tarromin potion (unf)") }
                , GetItem("Strength potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ashes"), GetItem("Tarromin"), GetItem("Vial of water") }
                , GetItem("Serum 207 (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ashes"), GetItem("Grimy tarromin"), GetItem("Vial of water") }
                , GetItem("Serum 207 (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ashes"), GetItem("Tarromin potion (unf)") }
                , GetItem("Serum 207 (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guam leaf", 2), GetItem("Harralander"), GetItem("Marrentill"), GetItem("Cup of hot water") }
                , GetItem("Guthix rest(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy guam leaf", 2), GetItem("Grimy harralander"), GetItem("Grimy marrentill"), GetItem("Cup of hot water") }
                , GetItem("Guthix rest(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Guam leaf") }
                , GetItem("Guam tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Grimy guam leaf") }
                , GetItem("Guam tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Red spiders' eggs"), GetItem("Harralander"), GetItem("Vial of water") }
                , GetItem("Restore potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Red spiders' eggs"), GetItem("Grimy harralander"), GetItem("Vial of water") }
                , GetItem("Restore potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Red spiders' eggs"), GetItem("Harralander potion (unf)") }
                , GetItem("Restore potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Garlic"), GetItem("Silver dust"), GetItem("Restore potion(1)") }
                , GetItem("Guthix balance(1)")),
            new CreationProcess(
                new List<Item>() { GetItem("Garlic"), GetItem("Silver dust"), GetItem("Restore potion(2)") }
                , GetItem("Guthix balance(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Garlic"), GetItem("Silver dust"), GetItem("Restore potion(3)") }
                , GetItem("Guthix balance(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Garlic"), GetItem("Silver dust"), GetItem("Restore potion(4)") }
                , GetItem("Guthix balance(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Chocolate dust"), GetItem("Harralander"), GetItem("Vial of water") }
                , GetItem("Energy potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Chocolate dust"), GetItem("Grimy harralander"), GetItem("Vial of water") }
                , GetItem("Energy potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Chocolate dust"), GetItem("Harralander potion (unf)") }
                , GetItem("Energy potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("White berries"), GetItem("Ranarr weed"), GetItem("Vial of water") }
                , GetItem("Defence potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("White berries"), GetItem("Grimy ranarr weed"), GetItem("Vial of water") }
                , GetItem("Defence potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("White berries"), GetItem("Ranarr potion (unf)") }
                , GetItem("Defence potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Marrentill") }
                , GetItem("Marrentill tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Grimy marrentill") }
                , GetItem("Marrentill tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Toad's legs"), GetItem("Toadflax"), GetItem("Vial of water") }
                , GetItem("Agility potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Toad's legs"), GetItem("Grimy toadflax"), GetItem("Vial of water") }
                , GetItem("Agility potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Toad's legs"), GetItem("Toadflax potion (unf)") }
                , GetItem("Agility potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Goat horn dust"), GetItem("Harralander"), GetItem("Vial of water") }
                , GetItem("Combat potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Goat horn dust"), GetItem("Grimy harralander"), GetItem("Vial of water") }
                , GetItem("Combat potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Goat horn dust"), GetItem("Harralander potion (unf)") }
                , GetItem("Combat potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Snape grass"), GetItem("Ranarr weed"), GetItem("Vial of water") }
                , GetItem("Prayer potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Snape grass"), GetItem("Grimy ranarr weed"), GetItem("Vial of water") }
                , GetItem("Prayer potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Snape grass"), GetItem("Ranarr potion (unf)") }
                , GetItem("Prayer potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Tarromin") }
                , GetItem("Tarromin tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Grimy tarromin") }
                , GetItem("Tarromin tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Harralander") }
                , GetItem("Harralander tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Swamp tar", 15), GetItem("Grimy harralander") }
                , GetItem("Harralander tar")),
            new CreationProcess(
                new List<Item>() { GetItem("Eye of newt"), GetItem("Irit leaf"), GetItem("Vial of water") }
                , GetItem("Super attack(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Eye of newt"), GetItem("Grimy irit leaf"), GetItem("Vial of water") }
                , GetItem("Super attack(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Eye of newt"), GetItem("Irit potion (unf)") }
                , GetItem("Super attack(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Unicorn horn dust"), GetItem("Irit leaf"), GetItem("Vial of water") }
                , GetItem("Superantipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Unicorn horn dust"), GetItem("Grimy irit leaf"), GetItem("Vial of water") }
                , GetItem("Superantipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Unicorn horn dust"), GetItem("Irit potion (unf)") }
                , GetItem("Superantipoison(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Snape grass"), GetItem("Avantoe"), GetItem("Vial of water") }
                , GetItem("Fishing potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Snape grass"), GetItem("Grimy avantoe"), GetItem("Vial of water") }
                , GetItem("Fishing potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Snape grass"), GetItem("Avantoe potion (unf)") }
                , GetItem("Fishing potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mort myre fungus"), GetItem("Avantoe"), GetItem("Vial of water") }
                , GetItem("Super energy(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mort myre fungus"), GetItem("Grimy avantoe"), GetItem("Vial of water") }
                , GetItem("Super energy(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mort myre fungus"), GetItem("Avantoe potion (unf)") }
                , GetItem("Super energy(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit teeth dust"), GetItem("Avantoe"), GetItem("Vial of water") }
                , GetItem("Hunter potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit teeth dust"), GetItem("Grimy avantoe"), GetItem("Vial of water") }
                , GetItem("Hunter potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Kebbit teeth dust"), GetItem("Avantoe potion (unf)") }
                , GetItem("Hunter potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Limpwurt root"), GetItem("Kwuarm"), GetItem("Vial of water") }
                , GetItem("Super strength(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Limpwurt root"), GetItem("Grimy kwuarm"), GetItem("Vial of water") }
                , GetItem("Super strength(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Limpwurt root"), GetItem("Kwuarm potion (unf)") }
                , GetItem("Super strength(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragon scale"), GetItem("Kwuarm"), GetItem("Vial of water") }
                , GetItem("Weapon poison")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragon scale"), GetItem("Grimy kwuarm"), GetItem("Vial of water") }
                , GetItem("Weapon poison")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragon scale"), GetItem("Kwuarm potion (unf)") }
                , GetItem("Weapon poison")),
            new CreationProcess(
                new List<Item>() { GetItem("Red spiders' eggs"), GetItem("Snapdragon"), GetItem("Vial of water") }
                , GetItem("Super restore(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Red spiders' eggs"), GetItem("Grimy snapdragon"), GetItem("Vial of water") }
                , GetItem("Super restore(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Red spiders' eggs"), GetItem("Snapdragon potion (unf)") }
                , GetItem("Super restore(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("White berries"), GetItem("Cadantine"), GetItem("Vial of water") }
                , GetItem("Super defence(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("White berries"), GetItem("Grimy cadantine"), GetItem("Vial of water") }
                , GetItem("Super defence(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("White berries"), GetItem("Cadantine potion (unf)") }
                , GetItem("Super defence(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Yew roots"), GetItem("Toadflax"), GetItem("Coconut milk") }
                , GetItem("Antidote+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Yew roots"), GetItem("Grimy toadflax"), GetItem("Coconut milk") }
                , GetItem("Antidote+(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon scale dust"), GetItem("Lantadyme"), GetItem("Vial of water") }
                , GetItem("Antifire potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon scale dust"), GetItem("Grimy lantadyme"), GetItem("Vial of water") }
                , GetItem("Antifire potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon scale dust"), GetItem("Lantadyme potion (unf)") }
                , GetItem("Antifire potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Wine of Zamorak"), GetItem("Dwarf weed"), GetItem("Vial of water") }
                , GetItem("Ranging potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Wine of Zamorak"), GetItem("Grimy dwarf weed"), GetItem("Vial of water") }
                , GetItem("Ranging potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Wine of Zamorak"), GetItem("Dwarf weed potion (unf)") }
                , GetItem("Ranging potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Red spiders' eggs"), GetItem("Cactus spine"), GetItem("Coconut milk") }
                , GetItem("Weapon poison(+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Potato cactus"), GetItem("Lantadyme"), GetItem("Vial of water") }
                , GetItem("Magic potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Potato cactus"), GetItem("Grimy lantadyme"), GetItem("Vial of water") }
                , GetItem("Magic potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Potato cactus"), GetItem("Lantadyme potion (unf)") }
                , GetItem("Magic potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Amylase crystal"), GetItem("Super energy(1)") }
                , GetItem("Stamina potion(1)")),
            new CreationProcess(
                new List<Item>() { GetItem("Amylase crystal", 2), GetItem("Super energy(2)") }
                , GetItem("Stamina potion(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Amylase crystal", 3), GetItem("Super energy(3)") }
                , GetItem("Stamina potion(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Amylase crystal", 4), GetItem("Super energy(4)") }
                , GetItem("Stamina potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Jangerberries"), GetItem("Torstol"), GetItem("Vial of water") }
                , GetItem("Zamorak brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Jangerberries"), GetItem("Grimy torstol"), GetItem("Vial of water") }
                , GetItem("Zamorak brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Jangerberries"), GetItem("Torstol potion (unf)") }
                , GetItem("Zamorak brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic roots"), GetItem("Irit leaf"), GetItem("Coconut milk") }
                , GetItem("Antidote++(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic roots"), GetItem("Grimy irit leaf"), GetItem("Coconut milk") }
                , GetItem("Antidote++(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Crushed nest"), GetItem("Toadflax"), GetItem("Vial of water") }
                , GetItem("Saradomin brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Crushed nest"), GetItem("Grimy toadflax"), GetItem("Vial of water") }
                , GetItem("Saradomin brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Crushed nest"), GetItem("Toadflax potion (unf)") }
                , GetItem("Saradomin brew(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Lava scale shard"), GetItem("Antifire potion(1)") }
                , GetItem("Extended antifire (2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Lava scale shard", 2), GetItem("Antifire potion(2)") }
                , GetItem("Extended antifire (3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Lava scale shard", 3), GetItem("Antifire potion(3)") }
                , GetItem("Extended antifire (4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Lava scale shard", 4), GetItem("Antifire potion(4)") }
                , GetItem("Extended antifire (1)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zulrah's scales", 5), GetItem("Antidote++(1)") }
                , GetItem("Anti-venom(1)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zulrah's scales", 10), GetItem("Antidote++(2)") }
                , GetItem("Anti-venom(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zulrah's scales", 15), GetItem("Antidote++(3)") }
                , GetItem("Anti-venom(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zulrah's scales", 20), GetItem("Antidote++(4)") }
                , GetItem("Anti-venom(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Torstol"), GetItem("Super attack(4)"), GetItem("Super strength(4)"), GetItem("Super defence(4)") }
                , GetItem("Super combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy torstol"), GetItem("Super attack(4)"), GetItem("Super strength(4)"), GetItem("Super defence(4)") }
                , GetItem("Super combat potion(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Torstol"), GetItem("Anti-venom(1)") }
                , GetItem("Anti-venom+(1)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy torstol"), GetItem("Anti-venom(1)") }
                , GetItem("Anti-venom+(1)")),
        };
        #endregion

        #region Magic
        public List<CreationProcess> Magic = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Opal bolts", 10) }
                , GetItem("Opal bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Mind rune"), GetItem("Sapphire bolts", 10) }
                , GetItem("Sapphire bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Pearl bolts", 10) }
                , GetItem("Pearl bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Nature rune"), GetItem("Emerald bolts", 10) }
                , GetItem("Emerald bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Topaz bolts", 10) }
                , GetItem("Topaz bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Blood rune"), GetItem("Ruby bolts", 10) }
                , GetItem("Ruby bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Law rune", 2), GetItem("Diamond bolts", 10) }
                , GetItem("Diamond bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Soul rune"), GetItem("Dragon bolts", 10) }
                , GetItem("Dragon bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Death rune"), GetItem("Onyx bolts", 10) }
                , GetItem("Onyx bolts (e)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Soft clay") }
                , GetItem("Enchant sapphire or opal")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Sapphire ring") }
                , GetItem("Ring of recoil")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Sapphire necklace") }
                , GetItem("Games necklace(8)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Sapphire bracelet") }
                , GetItem("Bracelet of clay")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Sapphire amulet") }
                , GetItem("Amulet of magic")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Soft clay") }
                , GetItem("Enchant emerald or jade")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Emerald ring") }
                , GetItem("Ring of dueling(8)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Emerald necklace") }
                , GetItem("Binding necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Emerald bracelet") }
                , GetItem("Castle wars bracelet(3)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Emerald amulet") }
                , GetItem("Amulet of defence")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Soft clay") }
                , GetItem("Enchant ruby or topaz")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Ruby ring") }
                , GetItem("Ring of forging")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Ruby bracelet") }
                , GetItem("Inoculation bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Ruby amulet") }
                , GetItem("Amulet of strength")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Soft clay") }
                , GetItem("Enchant diamond")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Diamond ring") }
                , GetItem("Ring of life")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Diamond necklace") }
                , GetItem("Phoenix necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Diamond bracelet") }
                , GetItem("Abyssal bracelet(5)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Diamond amulet") }
                , GetItem("Amulet of power")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Soft clay") }
                , GetItem("Enchant dragonstn.")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Dragonstone ring") }
                , GetItem("Ring of wealth (5)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Dragon necklace") }
                , GetItem("Skills necklace(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Dragonstone bracelet") }
                , GetItem("Combat bracelet(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Dragonstone amulet") }
                , GetItem("Amulet of glory(4)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Soft clay") }
                , GetItem("Enchant onyx")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Onyx ring") }
                , GetItem("Ring of stone")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Onyx necklace") }
                , GetItem("Berserker necklace")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Onyx bracelet") }
                , GetItem("Regen bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Onyx amulet") }
                , GetItem("Amulet of fury")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Blood rune", 20), GetItem("Soul rune", 20), GetItem("Zenyte ring") }
                , GetItem("Ring of suffering")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Blood rune", 20), GetItem("Soul rune", 20), GetItem("Zenyte necklace") }
                , GetItem("Necklace of anguish")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Blood rune", 20), GetItem("Soul rune", 20), GetItem("Zenyte bracelet") }
                , GetItem("Tormented bracelet")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune"), GetItem("Blood rune", 20), GetItem("Soul rune", 20), GetItem("Zenyte amulet") }
                , GetItem("Amulet of torture")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune", 3), GetItem("Unpowered orb") }
                , GetItem("Water orb")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune", 3), GetItem("Unpowered orb") }
                , GetItem("Earth orb")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune", 3), GetItem("Unpowered orb") }
                , GetItem("Fire orb")),
            new CreationProcess(
                new List<Item>() { GetItem("Cosmic rune", 3), GetItem("Unpowered orb") }
                , GetItem("Air orb")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Soft clay") }
                , GetItem("Bones to bananas")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Bones", 27) }
                , GetItem("Banana", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune", 2), GetItem("Soft clay") }
                , GetItem("Bones to peaches")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Tin ore"), GetItem("Copper ore") }
                , GetItem("Bronze bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Iron ore") }
                , GetItem("Iron bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Silver ore") }
                , GetItem("Silver bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Iron ore"), GetItem("Coal", 2) }
                , GetItem("Steel bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Gold ore") }
                , GetItem("Gold bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Mithril ore"), GetItem("Coal", 4) }
                , GetItem("Mithril bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Adamantite ore"), GetItem("Coal", 6) }
                , GetItem("Adamantite bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Runite ore"), GetItem("Coal", 8) }
                , GetItem("Runite bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Uncooked berry pie", 27) }
                , GetItem("Redberry pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Uncooked meat pie", 27) }
                , GetItem("Meat pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Raw mud pie", 27) }
                , GetItem("Mud pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Uncooked apple pie", 27) }
                , GetItem("Apple pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Raw garden pie", 27) }
                , GetItem("Garden pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Raw fish pie", 27) }
                , GetItem("Fish pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Uncooked botanical pie", 27) }
                , GetItem("Botanical pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Raw admiral pie", 27) }
                , GetItem("Admiral pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Raw wild pie", 27) }
                , GetItem("Wild pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Raw summer pie", 27) }
                , GetItem("Summer pie", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Bucket", 27) }
                , GetItem("Bucket of water", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Jug", 27) }
                , GetItem("Jug of water", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Vial", 27) }
                , GetItem("Vial of water", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Waterskin(0)", 27) }
                , GetItem("Waterskin(4)", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Bowl", 27) }
                , GetItem("Bowl of water", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Empty cup", 27) }
                , GetItem("Cup of water", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Clay", 27) }
                , GetItem("Soft clay", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2) }
                , new List<Item>() { GetItem("Box trap"), GetItem("Impling jar") }),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Bucket of sand", 13), GetItem("Soda ash", 13) }
                , GetItem("Molten glass", 13)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Cowhide", 5) }
                , GetItem("Leather", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Cowhide", 5) }
                , GetItem("Hard leather", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Green dragonhide", 5) }
                , GetItem("Green dragon leather", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Blue dragonhide", 5) }
                , GetItem("Blue dragon leather", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Red dragonhide", 5) }
                , GetItem("Red dragon leather", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Black dragonhide", 5) }
                , GetItem("Black dragon leather", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Snake hide", 5) }
                , GetItem("Snakeskin", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Astral rune", 2), GetItem("Yak-hide", 5) }
                , GetItem("Cured yak-hide", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Gold amulet (u)", 27) }
                , GetItem("Gold amulet", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Sapphire amulet (u)", 27) }
                , GetItem("Sapphire amulet", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Emerald amulet (u)", 27) }
                , GetItem("Emerald amulet", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Ruby amulet (u)", 27) }
                , GetItem("Ruby amulet", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Diamond amulet (u)", 27) }
                , GetItem("Diamond amulet", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Onyx amulet (u)", 27) }
                , GetItem("Onyx amulet", 27)),
            /*new CreationProcess( Not currently in OS Buddy DB
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Zenyte amulet (u)", 27) }
                , GetItem("Zenyte amulet", 27)),*/
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Unstrung emblem", 27) }
                , GetItem("Unblessed symbol", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Unstrung symbol", 27) }
                , GetItem("Unpowered symbol", 27)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Nature rune", 1), GetItem("Coins", 70), GetItem("Logs") }
                , GetItem("Plank")),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Nature rune", 1), GetItem("Coins", 175), GetItem("Oak logs") }
                , GetItem("Oak plank")),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Nature rune", 1), GetItem("Coins", 350), GetItem("Teak logs") }
                , GetItem("Teak plank")),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune", 2), GetItem("Nature rune", 1), GetItem("Coins", 1050), GetItem("Mahogany logs") }
                , GetItem("Mahogany plank")),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Soul rune"), GetItem("Amulet of glory", 26) }
                , GetItem("Amulet of glory(4)", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Soul rune"), GetItem("Combat bracelet", 26) }
                , GetItem("Combat bracelet(4)", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Astral rune"), GetItem("Soul rune"), GetItem("Skills necklace", 26) }
                , GetItem("Skills necklace(4)", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune"), GetItem("Soft clay") }
                , GetItem("Varrock teleport")),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune"), GetItem("Soft clay") }
                , GetItem("Lumbridge teleport")),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune"), GetItem("Soft clay") }
                , GetItem("Falador teleport")),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune"), GetItem("Soft clay") }
                , GetItem("Camelot teleport")),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune", 2), GetItem("Soft clay") }
                , GetItem("Ardougne teleport")),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune", 2), GetItem("Soft clay") }
                , GetItem("Watchtower teleport")),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune"), GetItem("Soft clay") }
                , GetItem("Teleport to house")),
            new CreationProcess(
                new List<Item>() { GetItem("Law rune"), GetItem("Soft clay") }
                , GetItem("Varrock teleport")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranger Boots"), GetItem("Pegasian Crystal") }
                , GetItem("Pegasian Boots")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon Boots"), GetItem("Primordial Crystal") }
                , GetItem("Primordial Boots")),
            new CreationProcess(
                new List<Item>() { GetItem("Infinity Boots"), GetItem("Eternal Crystal") }
                , GetItem("Eternal Boots")),
        };
        #endregion

        #region Mix
        public List<CreationProcess> Mix = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(2)"), GetItem("Roe") }
                , GetItem("Attack mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(2)"), GetItem("Caviar") }
                , GetItem("Attack mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(2)"), GetItem("Roe") }
                , GetItem("Antipoison mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antipoison(2)"), GetItem("Caviar") }
                , GetItem("Antipoison mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(2)"), GetItem("Roe") }
                , GetItem("Strength mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Strength potion(2)"), GetItem("Caviar") }
                , GetItem("Strength mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(2)"), GetItem("Roe") }
                , GetItem("Restore mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Restore potion(2)"), GetItem("Caviar") }
                , GetItem("Restore mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Energy potion(2)"), GetItem("Caviar") }
                , GetItem("Energy mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Defence potion(2)"), GetItem("Caviar") }
                , GetItem("Defence mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Agility potion(2)"), GetItem("Caviar") }
                , GetItem("Agility mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion(2)"), GetItem("Caviar") }
                , GetItem("Combat mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Prayer potion(2)"), GetItem("Caviar") }
                , GetItem("Prayer mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(2)"), GetItem("Caviar") }
                , GetItem("Superattack mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Superantipoison(2)"), GetItem("Caviar") }
                , GetItem("Anti-poison supermix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Fishing potion(2)"), GetItem("Caviar") }
                , GetItem("Fishing mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super energy(2)"), GetItem("Caviar") }
                , GetItem("Super energy mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Hunter potion(2)"), GetItem("Caviar") }
                , GetItem("Hunting mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super strength(2)"), GetItem("Caviar") }
                , GetItem("Super str. mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super restore(2)"), GetItem("Caviar") }
                , GetItem("Super restore mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Super defence(2)"), GetItem("Caviar") }
                , GetItem("Super def. mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antidote+(2)"), GetItem("Caviar") }
                , GetItem("Antidote+ mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Antifire potion(2)"), GetItem("Caviar") }
                , GetItem("Antifire mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranging potion(2)"), GetItem("Caviar") }
                , GetItem("Ranging mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Magic potion(2)"), GetItem("Caviar") }
                , GetItem("Magic mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak brew(2)"), GetItem("Caviar") }
                , GetItem("Zamorak mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Stamina potion(2)"), GetItem("Caviar") }
                , GetItem("Stamina mix(2)")),
            new CreationProcess(
                new List<Item>() { GetItem("Extended antifire (2)"), GetItem("Caviar") }
                , GetItem("Extended antifire mix(2)")),
        };
        #endregion

        #region Poisons
        public List<CreationProcess> Poisons = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Abyssal dagger"), GetItem("Weapon poison") }
                , GetItem("Abyssal dagger (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant arrow"), GetItem("Weapon poison") }
                , GetItem("Adamant arrow(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant bolts"), GetItem("Weapon poison") }
                , GetItem("Adamant bolts (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant dagger"), GetItem("Weapon poison") }
                , GetItem("Adamant dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant dart"), GetItem("Weapon poison") }
                , GetItem("Adamant dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant hasta"), GetItem("Weapon poison") }
                , GetItem("Adamant hasta(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant javelin"), GetItem("Weapon poison") }
                , GetItem("Adamant javelin(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant knife"), GetItem("Weapon poison") }
                , GetItem("Adamant knife(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant spear"), GetItem("Weapon poison") }
                , GetItem("Adamant spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dagger"), GetItem("Weapon poison") }
                , GetItem("Black dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dart"), GetItem("Weapon poison") }
                , GetItem("Black dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black knife"), GetItem("Weapon poison") }
                , GetItem("Black knife(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black spear"), GetItem("Weapon poison") }
                , GetItem("Black spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bone dagger"), GetItem("Weapon poison") }
                , GetItem("Bone dagger (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze arrow"), GetItem("Weapon poison") }
                , GetItem("Bronze arrow(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bolts"), GetItem("Weapon poison") }
                , GetItem("Bronze bolts(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze dagger"), GetItem("Weapon poison") }
                , GetItem("Bronze dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze dart"), GetItem("Weapon poison") }
                , GetItem("Bronze dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze hasta"), GetItem("Weapon poison") }
                , GetItem("Bronze hasta(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze javelin"), GetItem("Weapon poison") }
                , GetItem("Bronze javelin(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze knife"), GetItem("Weapon poison") }
                , GetItem("Bronze knife(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze spear"), GetItem("Weapon poison") }
                , GetItem("Bronze spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon arrow"), GetItem("Weapon poison") }
                , GetItem("Dragon arrow(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon dagger"), GetItem("Weapon poison") }
                , GetItem("Dragon dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon dart"), GetItem("Weapon poison") }
                , GetItem("Dragon dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon javelin"), GetItem("Weapon poison") }
                , GetItem("Dragon javelin(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon spear"), GetItem("Weapon poison") }
                , GetItem("Dragon spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron arrow"), GetItem("Weapon poison") }
                , GetItem("Iron arrow(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bolts"), GetItem("Weapon poison") }
                , GetItem("Iron bolts (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron dagger"), GetItem("Weapon poison") }
                , GetItem("Iron dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron dart"), GetItem("Weapon poison") }
                , GetItem("Iron dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron hasta"), GetItem("Weapon poison") }
                , GetItem("Iron hasta(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron javelin"), GetItem("Weapon poison") }
                , GetItem("Iron javelin(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron knife"), GetItem("Weapon poison") }
                , GetItem("Iron knife(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron spear"), GetItem("Weapon poison") }
                , GetItem("Iron spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril arrow"), GetItem("Weapon poison") }
                , GetItem("Mithril arrow(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bolts"), GetItem("Weapon poison") }
                , GetItem("Mithril bolts (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril dagger"), GetItem("Weapon poison") }
                , GetItem("Mithril dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril dart"), GetItem("Weapon poison") }
                , GetItem("Mithril dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril hasta"), GetItem("Weapon poison") }
                , GetItem("Mithril hasta(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril javelin"), GetItem("Weapon poison") }
                , GetItem("Mithril javelin(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril knife"), GetItem("Weapon poison") }
                , GetItem("Mithril knife(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril spear"), GetItem("Weapon poison") }
                , GetItem("Mithril spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune arrow"), GetItem("Weapon poison") }
                , GetItem("Rune arrow(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune dagger"), GetItem("Weapon poison") }
                , GetItem("Rune dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune dart"), GetItem("Weapon poison") }
                , GetItem("Rune dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune hasta"), GetItem("Weapon poison") }
                , GetItem("Rune hasta(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune javelin"), GetItem("Weapon poison") }
                , GetItem("Rune javelin(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune knife"), GetItem("Weapon poison") }
                , GetItem("Rune knife(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune spear"), GetItem("Weapon poison") }
                , GetItem("Rune spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bolts"), GetItem("Weapon poison") }
                , GetItem("Runite bolts (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Silver bolts"), GetItem("Weapon poison") }
                , GetItem("Silver bolts (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel arrow"), GetItem("Weapon poison") }
                , GetItem("Steel arrow(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bolts"), GetItem("Weapon poison") }
                , GetItem("Steel bolts (p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel dagger"), GetItem("Weapon poison") }
                , GetItem("Steel dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel dart"), GetItem("Weapon poison") }
                , GetItem("Steel dart(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel hasta"), GetItem("Weapon poison") }
                , GetItem("Steel hasta(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel javelin"), GetItem("Weapon poison") }
                , GetItem("Steel javelin(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel knife"), GetItem("Weapon poison") }
                , GetItem("Steel knife(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel spear"), GetItem("Weapon poison") }
                , GetItem("Steel spear(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("White dagger"), GetItem("Weapon poison") }
                , GetItem("White dagger(p)")),
            new CreationProcess(
                new List<Item>() { GetItem("Abyssal dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Abyssal dagger (p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant arrow"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant arrow(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant bolts"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant bolts(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant dart"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant hasta"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant hasta(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant javelin"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant javelin(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant knife"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant knife(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant spear"), GetItem("Weapon poison(+)") }
                , GetItem("Adamant spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Black dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dart"), GetItem("Weapon poison(+)") }
                , GetItem("Black dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black knife"), GetItem("Weapon poison(+)") }
                , GetItem("Black knife(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black spear"), GetItem("Weapon poison(+)") }
                , GetItem("Black spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bone dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Bone dagger (p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze arrow"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze arrow(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bolts"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze bolts(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze dart"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze hasta"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze hasta(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze javelin"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze javelin(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze knife"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze knife(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze spear"), GetItem("Weapon poison(+)") }
                , GetItem("Bronze spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon arrow"), GetItem("Weapon poison(+)") }
                , GetItem("Dragon arrow(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Dragon dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon dart"), GetItem("Weapon poison(+)") }
                , GetItem("Dragon dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon javelin"), GetItem("Weapon poison(+)") }
                , GetItem("Dragon javelin(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon spear"), GetItem("Weapon poison(+)") }
                , GetItem("Dragon spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron arrow"), GetItem("Weapon poison(+)") }
                , GetItem("Iron arrow(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bolts"), GetItem("Weapon poison(+)") }
                , GetItem("Iron bolts(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Iron dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron dart"), GetItem("Weapon poison(+)") }
                , GetItem("Iron dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron hasta"), GetItem("Weapon poison(+)") }
                , GetItem("Iron hasta(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron javelin"), GetItem("Weapon poison(+)") }
                , GetItem("Iron javelin(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron knife"), GetItem("Weapon poison(+)") }
                , GetItem("Iron knife(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron spear"), GetItem("Weapon poison(+)") }
                , GetItem("Iron spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril arrow"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril arrow(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bolts"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril bolts(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril dart"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril hasta"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril hasta(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril javelin"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril javelin(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril knife"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril knife(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril spear"), GetItem("Weapon poison(+)") }
                , GetItem("Mithril spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune arrow"), GetItem("Weapon poison(+)") }
                , GetItem("Rune arrow(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Rune dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune dart"), GetItem("Weapon poison(+)") }
                , GetItem("Rune dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune hasta"), GetItem("Weapon poison(+)") }
                , GetItem("Rune hasta(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune javelin"), GetItem("Weapon poison(+)") }
                , GetItem("Rune javelin(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune knife"), GetItem("Weapon poison(+)") }
                , GetItem("Rune knife(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune spear"), GetItem("Weapon poison(+)") }
                , GetItem("Rune spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bolts"), GetItem("Weapon poison(+)") }
                , GetItem("Runite bolts(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Silver bolts"), GetItem("Weapon poison(+)") }
                , GetItem("Silver bolts(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel arrow"), GetItem("Weapon poison(+)") }
                , GetItem("Steel arrow(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bolts"), GetItem("Weapon poison(+)") }
                , GetItem("Steel bolts(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel dagger"), GetItem("Weapon poison(+)") }
                , GetItem("Steel dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel dart"), GetItem("Weapon poison(+)") }
                , GetItem("Steel dart(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel hasta"), GetItem("Weapon poison(+)") }
                , GetItem("Steel hasta(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel javelin"), GetItem("Weapon poison(+)") }
                , GetItem("Steel javelin(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel knife"), GetItem("Weapon poison(+)") }
                , GetItem("Steel knife(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel spear"), GetItem("Weapon poison(+)") }
                , GetItem("Steel spear(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("White dagger"), GetItem("Weapon poison(+)") }
                , GetItem("White dagger(p+)")),
            new CreationProcess(
                new List<Item>() { GetItem("Abyssal dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Abyssal dagger (p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant arrow"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant arrow(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant bolts"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant bolts(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant dart"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant hasta"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant hasta(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant javelin"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant javelin(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant knife"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant knife(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant spear"), GetItem("Weapon poison(++)") }
                , GetItem("Adamant spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Black dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black dart"), GetItem("Weapon poison(++)") }
                , GetItem("Black dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black knife"), GetItem("Weapon poison(++)") }
                , GetItem("Black knife(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black spear"), GetItem("Weapon poison(++)") }
                , GetItem("Black spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bone dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Bone dagger (p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze arrow"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze arrow(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bolts"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze bolts(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze dart"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze hasta"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze hasta(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze javelin"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze javelin(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze knife"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze knife(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze spear"), GetItem("Weapon poison(++)") }
                , GetItem("Bronze spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon arrow"), GetItem("Weapon poison(++)") }
                , GetItem("Dragon arrow(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Dragon dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon dart"), GetItem("Weapon poison(++)") }
                , GetItem("Dragon dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon javelin"), GetItem("Weapon poison(++)") }
                , GetItem("Dragon javelin(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon spear"), GetItem("Weapon poison(++)") }
                , GetItem("Dragon spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron arrow"), GetItem("Weapon poison(++)") }
                , GetItem("Iron arrow(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bolts"), GetItem("Weapon poison(++)") }
                , GetItem("Iron bolts(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Iron dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron dart"), GetItem("Weapon poison(++)") }
                , GetItem("Iron dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron hasta"), GetItem("Weapon poison(++)") }
                , GetItem("Iron hasta(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron javelin"), GetItem("Weapon poison(++)") }
                , GetItem("Iron javelin(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron knife"), GetItem("Weapon poison(++)") }
                , GetItem("Iron knife(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron spear"), GetItem("Weapon poison(++)") }
                , GetItem("Iron spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril arrow"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril arrow(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bolts"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril bolts(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril dart"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril hasta"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril hasta(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril javelin"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril javelin(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril knife"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril knife(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril spear"), GetItem("Weapon poison(++)") }
                , GetItem("Mithril spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune arrow"), GetItem("Weapon poison(++)") }
                , GetItem("Rune arrow(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Rune dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune dart"), GetItem("Weapon poison(++)") }
                , GetItem("Rune dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune hasta"), GetItem("Weapon poison(++)") }
                , GetItem("Rune hasta(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune javelin"), GetItem("Weapon poison(++)") }
                , GetItem("Rune javelin(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune knife"), GetItem("Weapon poison(++)") }
                , GetItem("Rune knife(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune spear"), GetItem("Weapon poison(++)") }
                , GetItem("Rune spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bolts"), GetItem("Weapon poison(++)") }
                , GetItem("Runite bolts(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Silver bolts"), GetItem("Weapon poison(++)") }
                , GetItem("Silver bolts(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel arrow"), GetItem("Weapon poison(++)") }
                , GetItem("Steel arrow(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bolts"), GetItem("Weapon poison(++)") }
                , GetItem("Steel bolts(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel dagger"), GetItem("Weapon poison(++)") }
                , GetItem("Steel dagger(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel dart"), GetItem("Weapon poison(++)") }
                , GetItem("Steel dart(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel hasta"), GetItem("Weapon poison(++)") }
                , GetItem("Steel hasta(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel javelin"), GetItem("Weapon poison(++)") }
                , GetItem("Steel javelin(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel knife"), GetItem("Weapon poison(++)") }
                , GetItem("Steel knife(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel spear"), GetItem("Weapon poison(++)") }
                , GetItem("Steel spear(p++)")),
            new CreationProcess(
                new List<Item>() { GetItem("White dagger"), GetItem("Weapon poison(++)") }
                , GetItem("White dagger(p++)")),
        };
        #endregion

        #region Prayer
        public List<CreationProcess> Prayer = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Spirit shield"), GetItem("Holy Elixir") }
                , GetItem("Blessed spirit shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Elysian sigil"), GetItem("Blessed spirit shield")}
                , GetItem("Elysian spirit shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Arcane sigil"), GetItem("Blessed spirit shield")}
                , GetItem("Arcane spirit shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Spectral sigil"), GetItem("Blessed spirit shield")}
                , GetItem("Spectral spirit shield")),
        };
        #endregion

        #region Sets
        public List<CreationProcess> Sets = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Cannon base"), GetItem("Cannon stand"), GetItem("Cannon barrels"), GetItem("Cannon furnace") }
                , GetItem("Dwarf cannon set")),
            new CreationProcess(
                new List<Item>() { GetItem("Green d'hide body"), GetItem("Green d'hide chaps"), GetItem("Green d'hide vamb") }
                , GetItem("Green dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Blue d'hide body"), GetItem("Blue d'hide chaps"), GetItem("Blue d'hide vamb") }
                , GetItem("Blue dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Red d'hide body"), GetItem("Red d'hide chaps"), GetItem("Red d'hide vamb") }
                , GetItem("Red dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Black d'hide body"), GetItem("Black d'hide chaps"), GetItem("Black d'hide vamb") }
                , GetItem("Black dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Ahrim's hood"), GetItem("Ahrim's robetop"), GetItem("Ahrim's robeskirt"), GetItem("Ahrim's staff") }
                , GetItem("Ahrim's armour set")),
            new CreationProcess(
                new List<Item>() { GetItem("Dharok's helm"), GetItem("Dharok's platebody"), GetItem("Dharok's platelegs"), GetItem("Dharok's greataxe") }
                , GetItem("Dharok's armour set")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthan's helm"), GetItem("Guthan's platebody"), GetItem("Guthan's chainskirt"), GetItem("Guthan's warspear") }
                , GetItem("Guthan's armour set")),
            new CreationProcess(
                new List<Item>() { GetItem("Karil's coif"), GetItem("Karil's leathertop"), GetItem("Karil's leatherskirt"), GetItem("Karil's crossbow") }
                , GetItem("Karil's armour set")),
            new CreationProcess(
                new List<Item>() { GetItem("Torag's helm"), GetItem("Torag's platebody"), GetItem("Torag's platelegs"), GetItem("Torag's hammers") }
                , GetItem("Torag's armour set")),
            new CreationProcess(
                new List<Item>() { GetItem("Verac's helm"), GetItem("Verac's brassard"), GetItem("Verac's plateskirt"), GetItem("Verac's flail") }
                , GetItem("Verac's armour set")),
            new CreationProcess(
                new List<Item>() { GetItem("Attack potion(4)"), GetItem("Defence potion(4)"), GetItem("Strength potion(4)") }
                , GetItem("Combat potion set")),
            new CreationProcess(
                new List<Item>() { GetItem("Super attack(4)"), GetItem("Super defence(4)"), GetItem("Super strength(4)") }
                , GetItem("Super potion set")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze full helm"), GetItem("Bronze platebody"), GetItem("Bronze platelegs"), GetItem("Bronze kiteshield") }
                , GetItem("Bronze set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze full helm"), GetItem("Bronze platebody"), GetItem("Bronze plateskirt"), GetItem("Bronze kiteshield") }
                , GetItem("Bronze set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron full helm"), GetItem("Iron platebody"), GetItem("Iron platelegs"), GetItem("Iron kiteshield") }
                , GetItem("Iron set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron full helm"), GetItem("Iron platebody"), GetItem("Iron plateskirt"), GetItem("Iron kiteshield") }
                , GetItem("Iron set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel full helm"), GetItem("Steel platebody"), GetItem("Steel platelegs"), GetItem("Steel kiteshield") }
                , GetItem("Steel set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel full helm"), GetItem("Steel platebody"), GetItem("Steel plateskirt"), GetItem("Steel kiteshield") }
                , GetItem("Steel set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black full helm"), GetItem("Black platebody"), GetItem("Black platelegs"), GetItem("Black kiteshield") }
                , GetItem("Black set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black full helm"), GetItem("Black platebody"), GetItem("Black plateskirt"), GetItem("Black kiteshield") }
                , GetItem("Black set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril full helm"), GetItem("Mithril platebody"), GetItem("Mithril platelegs"), GetItem("Mithril kiteshield") }
                , GetItem("Mithril set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril full helm"), GetItem("Mithril platebody"), GetItem("Mithril plateskirt"), GetItem("Mithril kiteshield") }
                , GetItem("Mithril set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant full helm"), GetItem("Adamant platebody"), GetItem("Adamant platelegs"), GetItem("Adamant kiteshield") }
                , GetItem("Adamant set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant full helm"), GetItem("Adamant platebody"), GetItem("Adamant plateskirt"), GetItem("Adamant kiteshield") }
                , GetItem("Adamant set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune full helm"), GetItem("Rune platebody"), GetItem("Rune platelegs"), GetItem("Rune kiteshield") }
                , GetItem("Rune armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune full helm"), GetItem("Rune platebody"), GetItem("Rune plateskirt"), GetItem("Rune kiteshield") }
                , GetItem("Rune armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze full helm (t)"), GetItem("Bronze platebody (t)"), GetItem("Bronze platelegs (t)"), GetItem("Bronze kiteshield (t)") }
                , GetItem("Bronze trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze full helm (t)"), GetItem("Bronze platebody (t)"), GetItem("Bronze plateskirt (t)"), GetItem("Bronze kiteshield (t)") }
                , GetItem("Bronze trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze full helm (g)"), GetItem("Bronze platebody (g)"), GetItem("Bronze platelegs (g)"), GetItem("Bronze kiteshield (g)") }
                , GetItem("Bronze gold-trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze full helm (g)"), GetItem("Bronze platebody (g)"), GetItem("Bronze plateskirt (g)"), GetItem("Bronze kiteshield (g)") }
                , GetItem("Bronze gold-trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron full helm (t)"), GetItem("Iron platebody (t)"), GetItem("Iron platelegs (t)"), GetItem("Iron kiteshield (t)") }
                , GetItem("Iron trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron full helm (t)"), GetItem("Iron platebody (t)"), GetItem("Iron plateskirt (t)"), GetItem("Iron kiteshield (t)") }
                , GetItem("Iron trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron full helm (g)"), GetItem("Iron platebody (g)"), GetItem("Iron platelegs (g)"), GetItem("Iron kiteshield (g)") }
                , GetItem("Iron gold-trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron full helm (g)"), GetItem("Iron platebody (g)"), GetItem("Iron plateskirt (g)"), GetItem("Iron kiteshield (g)") }
                , GetItem("Iron gold-trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black full helm (t)"), GetItem("Black platebody (t)"), GetItem("Black platelegs (t)"), GetItem("Black kiteshield (t)") }
                , GetItem("Black trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black full helm (t)"), GetItem("Black platebody (t)"), GetItem("Black plateskirt (t)"), GetItem("Black kiteshield (t)") }
                , GetItem("Black trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black full helm (g)"), GetItem("Black platebody (g)"), GetItem("Black platelegs (g)"), GetItem("Black kiteshield (g)") }
                , GetItem("Black gold-trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Black full helm (g)"), GetItem("Black platebody (g)"), GetItem("Black plateskirt (g)"), GetItem("Black kiteshield (g)") }
                , GetItem("Black gold-trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril full helm (t)"), GetItem("Mithril platebody (t)"), GetItem("Mithril platelegs (t)"), GetItem("Mithril kiteshield (t)") }
                , GetItem("Mithril trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril full helm (t)"), GetItem("Mithril platebody (t)"), GetItem("Mithril plateskirt (t)"), GetItem("Mithril kiteshield (t)") }
                , GetItem("Mithril trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril full helm (g)"), GetItem("Mithril platebody (g)"), GetItem("Mithril platelegs (g)"), GetItem("Mithril kiteshield (g)") }
                , GetItem("Mithril gold-trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril full helm (g)"), GetItem("Mithril platebody (g)"), GetItem("Mithril plateskirt (g)"), GetItem("Mithril kiteshield (g)") }
                , GetItem("Mithril gold-trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant full helm (t)"), GetItem("Adamant platebody (t)"), GetItem("Adamant platelegs (t)"), GetItem("Adamant kiteshield (t)") }
                , GetItem("Adamant trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant full helm (t)"), GetItem("Adamant platebody (t)"), GetItem("Adamant plateskirt (t)"), GetItem("Adamant kiteshield (t)") }
                , GetItem("Adamant trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant full helm (g)"), GetItem("Adamant platebody (g)"), GetItem("Adamant platelegs (g)"), GetItem("Adamant kiteshield (g)") }
                , GetItem("Adamant gold-trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant full helm (g)"), GetItem("Adamant platebody (g)"), GetItem("Adamant plateskirt (g)"), GetItem("Adamant kiteshield (g)") }
                , GetItem("Adamant gold-trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune full helm (t)"), GetItem("Rune platebody (t)"), GetItem("Rune platelegs (t)"), GetItem("Rune kiteshield (t)") }
                , GetItem("Rune trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune full helm (t)"), GetItem("Rune platebody (t)"), GetItem("Rune plateskirt (t)"), GetItem("Rune kiteshield (t)") }
                , GetItem("Rune trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune full helm (g)"), GetItem("Rune platebody (g)"), GetItem("Rune platelegs (g)"), GetItem("Rune kiteshield (g)") }
                , GetItem("Rune gold-trimmed set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune full helm (g)"), GetItem("Rune platebody (g)"), GetItem("Rune plateskirt (g)"), GetItem("Rune kiteshield (g)") }
                , GetItem("Rune gold-trimmed set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin full helm"), GetItem("Saradomin platebody"), GetItem("Saradomin platelegs"), GetItem("Saradomin kiteshield") }
                , GetItem("Saradomin armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin full helm"), GetItem("Saradomin platebody"), GetItem("Saradomin plateskirt"), GetItem("Saradomin kiteshield") }
                , GetItem("Saradomin armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak full helm"), GetItem("Zamorak platebody"), GetItem("Zamorak platelegs"), GetItem("Zamorak kiteshield") }
                , GetItem("Zamorak armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak full helm"), GetItem("Zamorak platebody"), GetItem("Zamorak plateskirt"), GetItem("Zamorak kiteshield") }
                , GetItem("Zamorak armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix full helm"), GetItem("Guthix platebody"), GetItem("Guthix platelegs"), GetItem("Guthix kiteshield") }
                , GetItem("Guthix armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix full helm"), GetItem("Guthix platebody"), GetItem("Guthix plateskirt"), GetItem("Guthix kiteshield") }
                , GetItem("Guthix armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl full helm"), GetItem("Armadyl platebody"), GetItem("Armadyl platelegs"), GetItem("Armadyl kiteshield") }
                , GetItem("Armadyl rune armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl full helm"), GetItem("Armadyl platebody"), GetItem("Armadyl plateskirt"), GetItem("Armadyl kiteshield") }
                , GetItem("Armadyl rune armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos full helm"), GetItem("Bandos platebody"), GetItem("Bandos platelegs"), GetItem("Bandos kiteshield") }
                , GetItem("Bandos rune armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos full helm"), GetItem("Bandos platebody"), GetItem("Bandos plateskirt"), GetItem("Bandos kiteshield") }
                , GetItem("Bandos rune armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ancient full helm"), GetItem("Ancient platebody"), GetItem("Ancient platelegs"), GetItem("Ancient kiteshield") }
                , GetItem("Ancient rune armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ancient full helm"), GetItem("Ancient platebody"), GetItem("Ancient plateskirt"), GetItem("Ancient kiteshield") }
                , GetItem("Ancient rune armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Gilded full helm"), GetItem("Gilded platebody"), GetItem("Gilded platelegs"), GetItem("Gilded kiteshield") }
                , GetItem("Gilded armour set (lg)")),
            new CreationProcess(
                new List<Item>() { GetItem("Gilded full helm"), GetItem("Gilded platebody"), GetItem("Gilded plateskirt"), GetItem("Gilded kiteshield") }
                , GetItem("Gilded armour set (sk)")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin page 1"), GetItem("Saradomin page 2"), GetItem("Saradomin page 3"), GetItem("Saradomin page 4") }
                , GetItem("Holy book page set")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix page 1"), GetItem("Guthix page 2"), GetItem("Guthix page 3"), GetItem("Guthix page 4") }
                , GetItem("Book of balance page set")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak page 1"), GetItem("Zamorak page 2"), GetItem("Zamorak page 3"), GetItem("Zamorak page 4") }
                , GetItem("Unholy book page set")),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl page 1"), GetItem("Armadyl page 2"), GetItem("Armadyl page 3"), GetItem("Armadyl page 4") }
                , GetItem("Book of law page set")),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos page 1"), GetItem("Bandos page 2"), GetItem("Bandos page 3"), GetItem("Bandos page 4") }
                , GetItem("Book of war page set")),
            new CreationProcess(
                new List<Item>() { GetItem("Ancient page 1"), GetItem("Ancient page 2"), GetItem("Ancient page 3"), GetItem("Ancient page 4") }
                , GetItem("Book of darkness page set")),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin coif"), GetItem("Saradomin d'hide"), GetItem("Saradomin chaps"), GetItem("Saradomin bracers") }
                , GetItem("Saradomin dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak coif"), GetItem("Zamorak d'hide"), GetItem("Zamorak chaps"), GetItem("Zamorak bracers") }
                , GetItem("Zamorak dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix coif"), GetItem("Guthix dragonhide"), GetItem("Guthix chaps"), GetItem("Guthix bracers") }
                , GetItem("Guthix dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos coif"), GetItem("Bandos d'hide"), GetItem("Bandos chaps"), GetItem("Bandos bracers") }
                , GetItem("Bandos dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl coif"), GetItem("Armadyl d'hide"), GetItem("Armadyl chaps"), GetItem("Armadyl bracers") }
                , GetItem("Armadyl dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Ancient coif"), GetItem("Ancient d'hide"), GetItem("Ancient chaps"), GetItem("Ancient bracers") }
                , GetItem("Ancient dragonhide set")),
            new CreationProcess(
                new List<Item>() { GetItem("Green halloween mask"), GetItem("Blue halloween mask"), GetItem("Red halloween mask") }
                , GetItem("Halloween mask set")),
            new CreationProcess(
                new List<Item>() { GetItem("Dwarf cannon set") }
                , new List<Item> () {  GetItem("Cannon base"), GetItem("Cannon stand"), GetItem("Cannon barrels"), GetItem("Cannon furnace") }),
            new CreationProcess(
                new List<Item>() { GetItem("Green dragonhide set") }
                , new List<Item> () {  GetItem("Green d'hide body"), GetItem("Green d'hide chaps"), GetItem("Green d'hide vamb") }),
            new CreationProcess(
                new List<Item>() { GetItem("Blue dragonhide set") }
                , new List<Item> () {  GetItem("Blue d'hide body"), GetItem("Blue d'hide chaps"), GetItem("Blue d'hide vamb") }),
            new CreationProcess(
                new List<Item>() { GetItem("Red dragonhide set") }
                , new List<Item> () {  GetItem("Red d'hide body"), GetItem("Red d'hide chaps"), GetItem("Red d'hide vamb") }),
            new CreationProcess(
                new List<Item>() { GetItem("Black dragonhide set") }
                , new List<Item> () {  GetItem("Black d'hide body"), GetItem("Black d'hide chaps"), GetItem("Black d'hide vamb") }),
            new CreationProcess(
                new List<Item>() { GetItem("Ahrim's armour set") }
                , new List<Item> () {  GetItem("Ahrim's hood"), GetItem("Ahrim's robetop"), GetItem("Ahrim's robeskirt"), GetItem("Ahrim's staff") }),
            new CreationProcess(
                new List<Item>() { GetItem("Dharok's armour set") }
                , new List<Item> () {  GetItem("Dharok's helm"), GetItem("Dharok's platebody"), GetItem("Dharok's platelegs"), GetItem("Dharok's greataxe") }),
            new CreationProcess(
                new List<Item>() { GetItem("Guthan's armour set") }
                , new List<Item> () {  GetItem("Guthan's helm"), GetItem("Guthan's platebody"), GetItem("Guthan's chainskirt"), GetItem("Guthan's warspear") }),
            new CreationProcess(
                new List<Item>() { GetItem("Karil's armour set") }
                , new List<Item> () {  GetItem("Karil's coif"), GetItem("Karil's leathertop"), GetItem("Karil's leatherskirt"), GetItem("Karil's crossbow") }),
            new CreationProcess(
                new List<Item>() { GetItem("Torag's armour set") }
                , new List<Item> () {  GetItem("Torag's helm"), GetItem("Torag's platebody"), GetItem("Torag's platelegs"), GetItem("Torag's hammers") }),
            new CreationProcess(
                new List<Item>() { GetItem("Verac's armour set") }
                , new List<Item> () {  GetItem("Verac's helm"), GetItem("Verac's brassard"), GetItem("Verac's plateskirt"), GetItem("Verac's flail") }),
            new CreationProcess(
                new List<Item>() { GetItem("Combat potion set") }
                , new List<Item> () {  GetItem("Attack potion(4)"), GetItem("Defence potion(4)"), GetItem("Strength potion(4)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Super potion set") }
                , new List<Item> () {  GetItem("Super attack(4)"), GetItem("Super defence(4)"), GetItem("Super strength(4)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze set (lg)") }
                , new List<Item> () {  GetItem("Bronze full helm"), GetItem("Bronze platebody"), GetItem("Bronze platelegs"), GetItem("Bronze kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze set (sk)") }
                , new List<Item> () {  GetItem("Bronze full helm"), GetItem("Bronze platebody"), GetItem("Bronze plateskirt"), GetItem("Bronze kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Iron set (lg)") }
                , new List<Item> () {  GetItem("Iron full helm"), GetItem("Iron platebody"), GetItem("Iron platelegs"), GetItem("Iron kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Iron set (sk)") }
                , new List<Item> () {  GetItem("Iron full helm"), GetItem("Iron platebody"), GetItem("Iron plateskirt"), GetItem("Iron kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Steel set (lg)") }
                , new List<Item> () {  GetItem("Steel full helm"), GetItem("Steel platebody"), GetItem("Steel platelegs"), GetItem("Steel kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Steel set (sk)") }
                , new List<Item> () {  GetItem("Steel full helm"), GetItem("Steel platebody"), GetItem("Steel plateskirt"), GetItem("Steel kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Black set (lg)") }
                , new List<Item> () {  GetItem("Black full helm"), GetItem("Black platebody"), GetItem("Black platelegs"), GetItem("Black kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Black set (sk)") }
                , new List<Item> () {  GetItem("Black full helm"), GetItem("Black platebody"), GetItem("Black plateskirt"), GetItem("Black kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril set (lg)") }
                , new List<Item> () {  GetItem("Mithril full helm"), GetItem("Mithril platebody"), GetItem("Mithril platelegs"), GetItem("Mithril kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril set (sk)") }
                , new List<Item> () {  GetItem("Mithril full helm"), GetItem("Mithril platebody"), GetItem("Mithril plateskirt"), GetItem("Mithril kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant set (lg)") }
                , new List<Item> () {  GetItem("Adamant full helm"), GetItem("Adamant platebody"), GetItem("Adamant platelegs"), GetItem("Adamant kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant set (sk)") }
                , new List<Item> () {  GetItem("Adamant full helm"), GetItem("Adamant platebody"), GetItem("Adamant plateskirt"), GetItem("Adamant kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Rune armour set (lg)") }
                , new List<Item> () {  GetItem("Rune full helm"), GetItem("Rune platebody"), GetItem("Rune platelegs"), GetItem("Rune kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Rune armour set (sk)") }
                , new List<Item> () {  GetItem("Rune full helm"), GetItem("Rune platebody"), GetItem("Rune plateskirt"), GetItem("Rune kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze trimmed set (lg)") }
                , new List<Item> () {  GetItem("Bronze full helm (t)"), GetItem("Bronze platebody (t)"), GetItem("Bronze platelegs (t)"), GetItem("Bronze kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze trimmed set (sk)") }
                , new List<Item> () {  GetItem("Bronze full helm (t)"), GetItem("Bronze platebody (t)"), GetItem("Bronze plateskirt (t)"), GetItem("Bronze kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze gold-trimmed set (lg)") }
                , new List<Item> () {  GetItem("Bronze full helm (g)"), GetItem("Bronze platebody (g)"), GetItem("Bronze platelegs (g)"), GetItem("Bronze kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze gold-trimmed set (sk)") }
                , new List<Item> () {  GetItem("Bronze full helm (g)"), GetItem("Bronze platebody (g)"), GetItem("Bronze plateskirt (g)"), GetItem("Bronze kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Iron trimmed set (lg)") }
                , new List<Item> () {  GetItem("Iron full helm (t)"), GetItem("Iron platebody (t)"), GetItem("Iron platelegs (t)"), GetItem("Iron kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Iron trimmed set (sk)") }
                , new List<Item> () {  GetItem("Iron full helm (t)"), GetItem("Iron platebody (t)"), GetItem("Iron plateskirt (t)"), GetItem("Iron kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Iron gold-trimmed set (lg)") }
                , new List<Item> () {  GetItem("Iron full helm (g)"), GetItem("Iron platebody (g)"), GetItem("Iron platelegs (g)"), GetItem("Iron kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Iron gold-trimmed set (sk)") }
                , new List<Item> () {  GetItem("Iron full helm (g)"), GetItem("Iron platebody (g)"), GetItem("Iron plateskirt (g)"), GetItem("Iron kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Black trimmed set (lg)") }
                , new List<Item> () {  GetItem("Black full helm (t)"), GetItem("Black platebody (t)"), GetItem("Black platelegs (t)"), GetItem("Black kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Black trimmed set (sk)") }
                , new List<Item> () {  GetItem("Black full helm (t)"), GetItem("Black platebody (t)"), GetItem("Black plateskirt (t)"), GetItem("Black kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Black gold-trimmed set (lg)") }
                , new List<Item> () {  GetItem("Black full helm (g)"), GetItem("Black platebody (g)"), GetItem("Black platelegs (g)"), GetItem("Black kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Black gold-trimmed set (sk)") }
                , new List<Item> () {  GetItem("Black full helm (g)"), GetItem("Black platebody (g)"), GetItem("Black plateskirt (g)"), GetItem("Black kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril trimmed set (lg)") }
                , new List<Item> () {  GetItem("Mithril full helm (t)"), GetItem("Mithril platebody (t)"), GetItem("Mithril platelegs (t)"), GetItem("Mithril kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril trimmed set (sk)") }
                , new List<Item> () {  GetItem("Mithril full helm (t)"), GetItem("Mithril platebody (t)"), GetItem("Mithril plateskirt (t)"), GetItem("Mithril kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril gold-trimmed set (lg)") }
                , new List<Item> () {  GetItem("Mithril full helm (g)"), GetItem("Mithril platebody (g)"), GetItem("Mithril platelegs (g)"), GetItem("Mithril kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril gold-trimmed set (sk)") }
                , new List<Item> () {  GetItem("Mithril full helm (g)"), GetItem("Mithril platebody (g)"), GetItem("Mithril plateskirt (g)"), GetItem("Mithril kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant trimmed set (lg)") }
                , new List<Item> () {  GetItem("Adamant full helm (t)"), GetItem("Adamant platebody (t)"), GetItem("Adamant platelegs (t)"), GetItem("Adamant kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant trimmed set (sk)") }
                , new List<Item> () {  GetItem("Adamant full helm (t)"), GetItem("Adamant platebody (t)"), GetItem("Adamant plateskirt (t)"), GetItem("Adamant kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant gold-trimmed set (lg)") }
                , new List<Item> () {  GetItem("Adamant full helm (g)"), GetItem("Adamant platebody (g)"), GetItem("Adamant platelegs (g)"), GetItem("Adamant kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Adamant gold-trimmed set (sk)") }
                , new List<Item> () {  GetItem("Adamant full helm (g)"), GetItem("Adamant platebody (g)"), GetItem("Adamant plateskirt (g)"), GetItem("Adamant kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Rune trimmed set (lg)") }
                , new List<Item> () {  GetItem("Rune full helm (t)"), GetItem("Rune platebody (t)"), GetItem("Rune platelegs (t)"), GetItem("Rune kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Rune trimmed set (sk)") }
                , new List<Item> () {  GetItem("Rune full helm (t)"), GetItem("Rune platebody (t)"), GetItem("Rune plateskirt (t)"), GetItem("Rune kiteshield (t)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Rune gold-trimmed set (lg)") }
                , new List<Item> () {  GetItem("Rune full helm (g)"), GetItem("Rune platebody (g)"), GetItem("Rune platelegs (g)"), GetItem("Rune kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Rune gold-trimmed set (sk)") }
                , new List<Item> () {  GetItem("Rune full helm (g)"), GetItem("Rune platebody (g)"), GetItem("Rune plateskirt (g)"), GetItem("Rune kiteshield (g)") }),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin armour set (lg)") }
                , new List<Item> () {  GetItem("Saradomin full helm"), GetItem("Saradomin platebody"), GetItem("Saradomin platelegs"), GetItem("Saradomin kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin armour set (sk)") }
                , new List<Item> () {  GetItem("Saradomin full helm"), GetItem("Saradomin platebody"), GetItem("Saradomin plateskirt"), GetItem("Saradomin kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak armour set (lg)") }
                , new List<Item> () {  GetItem("Zamorak full helm"), GetItem("Zamorak platebody"), GetItem("Zamorak platelegs"), GetItem("Zamorak kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak armour set (sk)") }
                , new List<Item> () {  GetItem("Zamorak full helm"), GetItem("Zamorak platebody"), GetItem("Zamorak plateskirt"), GetItem("Zamorak kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix armour set (lg)") }
                , new List<Item> () {  GetItem("Guthix full helm"), GetItem("Guthix platebody"), GetItem("Guthix platelegs"), GetItem("Guthix kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix armour set (sk)") }
                , new List<Item> () {  GetItem("Guthix full helm"), GetItem("Guthix platebody"), GetItem("Guthix plateskirt"), GetItem("Guthix kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl rune armour set (lg)") }
                , new List<Item> () {  GetItem("Armadyl full helm"), GetItem("Armadyl platebody"), GetItem("Armadyl platelegs"), GetItem("Armadyl kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl rune armour set (sk)") }
                , new List<Item> () {  GetItem("Armadyl full helm"), GetItem("Armadyl platebody"), GetItem("Armadyl plateskirt"), GetItem("Armadyl kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos rune armour set (lg)") }
                , new List<Item> () {  GetItem("Bandos full helm"), GetItem("Bandos platebody"), GetItem("Bandos platelegs"), GetItem("Bandos kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos rune armour set (sk)") }
                , new List<Item> () {  GetItem("Bandos full helm"), GetItem("Bandos platebody"), GetItem("Bandos plateskirt"), GetItem("Bandos kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Ancient rune armour set (lg)") }
                , new List<Item> () {  GetItem("Ancient full helm"), GetItem("Ancient platebody"), GetItem("Ancient platelegs"), GetItem("Ancient kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Ancient rune armour set (sk)") }
                , new List<Item> () {  GetItem("Ancient full helm"), GetItem("Ancient platebody"), GetItem("Ancient plateskirt"), GetItem("Ancient kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Gilded armour set (lg)") }
                , new List<Item> () {  GetItem("Gilded full helm"), GetItem("Gilded platebody"), GetItem("Gilded platelegs"), GetItem("Gilded kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Gilded armour set (sk)") }
                , new List<Item> () {  GetItem("Gilded full helm"), GetItem("Gilded platebody"), GetItem("Gilded plateskirt"), GetItem("Gilded kiteshield") }),
            new CreationProcess(
                new List<Item>() { GetItem("Holy book page set") }
                , new List<Item> () {  GetItem("Saradomin page 1"), GetItem("Saradomin page 2"), GetItem("Saradomin page 3"), GetItem("Saradomin page 4") }),
            new CreationProcess(
                new List<Item>() { GetItem("Book of balance page set") }
                , new List<Item> () {  GetItem("Guthix page 1"), GetItem("Guthix page 2"), GetItem("Guthix page 3"), GetItem("Guthix page 4") }),
            new CreationProcess(
                new List<Item>() { GetItem("Unholy book page set") }
                , new List<Item> () {  GetItem("Zamorak page 1"), GetItem("Zamorak page 2"), GetItem("Zamorak page 3"), GetItem("Zamorak page 4") }),
            new CreationProcess(
                new List<Item>() { GetItem("Book of law page set") }
                , new List<Item> () {  GetItem("Armadyl page 1"), GetItem("Armadyl page 2"), GetItem("Armadyl page 3"), GetItem("Armadyl page 4") }),
            new CreationProcess(
                new List<Item>() { GetItem("Book of war page set") }
                , new List<Item> () {  GetItem("Bandos page 1"), GetItem("Bandos page 2"), GetItem("Bandos page 3"), GetItem("Bandos page 4") }),
            new CreationProcess(
                new List<Item>() { GetItem("Book of darkness page set") }
                , new List<Item> () {  GetItem("Ancient page 1"), GetItem("Ancient page 2"), GetItem("Ancient page 3"), GetItem("Ancient page 4") }),
            new CreationProcess(
                new List<Item>() { GetItem("Saradomin dragonhide set") }
                , new List<Item> () {  GetItem("Saradomin coif"), GetItem("Saradomin d'hide"), GetItem("Saradomin chaps"), GetItem("Saradomin bracers") }),
            new CreationProcess(
                new List<Item>() { GetItem("Zamorak dragonhide set") }
                , new List<Item> () {  GetItem("Zamorak coif"), GetItem("Zamorak d'hide"), GetItem("Zamorak chaps"), GetItem("Zamorak bracers") }),
            new CreationProcess(
                new List<Item>() { GetItem("Guthix dragonhide set") }
                , new List<Item> () {  GetItem("Guthix coif"), GetItem("Guthix dragonhide"), GetItem("Guthix chaps"), GetItem("Guthix bracers") }),
            new CreationProcess(
                new List<Item>() { GetItem("Bandos dragonhide set") }
                , new List<Item> () {  GetItem("Bandos coif"), GetItem("Bandos d'hide"), GetItem("Bandos chaps"), GetItem("Bandos bracers") }),
            new CreationProcess(
                new List<Item>() { GetItem("Armadyl dragonhide set") }
                , new List<Item> () {  GetItem("Armadyl coif"), GetItem("Armadyl d'hide"), GetItem("Armadyl chaps"), GetItem("Armadyl bracers") }),
            new CreationProcess(
                new List<Item>() { GetItem("Ancient dragonhide set") }
                , new List<Item> () {  GetItem("Ancient coif"), GetItem("Ancient d'hide"), GetItem("Ancient chaps"), GetItem("Ancient bracers") }),
            new CreationProcess(
                new List<Item>() { GetItem("Halloween mask set") }
                , new List<Item> () {  GetItem("Green halloween mask"), GetItem("Blue halloween mask"), GetItem("Red halloween mask") }),
        };
        #endregion

        #region Runecrafting
        public List<CreationProcess> Runecrafting = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Air talisman") }
                , GetItem("Air tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Mind talisman") }
                , GetItem("Mind tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Water talisman") }
                , GetItem("Water tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Earth talisman") }
                , GetItem("Earth tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Fire talisman") }
                , GetItem("Fire tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Body talisman") }
                , GetItem("Body tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Cosmic talisman") }
                , GetItem("Cosmic tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Chaos talisman") }
                , GetItem("Chaos tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Nature talisman") }
                , GetItem("Nature tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Tiara"), GetItem("Death talisman") }
                , GetItem("Death tiara")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranger Boots"), GetItem("Pegasian Crystal") }
                , GetItem("Pegasian Boots")),
            new CreationProcess(
                new List<Item>() { GetItem("Dragon Boots"), GetItem("Primordial Crystal") }
                , GetItem("Primordial Boots")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 7)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 7)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 8)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 8)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 9)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 9)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Air rune", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Air rune", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune", 7)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune", 7)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Mind rune", 8)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Mind rune", 8)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Air rune", 208), GetItem("Air talisman", 208), GetItem("Binding necklace") }
                , GetItem("Mist rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Water rune", 208), GetItem("Water talisman", 208), GetItem("Binding necklace") }
                , GetItem("Mist rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Water rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Water rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Water rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Water rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Water rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Water rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Water rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Water rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Water rune", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Water rune", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Water rune", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Water rune", 6)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Earth rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Earth rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Earth rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Earth rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Earth rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Earth rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Earth rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Earth rune", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Air rune", 208), GetItem("Air talisman", 208), GetItem("Binding necklace") }
                , GetItem("Dust rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Earth rune", 208), GetItem("Earth talisman", 208), GetItem("Binding necklace") }
                , GetItem("Dust rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Water rune", 208), GetItem("Water talisman", 208), GetItem("Binding necklace") }
                , GetItem("Mud rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Earth rune", 208), GetItem("Earth talisman", 208), GetItem("Binding necklace") }
                , GetItem("Mud rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Fire rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Fire rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Fire rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Fire rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Fire rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Fire rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Air rune", 208), GetItem("Air talisman", 208), GetItem("Binding necklace") }
                , GetItem("Smoke rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Fire rune", 208), GetItem("Fire talisman", 208), GetItem("Binding necklace") }
                , GetItem("Smoke rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Water rune", 208), GetItem("Water talisman", 208), GetItem("Binding necklace") }
                , GetItem("Steam rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Fire rune", 208), GetItem("Fire talisman", 208), GetItem("Binding necklace") }
                , GetItem("Steam rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Body rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Body rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Body rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Body rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Rune essence") }
                , GetItem("Body rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Body rune", 3)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Earth rune", 208), GetItem("Earth talisman", 208), GetItem("Binding necklace") }
                , GetItem("Lava rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 208), GetItem("Fire rune", 208), GetItem("Fire talisman", 208), GetItem("Binding necklace") }
                , GetItem("Lava rune", 208)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Cosmic rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Cosmic rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Chaos rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Chaos rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Astral rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Astral rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Nature rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Nature rune", 2)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Law rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence") }
                , GetItem("Death rune")),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Air rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Mist rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Water rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Mist rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Air rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Dust rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Earth rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Dust rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Water rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Mud rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Earth rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Mud rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Air rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Smoke rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Fire rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Smoke rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Water rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Steam rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Fire rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Steam rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Earth rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Lava rune", 26)),
            new CreationProcess(
                new List<Item>() { GetItem("Pure essence", 26), GetItem("Fire rune", 26), GetItem("Astral rune", 2) }
                , GetItem("Lava rune", 26)),
        };
        #endregion

        #region Smithing
        public List<CreationProcess> Smithing = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Tin ore"), GetItem("Copper ore") }
                , GetItem("Bronze bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron ore") }
                , GetItem("Iron bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Silver ore") }
                , GetItem("Silver bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron ore"), GetItem("Coal", 4) }
                , GetItem("Steel bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Gold ore") }
                , GetItem("Gold bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril ore"), GetItem("Coal", 4) }
                , GetItem("Mithril bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite ore"), GetItem("Coal", 6) }
                , GetItem("Adamantite bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite ore"), GetItem("Coal", 8) }
                , GetItem("Runite bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Tin ore"), GetItem("Copper ore") }
                , GetItem("Bronze bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Iron ore") }
                , GetItem("Iron bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Silver ore") }
                , GetItem("Silver bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Iron ore"), GetItem("Coal", 2) }
                , GetItem("Steel bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Gold ore") }
                , GetItem("Gold bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Mithril ore"), GetItem("Coal", 4) }
                , GetItem("Mithril bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Adamantite ore"), GetItem("Coal", 6) }
                , GetItem("Adamantite bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Nature rune"), GetItem("Runite ore"), GetItem("Coal", 8) }
                , GetItem("Runite bar")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze dagger")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze axe")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze mace")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze med helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze bolts (unf)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze wire")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze dart tip", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze nails", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze arrowtips", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 2) }
                , GetItem("Bronze scimitar")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar"), GetItem("Logs") }
                , GetItem("Bronze spear")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar"), GetItem("Logs") }
                , GetItem("Bronze hasta")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze limbs")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze javelin heads", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 2) }
                , GetItem("Bronze longsword")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 2) }
                , GetItem("Bronze full helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar") }
                , GetItem("Bronze knife", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 2) }
                , GetItem("Bronze sq shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 3) }
                , GetItem("Bronze warhammer")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 3) }
                , GetItem("Bronze battleaxe")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 3) }
                , GetItem("Bronze chainbody")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 3) }
                , GetItem("Bronze kiteshield")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 2) }
                , GetItem("Bronze claws")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 3) }
                , GetItem("Bronze 2h sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 3) }
                , GetItem("Bronze platelegs")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 3) }
                , GetItem("Bronze plateskirt")),
            new CreationProcess(
                new List<Item>() { GetItem("Bronze bar", 5) }
                , GetItem("Bronze platebody")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron dagger")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron axe")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron mace")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron spit")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron med helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron bolts (unf)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron dart tip", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron nails", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron arrowtips", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 2) }
                , GetItem("Iron scimitar")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar"), GetItem("Oak logs") }
                , GetItem("Iron spear")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar"), GetItem("Oak logs") }
                , GetItem("Iron hasta")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron javelin heads", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 2) }
                , GetItem("Iron longsword")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 2) }
                , GetItem("Iron full helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron knife", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Iron limbs")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 2) }
                , GetItem("Iron sq shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 3) }
                , GetItem("Iron warhammer")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 3) }
                , GetItem("Iron battleaxe")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar") }
                , GetItem("Oil lantern frame")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 3) }
                , GetItem("Iron chainbody")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 3) }
                , GetItem("Iron kiteshield")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 2) }
                , GetItem("Iron claws")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 3) }
                , GetItem("Iron 2h sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 3) }
                , GetItem("Iron platelegs")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 3) }
                , GetItem("Iron plateskirt")),
            new CreationProcess(
                new List<Item>() { GetItem("Iron bar", 5) }
                , GetItem("Iron platebody")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel dagger")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel axe")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel mace")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel med helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel bolts (unf)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel dart tip", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel nails", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel arrowtips", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Cannonball", 4)),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 2) }
                , GetItem("Steel scimitar")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar"), GetItem("Willow logs") }
                , GetItem("Steel spear")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar"), GetItem("Willow logs") }
                , GetItem("Steel hasta")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel limbs")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel javelin heads", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 2) }
                , GetItem("Steel longsword")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel studs")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 2) }
                , GetItem("Steel full helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Steel knife", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 2) }
                , GetItem("Steel sq shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 3) }
                , GetItem("Steel warhammer")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 3) }
                , GetItem("Steel battleaxe")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 3) }
                , GetItem("Steel chainbody")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 3) }
                , GetItem("Steel kiteshield")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 2) }
                , GetItem("Steel claws")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 3) }
                , GetItem("Steel 2h sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 3) }
                , GetItem("Steel platelegs")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 3) }
                , GetItem("Steel plateskirt")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar", 5) }
                , GetItem("Steel platebody")),
            new CreationProcess(
                new List<Item>() { GetItem("Steel bar") }
                , GetItem("Bullseye lantern (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril dagger")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril axe")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril mace")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril med helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril bolts (unf)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril dart tip", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril nails", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril arrowtips", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 2) }
                , GetItem("Mithril scimitar")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar"), GetItem("Maple logs") }
                , GetItem("Mithril spear")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar"), GetItem("Maple logs") }
                , GetItem("Mithril hasta")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril limbs")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril javelin heads", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 2) }
                , GetItem("Mithril longsword")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 2) }
                , GetItem("Mithril full helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mithril knife", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 2) }
                , GetItem("Mithril sq shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 3) }
                , GetItem("Mithril warhammer")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar") }
                , GetItem("Mith grapple tip")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 3) }
                , GetItem("Mithril battleaxe")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 3) }
                , GetItem("Mithril chainbody")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 3) }
                , GetItem("Mithril kiteshield")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 2) }
                , GetItem("Mithril claws")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 3) }
                , GetItem("Mithril 2h sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 3) }
                , GetItem("Mithril platelegs")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 3) }
                , GetItem("Mithril plateskirt")),
            new CreationProcess(
                new List<Item>() { GetItem("Mithril bar", 5) }
                , GetItem("Mithril platebody")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant dagger")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant axe")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant mace")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant med helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant bolts(unf)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant dart tip", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamantite nails", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant arrowtips", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 2) }
                , GetItem("Adamant scimitar")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar"), GetItem("Yew logs") }
                , GetItem("Adamant spear")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar"), GetItem("Yew logs") }
                , GetItem("Adamant hasta")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamantite limbs")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant javelin heads", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 2) }
                , GetItem("Adamant longsword")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 2) }
                , GetItem("Adamant full helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar") }
                , GetItem("Adamant knife", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 2) }
                , GetItem("Adamant sq shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 3) }
                , GetItem("Adamant warhammer")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 3) }
                , GetItem("Adamant battleaxe")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 3) }
                , GetItem("Adamant chainbody")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 3) }
                , GetItem("Adamant kiteshield")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 2) }
                , GetItem("Adamant claws")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 3) }
                , GetItem("Adamant 2h sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 3) }
                , GetItem("Adamant platelegs")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 3) }
                , GetItem("Adamant plateskirt")),
            new CreationProcess(
                new List<Item>() { GetItem("Adamantite bar", 5) }
                , GetItem("Adamant platebody")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune dagger")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune axe")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune mace")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune med helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Runite bolts (unf)", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune dart tip", 10)),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune nails", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune arrowtips", 15)),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 2) }
                , GetItem("Rune scimitar")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar"), GetItem("Magic logs") }
                , GetItem("Rune spear")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar"), GetItem("Magic logs") }
                , GetItem("Rune hasta")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Runite limbs")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune javelin heads", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 2) }
                , GetItem("Rune longsword")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 2) }
                , GetItem("Rune full helm")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar") }
                , GetItem("Rune knife", 5)),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 2) }
                , GetItem("Rune sq shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 3) }
                , GetItem("Rune warhammer")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 3) }
                , GetItem("Rune battleaxe")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 3) }
                , GetItem("Rune chainbody")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 3) }
                , GetItem("Rune kiteshield")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 2) }
                , GetItem("Rune claws")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 3) }
                , GetItem("Rune 2h sword")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 3) }
                , GetItem("Rune platelegs")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 3) }
                , GetItem("Rune plateskirt")),
            new CreationProcess(
                new List<Item>() { GetItem("Runite bar", 5) }
                , GetItem("Rune platebody")),
            new CreationProcess(
                new List<Item>() { GetItem("shield left half"), GetItem("shield right half")}
                , GetItem("Dragon sq shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Godsword shard 1"), GetItem("Godsword shard 2"), GetItem("Godsword shard 2") }
                , GetItem("Godsword blade")),
            new CreationProcess(
                new List<Item>() { GetItem("Draconic visage"), GetItem("Anti-dragon shield") }
                , GetItem("Dragonfire shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Elysian sigil"), GetItem("Blessed spirit shield")}
                , GetItem("Elysian spirit shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Arcane sigil"), GetItem("Blessed spirit shield")}
                , GetItem("Arcane spirit shield")),
            new CreationProcess(
                new List<Item>() { GetItem("Spectral sigil"), GetItem("Blessed spirit shield")}
                , GetItem("Spectral spirit shield")),
        };
        #endregion

        #region Unfinished
        public List<CreationProcess> Unfinished = new List<CreationProcess>()
        {
            new CreationProcess(
                new List<Item>() { GetItem("Grimy guam leaf"), GetItem("Vial of water") }
                , GetItem("Guam potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Guam leaf"), GetItem("Vial of water") }
                , GetItem("Guam potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy marrentill"), GetItem("Vial of water") }
                , GetItem("Marrentill potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Marrentill"), GetItem("Vial of water") }
                , GetItem("Marrentill potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy tarromin"), GetItem("Vial of water") }
                , GetItem("Tarromin potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Tarromin"), GetItem("Vial of water") }
                , GetItem("Tarromin potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy harralander"), GetItem("Vial of water") }
                , GetItem("Harralander potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Harralander"), GetItem("Vial of water") }
                , GetItem("Harralander potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy ranarr weed"), GetItem("Vial of water") }
                , GetItem("Ranarr potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Ranarr weed"), GetItem("Vial of water") }
                , GetItem("Ranarr potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy toadflax"), GetItem("Vial of water") }
                , GetItem("Toadflax potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Toadflax"), GetItem("Vial of water") }
                , GetItem("Toadflax potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy irit leaf"), GetItem("Vial of water") }
                , GetItem("Irit potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Irit leaf"), GetItem("Vial of water") }
                , GetItem("Irit potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy avantoe"), GetItem("Vial of water") }
                , GetItem("Avantoe potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Avantoe"), GetItem("Vial of water") }
                , GetItem("Avantoe potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy kwuarm"), GetItem("Vial of water") }
                , GetItem("Kwuarm potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Kwuarm"), GetItem("Vial of water") }
                , GetItem("Kwuarm potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy snapdragon"), GetItem("Vial of water") }
                , GetItem("Snapdragon potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Snapdragon"), GetItem("Vial of water") }
                , GetItem("Snapdragon potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy cadantine"), GetItem("Vial of water") }
                , GetItem("Cadantine potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Cadantine"), GetItem("Vial of water") }
                , GetItem("Cadantine potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy lantadyme"), GetItem("Vial of water") }
                , GetItem("Lantadyme potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Lantadyme"), GetItem("Vial of water") }
                , GetItem("Lantadyme potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy dwarf weed"), GetItem("Vial of water") }
                , GetItem("Dwarf weed potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Dwarf weed"), GetItem("Vial of water") }
                , GetItem("Dwarf weed potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Grimy torstol"), GetItem("Vial of water") }
                , GetItem("Torstol potion (unf)")),
            new CreationProcess(
                new List<Item>() { GetItem("Torstol"), GetItem("Vial of water") }
                , GetItem("Torstol potion (unf)")),
        };
        #endregion
    }
}
