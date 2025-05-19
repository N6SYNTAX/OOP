using System;
namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {

        private string location;
        private string desc;


        public Path(string[] ids, string _location, string _desc)
             : base(ids)
        {
            _location = location;
            _desc = desc;
        }

        public string BackStory
        {
            get
            {
                return $"\n\n\n\nYou are standing at the base of an old weatherd tree, with long twisting knots spanning the entire length of the trunk.\nAt the base of the door you notice an overgrown door with vines and tree growth partially covering it.\nWould you like to proceed through the door? ";
            }
        }

         public string Hole
        {
            get
            {
                return $"\n*THUMP* you slide down a long worming hole and land flat on your back in what appears to be a caveren with several paths leading away from you. You look back up at the hole you fell through, and there is no way back up";
        }
        }

        public string Description
        {
            get
            {
                desc;
            }
        }

    }

}



