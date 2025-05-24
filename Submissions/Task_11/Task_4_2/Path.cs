using System;
using System.Runtime.CompilerServices;
namespace SwinAdventure
{
    public class Path : GameObject
    {

        private Location _destination;
        private string _peek;
        private string _desc;
        private bool _unlock;


        public Path(string[] ids, Location destination, string name, string peek, string desc, bool unlock)
             : base(ids, name, desc)
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

        public override string FullDescription
        {
            get
            {
                return _desc;
            }
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

    }

}



