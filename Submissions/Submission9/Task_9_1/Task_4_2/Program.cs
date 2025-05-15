using System;
using SplashKitSDK;
using SwinAdventure;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main()
        {

            Player player;
            Item silverHat;
            Item torch;
            Bag bag;
            Item gem;
            Item sword;
            Item potion;
            Item apple;
            player = new Player("Sean", "an epic explorer");
            silverHat = new Item(new[] { "silvert", "silver" }, "Silver Hat", "A shiny hat");
            torch = new Item(new[] { "light", "torch" }, "Torch", "A wooden torch");
            player.Inventory.Put(silverHat);
            player.Inventory.Put(torch);

            bag = new Bag(new[] { "bag", "sack" }, "Leather Bag", "A small leather bag");

            Bag sack;
            sack = new Bag(new[] { "sack" }, "Sack", "A small sack");

            gem = new Item(new[] { "gem", "ruby" }, "Red Gem", "A bright red gem");
            bag.Inventory.Put(gem);

            sword = new Item(new[] { "weapon", "sword" }, "Sword", "A fighting instrument");
            potion = new Item(new[] { "potion", "healing" }, "Healing Potion", "A potion of healing");
            apple = new Item(new[] { "fruit", "apple" }, "Apple", "A delicious fruit");
            bag.Inventory.Put(sword);
            bag.Inventory.Put(potion);
            bag.Inventory.Put(apple);

            List<IHaveInventory> myContainers = new List<IHaveInventory>();
            myContainers.Add(player);
            myContainers.Add(bag);
            myContainers.Add(sack);


            foreach (IHaveInventory c in myContainers)
            {
                Console.WriteLine(c.Name);

                if (c is Player)
                {
                    //var found = c.Locate("me");

                    Console.WriteLine(player.ShortDescription);
                    Console.WriteLine(player.FullDescription);
                }
                else
                {


                    Console.WriteLine(bag.ShortDescription);
                    Console.WriteLine(bag.FullDescription);
                }

                // if (c.Locate("me") != null)
                // {
                //     var found = c.Locate("me");
                //     Console.WriteLine(found.ShortDescription);
                //     Console.WriteLine(found.FullDescription);
                // }

                // else if (c.Locate("me") == null)
                // {
                //     //Console.WriteLine("Nothing Found");
                //     var found2 = c.Locate(Convert.ToString(c));
                //     var res = found2.FirstId;
                //     Console.WriteLine(found2.FirstId);
                //     Console.WriteLine(found2.ShortDescription);
                //     Console.WriteLine(res.FullDescription);
                // }

                Console.WriteLine();
            }

            //     List<IHaveInventory> myContainers = new List<IHaveInventory>();

            // // define a player object and add this object into the list myContainers
            // Player _testPlayer;
            // _testPlayer = new Player("James", "an explorer");

            // myContainers.Add(_testPlayer);

            // // define a bag object and an item, then add the item into the inventory of the bag.
            // Bag _testToolBag;
            // _testToolBag = new Bag(new string[] { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            // Item _testItem2;
            // _testItem2 = new Item(new string[] { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");

            // _testToolBag.Inventory.Put(_testItem2);
            // // add the bag into the list myContainers
            // myContainers.Add(_testToolBag);

            // Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            // Item item2 = new Item(new string[] { "light", " torch" }, "A Torch", "A Torch to light the path");

            // _testPlayer.Inventory.Put(item1);
            // _testPlayer.Inventory.Put(item2);


            // Bag Sack;
            // Item Apple;
            // Item Bannana;
            // Item Sword;
            // Item Shield;

            // Sack = new Bag(new string[] { "a" }, "Apple", "A Delicious Fruit");
            // Apple = new Item(new string[] { "a" }, "Apple", "A Delicious Fruit");
            // Bannana = new Item(new string[] { "b" }, "Bannana", "A Fuit with A Peel");
            // Sword = new Item(new string[] { "W" }, "Bronze Sword", "A feirce fighting instrument");
            // Shield = new Item(new string[] { "S" }, "Wooden Shield", "Will protect you... I guess");

            // Sack.Inventory.Put(Shield);
            // Sack.Inventory.Put(Apple);



            // StreamWriter writer = new StreamWriter("TestPlayer.txt");
            // try
            // {
            //     _testPlayer.SaveTo(writer);
            // }
            // finally
            // {
            //     writer.Close();
            // }


            // //read from the file
            // StreamReader reader = new StreamReader("TestPlayer.txt");
            // try
            // {
            //     _testPlayer.LoadFrom(reader);
            // }
            // finally
            // {

            //     writer.Close();
            // }



        }
    }
}
