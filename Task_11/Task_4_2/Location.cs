using System;
namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {

        private List<Path> _paths;
        private string _desc;

        public Location(string desc)
        {
            _paths = new List<Path>();
            _desc = desc;
        }


        public string FullDescription
        {
            get
            {
                return _desc;
            }
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

