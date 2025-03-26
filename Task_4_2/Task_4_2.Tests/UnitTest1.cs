using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class IdentifiableObjectTests
    {
        private IdentifiableObject obj;



        [SetUp]
        public void IdentSetUp()
        {
            var idents = new string[] { "104548669", "Sean", "Kelly" };
            obj = new IdentifiableObject(idents);

        }

        [Test]
        public void Test_AreYou_Correct()
        {
            bool result = obj.AreYou("Sean");
            bool result2 = obj.AreYou("104548669");
            Assert.IsTrue(result);
        }


        [Test]
        public void Test_AreYou_Incorrect()
        {
            var idents = new string[] { "104548669", "Sean", "Kelly" };
            var obj = new IdentifiableObject(idents);
            bool result = obj.AreYou("1o4548669");
            Assert.IsFalse(result);
        }

        // Test that AreYou works if capitalization is incorrect.
        [Test]
        public void Test_CaseInsensitive()
        {
            bool result1 = obj.AreYou("SeAn");
            bool result2 = obj.AreYou("KeLlY");
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        // Test that FirstId returns the first identifier when identifiers are present.
        [Test]
        public void Test_FirstId()
        {
            var idents = new string[] { "1000", "T1001", "T1002" };
            var obj = new IdentifiableObject(idents);
            Assert.AreEqual("1000", obj.FirstId);
        }

        // Test that FirstId returns an empty string when there are no identifiers.
        [Test]
        public void Test_FirstId_ReturnsEmptyString()
        {
            var obj = new IdentifiableObject(new string[] { });
            Assert.AreEqual(string.Empty, obj.FirstId);
        }

        // Test that after adding an identifier the object can recognize it.
        [Test]
        public void Test_AddIdentifier()
        {
            var idents = new string[] { "stew", "peeled", "cut up" };
            var obj = new IdentifiableObject(idents);
            obj.AddIdentifier("apple");
            Assert.IsTrue(obj.AreYou("apple"));
        }
    }
    [TestFixture]
    public class ItemTests
    {
        private Item item;

        [SetUp]
        public void SetupItem()
        {
            // Create an item with identifiers, name, and description.
            // Here, "sword" is used as the first identifier.
            item = new Item(new string[] { "sword", "bronze sword" }, "Bronze Sword", "A fierce fighting instrument");
        }

        [Test]
        public void Test_ItemIsIdentifiable()
        {
            // The item should respond to AreYou requests for its identifiers.
            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsTrue(item.AreYou("bronze sword"));
        }

        [Test]
        public void Test_ShortDescription()
        {
            // The short description should be in the format: "a {name} ({first id})"
            string expected = $"a {item.Name} ({item.FirstId})";
            Assert.AreEqual(expected, item.ShortDescription);
        }

        [Test]
        public void Test_FullDescription()
        {
            // The full description should return the complete description.
            Assert.AreEqual("A fierce fighting instrument", item.LongDescription);
        }

        [Test]
        public void Test_ItemPrivilegeEscalation()
        {
            // Test that privilege escalation works for an item.
            // Since Item inherits from IdentifiableObject, it should behave similarly.
            var testItem = new Item(new string[] { "007", "James" }, "Test Sword", "A test sword");
            testItem.PrivilegeEscalation("8669");
            Assert.AreEqual("1-13", testItem.FirstId);
        }



        // Test that privilege escalation with the correct pin updates the first identifier.

        [Test]
        public void Test_PrivilegeEscalation()
        {
            var idents = new string[] { "T1000", "Terminator" };
            var obj = new IdentifiableObject(idents);
            obj.PrivilegeEscalation("8669");

            Assert.AreEqual("1-13", obj.FirstId);
        }
    }

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

        [Test]
        public void Test_ItemList()
        {
            Inv.Put(Apple);
            Inv.Put(Bannana);
            Inv.Put(Shield);

            Assert.AreEqual(Apple.Name + "\n\t" + Apple.ShortDescription + "\n" +
                            Bannana.Name + "\n\t" + Bannana.ShortDescription + "\n" +
                            Shield.Name + "\n\t" + Shield.ShortDescription + "\n", Inv.ItemList);

        }
    }

}

