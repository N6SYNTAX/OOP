using System;
namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {

        public Path(string[] ids)
             : base(ids)
        {
        }

        public string BackStory
        {
            get
            {
                return $"\n\n\n\nYou are standing at the base of an old weatherd tree, with long twisting knots spanning the entire length of the trunk.\nAt the base of the door you notice an overgrown door with vines and tree growth partially covering it.\nWould you like to proceed through the door? ";
            }
        }

    }
}

