using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Player : GameObject
    {
        private Inventory _inventory; // This specific players inventory

        public Player(string name, string desc)
        // passing up identifiers me and inventory
            : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                //Console.WriteLine("Success");
                return this;

            }
            else
            {
                return Inventory.Fetch(id);
            }
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