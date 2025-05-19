using System;
namespace SwinAdventure
{
    public class Map
    {

        private List<Path> _paths;

        public Map()
        {
            _paths = new List<Path>();

        }

        public string BackStory
        {
            get
            {
                return $"You are \nYou are standing at the base of an old weatherd tree,\nwith long twisting knots spanning the entire length of the trunk.\nAt the base of the door you notice an overgrown door with vines and tree growth partially covering.\nWould you like to proceed through the door? ";
            }
        }


    }
}

