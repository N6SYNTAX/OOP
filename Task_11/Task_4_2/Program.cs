
using System;
using System.ComponentModel;

namespace SwinAdventure
{
    class Program
    {
        static void Main()
        {

            //
            //---------------------- PLAYER BUILDER --------------------------------
            //
            //Console.Write("Name: ");
            var name = Console.ReadLine();
            //Console.Write("Description: ");
            var desc = Console.ReadLine();
            var Player = new Player("Sean", "Solider");

            //
            //---------------------- ITEM BUILDER --------------------------------
            //

            var gem = new Item(new[] { "gem" }, "Red Gem", "A bright red gem");
            var bag = new Bag(new[] { "bag" }, "Leather Bag", "A small leather bag");
            Player.Inventory.Put(gem);
            Player.Inventory.Put(bag);

            var torch = new Item(new[] { "torch" }, "Torch", "A wooden torch");
            bag.Inventory.Put(torch);



            //
            //---------------------- COMMAND BUILDER --------------------------------
            //

            var look = new LookCommand();
            var peek = new PeekCommand();
            var move = new MoveCommand();
            var commands = new List<Command>
            {
            new LookCommand(),
            new MoveCommand(),
            new PeekCommand(),
            };



            // 
            //---------------------- MAP BUILDER -----------------------------------
            //
            // 

            //Cavern
            var Cavern = new Location(new[] { "cavern" }, "Cavern", $"Large Opening");
            var MineshaftPath = new Path(new[] { "mine" }, Cavern, "Mineshaft", $"Mineshaft ahead", "You Walk down the path", true);
            //var TunnelPath 
            //var RiverPath
            //var CliffPath
            Cavern.Put(MineshaftPath);
            Cavern.Inventory.Put(bag);


            //opening
            var Default = new Location(new[] { "default" }, "Forest", $"You are \nYou are standing at the base of an old weatherd tree,\nwith long twisting knots spanning the entire length of the trunk.\nAt the base of the door you notice an overgrown door with vines and tree growth partially covering.\nWould you like to proceed through the door?");
            var HolePath = new Path(new[] { "door" }, Cavern, "Tree Door", $"At the base of the door you notice an overgrown door with vines and tree growth partially covering it.\nWould you like to proceed through the door?", $"\n*THUMP* You slide down a long worming hole and land flat on your back in what appears to be a caveren with several paths leading away from you. You look back up at the hole you fell through, and there is no way back up", true);
            Default.Put(HolePath);
            Default.Inventory.Put(gem);
            Player.Location = Default;





            //var P1 = new Path(new[] { "1" }, "NSE", "You are standing on a narrow ledge, you peer off and there is nothing but darkness below");


            Console.WriteLine(Player.Location.FullDescription);
            Console.WriteLine(HolePath.Peek);
            // Console.WriteLine(HolePath.FullDescription);
            //Console.WriteLine(Default.WorldMap);


            while (true)
            {
                Console.Write("Command -> ");
                var line = Console.ReadLine();
                if (line == "quit") break;
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //case:
                //Console.WriteLine(move.Execute(Player, words));
                // Console.WriteLine(look.Execute(Player, words));
                Console.WriteLine(look.Execute(Player, words));
            }
        }
    }
}
