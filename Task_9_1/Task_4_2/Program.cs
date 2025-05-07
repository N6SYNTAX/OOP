using System;
using SplashKitSDK;
using SwinAdventure;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main()
        {


            Player _testPlayer;
            _testPlayer = new Player("James", "an explorer");
            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", " torch" }, "A Torch", "A Torch to light the path");


            //add the items into t he playe r' s inventory
            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);


            //Print the player Identifiers
            // Console.WriteLine(_testPlayer.AreYou("me"));
            // Console.WriteLine(_testPlayer.AreYou("inventory"));

            // if (_testPlayer.Locate("light") != null)
            // {
            //     Console.WriteLine("The object torch exists");
            //     Console.WriteLine(_testPlayer.Inventory.HasItem("light"));
            // }
            // else
            // {
            //     Console.WriteLine("The object torch does not exist");
            // }




            //write the PlayerObject to file
            Bag Sack;
            Item Apple;
            Item Bannana;
            Item Sword;
            Item Shield;

            Sack = new Bag(new string[] { "a" }, "Apple", "A Delicious Fruit");
            Apple = new Item(new string[] { "a" }, "Apple", "A Delicious Fruit");
            Bannana = new Item(new string[] { "b" }, "Bannana", "A Fuit with A Peel");
            Sword = new Item(new string[] { "W" }, "Bronze Sword", "A feirce fighting instrument");
            Shield = new Item(new string[] { "S" }, "Wooden Shield", "Will protect you... I guess");

            Sack.Inventory.Put(Shield);
            Sack.Inventory.Put(Apple);

            Console.WriteLine(Sack.Locate("me"));


            Console.WriteLine(Sack.Inventory.ItemList);



            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try
            {
                _testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }


            //read from the file
            StreamReader reader = new StreamReader("TestPlayer.txt");
            try
            {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {

                writer.Close();
            }


        }
    }
}
