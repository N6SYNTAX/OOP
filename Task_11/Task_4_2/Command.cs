using System;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        protected Command(string[] ids) : base(ids) { }
        public abstract string Execute(Player p, string[] text);
        public abstract string ExecutePeak(Location L, string[] text);
    }
}