
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

        public Item? FirstItem()
        {
            /*          Item val = val;
                        if (val.Fetch(_items[0].FirstId) != null)
                        {
                            return val;
                        }
                        else
                        {
                            return null;
                        }
            */
            if (_items.Count > 0)
            {
                return _items[0];
            }
            else
            {
                return null;
            }
        }


        public Item? Take(string id)
        {
            Item found = Fetch(id);
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
                string list = String.Empty;

                List<string> ItemDescriptionList = new List<string>();
                foreach (Item itm in _items)
                {
                    ItemDescriptionList.Add(itm.ShortDescription);
                }
                list = string.Join(",", ItemDescriptionList);


                return list;

                /*
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
                */
            }
        }

    }
}