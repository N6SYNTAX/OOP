using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{

    [TestFixture]
    public class InventoryTests
    {
        private Inventory Inv;
        private Item Apple;
        private Item Bannana;
        private Item Sword;
        private Item Shield;

        [SetUp]
        public void InventorySetup()
        {
            Inv = new Inventory();
            Apple = new Item(new string[] { "a" }, "Apple", "A Delicious Fruit");
            Bannana = new Item(new string[] { "b" }, "Bannana", "A Fuit with A Peel");
            Sword = new Item(new string[] { "W" }, "Bronze Sword", "A feirce fighting instrument");
            Shield = new Item(new string[] { "S" }, "Wooden Shield", "Will protect you... I guess");

        }
        [Test]
        public void Test_FindItem()
        {
            Inv.Put(Apple);

            Assert.IsTrue(Inv.HasItem("a"));
        }

        [Test]
        public void Test_No_FindItem()
        {
            Inv.Put(Sword);

            Assert.IsFalse(Inv.HasItem("a"));
        }

        [Test]
        public void Test_FetchItem()
        {
            Inv.Put(Sword);
            Inv.Fetch("w");

            Assert.IsTrue(Inv.HasItem("w"));
        }

        [Test]
        public void Test_TakeItem()
        {
            Inv.Put(Sword);
            Inv.Take("w");

            Assert.IsFalse(Inv.HasItem("w"));
        }

        //     [Test]
        //     public void Test_ItemList()
        //     {
        //         Inv.Put(Apple);
        //         Inv.Put(Bannana);
        //         Inv.Put(Shield);

        //         Assert.AreEqual(Apple.Name + "\n\t" + "a " + Apple.ShortDescription + "\n"
        //   + Bannana.Name + "\n\t" + "a " + Bannana.ShortDescription + "\n"
        //   + Shield.Name + "\n\t" + "a " + Shield.ShortDescription + "\n", Inv.ItemList);
        //     }

        [Test]
        public void Test_FirstItem()
        {
            Assert.IsNull(Inv.FirstItem());
            Inv.Put(Apple);
            Inv.Put(Bannana);
            Assert.AreEqual(Apple, Inv.FirstItem());
        }
    }

}

