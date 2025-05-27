using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory; // This specific players inventory
        private Location _location; // players current location updated by move command

        public Player(string name, string desc)
        // passing up identifiers me and inventory
            : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            var Default = new Location(new[] { "default" }, "Forest", $"You are \nYou are standing at the base of an old weatherd tree,\nwith long twisting knots spanning the entire length of the trunk.\nAt the base of the door you notice an overgrown door with vines and tree growth partially covering.\nWould you like to proceed through the door?");
            _location = Default;



        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }


        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                //Console.WriteLine("Success");
                return this;
            }
            var item = Inventory.Fetch(id);
            if (item != null)
            {
                return item;
            }

            return Location.Locate(id);

        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name} {base.FullDescription}\n" + "You are carrying:\n" + _inventory.ItemList;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);

            writer.WriteLine(Inventory.ItemList);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            string ItemDescriptionList = reader.ReadLine();

            //display the information to Console
            Console.WriteLine("Player information");
            Console.WriteLine(Name);
            Console.WriteLine(ShortDescription);
            Console.WriteLine(ItemDescriptionList);

        }
    }
}