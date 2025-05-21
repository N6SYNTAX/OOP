using System;
using SwinAdventure;

public class MoveCommand : Command
{
    public MoveCommand() 
        : base(new[] { "move", "go" }) { }

    public override bool Execute(Player player, string[] words)
    {
        if (words.Length < 2)
        {
            Console.WriteLine("Move where?");
            return false;
        }

        var direction = words[1];
        // Try to fetch a Path from the player's current Location
        var path = player.Location.Fetch(direction);
        if (path == null)
        {
            Console.WriteLine($"You can't go {direction}.");
            return false;
        }

        // Move the player
        player.Location = path.Destination;

        // Describe what they see as they go
        Console.WriteLine(path.FullDescription);
        Console.WriteLine(player.Location.FullDescription);

        return true;
    }
}
