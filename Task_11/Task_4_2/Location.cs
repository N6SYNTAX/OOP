using System;
namespace SwinAdventure
{
    public class Location : Item, IHaveInventory
    {

        private Inventory _paths;
        private string _desc;

        public Location(string[] ids, string name, string desc)
            : base(ids, name, desc)
        {
            _paths = new Inventory();
            _desc = desc;
        }


        public Inventory Paths
        {
            get
            {
                return _paths;
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
                return Paths.Fetch(id);
            }
        }



        public override string FullDescription
        {
            get
            {
                return _desc;
            }
        }

    //    public void Put(Path p)
    //     {
    //         _paths.Put(p);
    //     }

        // public bool HasPath(string id)
        // {
        //     foreach (Path p in _paths)
        //     {
        //         if (p.AreYou(id))
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }

 

        // public Path? Fetch(string id)
        // {
        //     foreach (Path p in _paths)
        //     {
        //         if (p.AreYou(id))
        //         {
        //             return p;
        //         }
        //     }

        //     return null;
        // }

        // public string WorldMap
        // {
        //     get
        //     {
        //         string list = "";

        //         List<string> Map = new List<string>();
        //         foreach (Path p in _paths)
        //         {
        //             Map.Add(p.FullDescription);
        //         }
        //         list = string.Join(",", Map);
        //         return list;

        //     }
        // }


    }
}

