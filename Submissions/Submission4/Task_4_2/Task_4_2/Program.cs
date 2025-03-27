using System;
using SplashKitSDK;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main()
        {
            Item Apple = new Item(new string[] { "F" }, "Apple", "A Delicious Fruit");
            Item Bannana = new Item(new string[] { "F" }, "Bannana", "A Fuit with A Peel");

            Item Sword = new Item(new string[] { "W" }, "Bronze Sword", "A feirce fighting instrument");
            Item Sheild = new Item(new string[] { "S" }, "Wooden Shield", "Will protect you... I guess");

            Console.WriteLine(Apple.ShortDescription);

            Inventory Player1 = new Inventory();
            Console.WriteLine(Player1.ItemList);
            Player1.Put(Apple);
            Console.WriteLine(Player1.ItemList);
            Player1.Put(Bannana);
            Player1.Put(Sword);
            Player1.Put(Sheild);
            Player1.Take("w");
            Console.WriteLine(Player1.ItemList);
        }
    }
}
