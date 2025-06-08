
using System;
using System.Collections.Generic;

namespace Task_3_1
{
    public class Item : IdentifiableObject
    {
        private string _name;
        private string _description;

        // Constructor: takes an array of identifiers, a name, and a description.
        public Item(string[] idents, string name, string desc)
            : base(idents)
        {
            _name = name;
            _description = desc;
        }

        // Read-only property for the item's name.
        public string Name
        {
            get { return _name; }
        }

        // Read-only property for the short description.
        // Format: "a [name] ([first id])"
        public string ShortDescription
        {
            get { return $"a {_name} ({FirstId})"; }
        }

        // Read-only property for the long description.
        // By default, this returns the full item description.
        public string LongDescription
        {
            get { return _description; }
        }
    }
}
