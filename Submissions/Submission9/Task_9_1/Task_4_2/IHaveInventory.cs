
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public interface IHaveInventory
    {

        GameObject Locate(string id);

        string Name { get; }
    }
}