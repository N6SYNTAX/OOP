
using System;
using System.ComponentModel;

namespace SwinAdventure
{
    class Program
    {
        static void Main()
        {
            //Console.Write("Name: ");
            var name = Console.ReadLine();
            //Console.Write("Description: ");
            var desc = Console.ReadLine();
            var player = new Player(name, desc);

            var gem = new Item(new[] { "gem" }, "Red Gem", "A bright red gem");
            var bag = new Bag(new[] { "bag" }, "Leather Bag", "A small leather bag");
            player.Inventory.Put(gem);
            player.Inventory.Put(bag);

            var torch = new Item(new[] { "torch" }, "Torch", "A wooden torch");
            bag.Inventory.Put(torch);

            var look = new LookCommand();


            var Opening = new Location();

            var Hole = new Path(new[] { "forward" }, Opening, $"At the base of the door you notice an overgrown door with vines and tree growth partially covering it.\nWould you like to proceed through the door?", $"\n*THUMP* You slide down a long worming hole and land flat on your back in what appears to be a caveren with several paths leading away from you. You look back up at the hole you fell through, and there is no way back up", true);
            Opening.AddPath(Hole);

            //var P1 = new Path(new[] { "1" }, "NSE", "You are standing on a narrow ledge, you peer off and there is nothing but darkness below");

            Console.WriteLine(Hole.Peak);
            Console.WriteLine(Hole.Description);


            // while (true)
            // {
            //     Console.Write("Command -> ");
            //     var line = Console.ReadLine();
            //     if (line == "quit") break;
            //     var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //     Console.WriteLine(look.Execute(player, words));
            // }
        }
    }
}
