using System;
using SwinAdventure;

public class MoveCommand : Command
{
    public MoveCommand() 
        : base(new[] { "move", "go" }) { }

public override string Execute(Player player, string[] words)
{
  if (words.Length < 2)
    return "Move where?";

  var direction = words[1];
  var path = player.Location.Fetch(direction);
  if (path == null)
    return $"You can't go {direction}.";

  player.Location = path.Destination;
  return path.FullDescription + "\n" + player.Location.FullDescription;
}

}
