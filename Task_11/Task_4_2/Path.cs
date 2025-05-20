using System;
using System.Runtime.CompilerServices;
namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {

        private Location _destination;
        private string _peak;
        private string _desc;
        private bool _unlock;


        public Path(string[] ids, Location destination, string peak, string desc, bool unlock)
             : base(ids)
        {
            _destination = destination;
            _peak = peak;
            _desc = desc;
            _unlock = unlock;

        }

        public string BackStory
        {
            get
            {
                return $"\n\n\n\nYou are standing at the base of an old weatherd tree, with long twisting knots spanning the entire length of the trunk.\nAt the base of the door you notice an overgrown door with vines and tree growth partially covering it.\nWould you like to proceed through the door? ";
            }
        }

        public string Peak
        {
            get
            {
                return _peak;
            }
        }

        public string Description
        {
            get
            {
                return _desc;
            }
        }

    }

}



