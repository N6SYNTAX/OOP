using System;
namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {

        private List<Path> _paths;


        public Location()
        {
            _paths = new List<Path>();

        }


        Inventory

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

        public void AddPath(Path p)
        {
            _paths.Add(p);
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
                    Map.Add(p.Description);
                }
                list = string.Join(",", Map);
                return list;

            }
        }


    }
}

