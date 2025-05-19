using System;
using SwinAdventure;

namespace SwinAdventure
{
    // The abstract base, already provided:
    // public abstract class Command : IdentifiableObject
    // {
    //     protected Command(string[] ids) : base(ids) { }
    //     public abstract string Execute(Player p, string[] text);
    // }

    public class LookCommand : Command
    {
        public LookCommand()
            : base(new string[] { "look" })  // identified by "look"
        { }

        public override string Execute(Player player, string[] text)
        {
            // 1. Must be 3 or 5 words
            if (text.Length != 3 && text.Length != 5)
                return "I don't know how to look like that";

            // 2. First word must be “look”
            if (!AreYou(text[0]))
                return "Error in look input";

            // 3. Second word must be “at”
            if (text[1] != "at")
                return "What do you want to look at?";

            // Determine container (player or named bag)
            IHaveInventory container;
            if (text.Length == 5)
            {
                // 4-word must be “in”
                if (text[3] != "in")
                    return "What do you want to look in?";
                container = FetchContainer(player, text[4]);
                if (container == null)
                    return $"I cannot find the {text[4]}";
            }
            else
            {
                container = player;
            }

            // Look up the item
            return LookAtIn(text[2], container);
        }

        // Ask Player to Locate(...) and cast safely to IHaveInventory
        private IHaveInventory FetchContainer(Player player, string containerId)
        {
            var obj = player.Locate(containerId);
            return obj as IHaveInventory;
        }

        // Ask the container to Locate the “thing”; return full description or error
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            var obj = container.Locate(thingId);
            if (obj == null)
                return $"I cannot find the {thingId} in the {container.Name}";
            return obj.FullDescription;
        }
    }
}
