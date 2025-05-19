
using System;

namespace SwinAdventure
{
    class Program
    {
        static void Main()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Description: ");
            var desc = Console.ReadLine();
            var player = new Player(name, desc);

            var gem = new Item(new[] { "gem" }, "Red Gem", "A bright red gem");
            var bag = new Bag(new[] { "bag" }, "Leather Bag", "A small leather bag");
            player.Inventory.Put(gem);
            player.Inventory.Put(bag);

            var torch = new Item(new[] { "torch" }, "Torch", "A wooden torch");
            bag.Inventory.Put(torch);

            var look = new LookCommand();

            
            
            var P1 = new Path(new[]{"1"}, "NSE", "You are standing on a narrow ledge, you peer off and there is nothing but darkness below");
            Console.WriteLine(P1.BackStory);
            Console.WriteLine(P1.Hole);
            Console.WriteLine(P1.Description);


            while (true)
            {
                Console.Write("Command -> ");
                var line = Console.ReadLine();
                if (line == "quit") break;
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(look.Execute(player, words));
            }
        }
    }
}
