using System;
namespace SwinAdventure
{
    public class PeekCommand : Command
    {
        public PeekCommand() : base(new[] { "peek" }) { }


        public override bool Execute(Player player, string[] words)
    {
        if (words.Length < 2) return false;

        // look up a path from your current location
        var thing = player.Location.Locate(words[1]);
        if (thing is Path p)
        {
            Console.WriteLine(p.Peek);
            return true;
        }

        Console.WriteLine("You can't peek at " + words[1]);
        return true;
    }
}
}
