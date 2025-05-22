using System;
namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {

        // private Inventory _paths;
        private List<Path> _paths;
        private Inventory _inventory;
        private string _desc;
        private string _name;



        public Location(string[] ids, string name, string desc)
        : base(ids, name, desc)
        {
            //_paths = new Inventory();
            _paths = new List<Path>();
            _inventory = new Inventory();
            _desc = desc;

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


        public List<Path> Paths
        {
            get
            {
                return _paths;
            }
        }


        // public Inventory Paths
        // {
        //     get
        //     {
        //         return _paths;
        //     }
        // }

        // public GameObject Locate(string id)
        // {
        //     if (AreYou(id))
        //     {
        //         //Console.WriteLine("Success");
        //         return this;

        //     }
        //    else
        //     {
        //          return _paths.Fetch(id);
        //     }


        // }



        public override string FullDescription
        {
            get
            {
                string nameDescription;
                string inventoryDescription;
                if (Name != null && Name != "")
                {
                    nameDescription = Name;
                }
                else
                {
                    nameDescription = "an unknown location";
                }

                if (_inventory != null && _inventory.ItemList != null)
                {
                    inventoryDescription = _inventory.ItemList;
                }
                else
                {
                    inventoryDescription = "There are no items at this location";
                }
                return "You are in " + nameDescription + "." +
                base.FullDescription +
                "\n Here, you can see : \n" + inventoryDescription;
            }
        }

        public void Put(Path p)
        {
            _paths.Add(p);
        }

        public bool HasPath(string id)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }



        public Path? Fetch(string id)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }

            return null;
        }

        public string WorldMap
        {
            get
            {
                string list = "";

                List<string> Map = new List<string>();
                foreach (Path p in _paths)
                {
                    Map.Add(p.FullDescription);
                }
                list = string.Join(",", Map);
                return list;

            }
        }


    }
}

