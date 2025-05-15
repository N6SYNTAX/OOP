
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        // Constructor simply calls the base GameObject constructor.
        public Item(string[] ids, string name, string desc)
            : base(ids, name, desc)
        {
        }
    }
}
