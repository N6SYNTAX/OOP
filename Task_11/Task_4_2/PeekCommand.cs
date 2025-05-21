using System;
namespace SwinAdventure
{
    public class PeekCommand : Command
    {
        public PeekCommand() : base(new[] { "peek" }) { }


        public override string Execute(Player player, string[] words)
        {
            if (words.Length < 2)
            return "Peek where?";

            var thing = player.CurrentLocation.Locate(words[1]);
            if (thing is Path p)
            return p.Peek;

            return $"You can't peek at {words[1]}.";
}

}
}
