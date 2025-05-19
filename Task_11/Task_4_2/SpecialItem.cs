using System;

namespace SwinAdventure
{
    public class SpecialItem : GameObject
    {
        private string _feature;
        public SpecialItem(string[] ids, string name, string desc, string feature)
        : base(ids, name, desc)
        {
            _feature = feature;
        }

        public string Feature
        {
            get { return _feature; }
        }
    }
}
