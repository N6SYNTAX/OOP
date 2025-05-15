
using System;
namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new[] { "look" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5) return "I don't know how to look like that";
            if (!AreYou(text[0])) return "Error in look input";
            if (text[1] != "at") return "What do you want to look at?";
            IHaveInventory container = text.Length == 3
                ? p
                : FetchContainer(p, text[4]);
            if (container == null) return $"I cannot find the {text[4]}";
            return LookAtIn(text[2], container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            var obj = p.Locate(containerId);
            return obj as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            var obj = container.Locate(thingId);
            if (obj == null) return $"I cannot find the {thingId}";
            return obj.FullDescription;
        }
    }
}
