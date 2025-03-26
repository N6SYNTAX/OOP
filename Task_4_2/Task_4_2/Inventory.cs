
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }


        public Item? Take(string id)
        {
            Item? found = null;
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    found = item;
                    break;
                }
            }
            if (found != null)
            {
                _items.Remove(found);
            }
            return found;
        }


        public Item? Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }

            return null;
        }

        public string ItemList
        {
            get
            {
                string ItmList = "";
                foreach (Item item in _items)
                {
                    ItmList += item.Name + "\n\t" + item.ShortDescription + "\n";
                }

                if (ItmList == "")
                {
                    Console.WriteLine("Inventory Empty!");
                }
                return ItmList;
            }
        }

    }
}