using System;
using System.Runtime.CompilerServices;
namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {

        private Location _destination;
        private string _peek;
        private string _desc;
        private bool _unlock;


        public Path(string[] ids, Location destination, string peek, string desc, bool unlock)
             : base(ids)
        {
            _destination = destination;
            _peek = peek;
            _desc = desc;
            _unlock = unlock;

        }


        public string Peek
        {
            get
            {
                return _peek;
            }
        }

        public string FullDescription
        {
            get
            {
                return _desc;
            }
        }

        public Location Destination 
        {
            get{
                return _destination
            }
        }

    }

}



