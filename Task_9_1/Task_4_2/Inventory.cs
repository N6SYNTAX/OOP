
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


                // string ItmList = "";
                // foreach (Item item in _items)
                // {
                //     ItmList += item.FirstId + item.Name + "\n\t" + item.ShortDescription + "\n";
                // }

                // if (ItmList == "")
                // {
                //     Console.WriteLine("Inventory Empty!");
                // }
                // return ItmList;

            }
        }


        // public void LoadFrom(StreamReader reader)
        // {

        //     base.LoadFrom(reader);
        //     string ItemDescriptionList = reader.ReadLine();

        //     //display the information to Console
        //     Console.WriteLine("Player information");
        //     Console.WriteLine(Name);
        //     Console.WriteLine(ShortDescription);
        //     Console.WriteLine(ItemDescriptionList);
        // }

        // public void LoadFrom(StreamReader reader)
        // {
        //     var line = reader.ReadLine();
        //     if (line == null) return;
        //     foreach (l)
        //     {
        //         var p = part.Trim();
        //         var s = p.LastIndexOf('(');
        //         var e = p.LastIndexOf(')');
        //         var id = (s >= 0 && e > s) ? p.Substring(s + 1, e - s - 1) : p;
        //         _items.Add(new Item(new[] { id }, id, ""));
        //     }

    }
}