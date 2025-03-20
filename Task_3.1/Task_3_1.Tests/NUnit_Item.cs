using NUnit.Framework;
using Task_3_1;

namespace Task_3_1.Tests
{
    [TestFixture]
    public class ItemTests
    {
        private IdentifiableObject item;

        [SetUp]
        public void SetUp()
        {

            var idents = new string[] { "sword", "bronze sword" };
            item = new Item(idents, "bronze sword", "A sword made of bronze.");

        }
        // Test that the item is identifiable (inherits functinality)
        [Test]
        public void Test_Item_Identifiable()
        {

            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsTrue(item.AreYou("BRONZE SWORD"));
        }


        // Test that ShortDescription returns the properly formatted string 
        [Test]
        public void Test_ShortDesc()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            Item item = new Item(idents, "bronze sword", "A sword made of bronze.");

            string expected = "a bronze sword (sword)";
            Assert.AreEqual(expected, item.ShortDescription);
        }

        // Test that LongDescription returns the full description provided 
        [Test]
        public void Test_LongDesc()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            string desc = "A finely crafted bronze sword with glowing and detailed designs.";
            Item item = new Item(idents, "bronze sword", desc);
            Assert.AreEqual(desc, item.LongDescription);
        }

        // Test that privilege escalation with the correct pin updates the first identifier

        [Test]
        public void Test_PrivilegeEscalation()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            Item item = new Item(idents, "bronze sword", "A sword made of bronze.");


            item.PrivilegeEscalation("8669");

            Assert.AreEqual("1-13", item.FirstId);
        }


        // Test that after removing an identifier the object no longer recognizes it.
        [Test]
        public void Test_RemoveIdentifier()
        {
            var idents = new string[] { "John", "Paul", "George" };
            var obj2 = new IdentifiableObject(idents);
            obj2.RemoveIdentifier("John");
            Assert.IsFalse(obj2.AreYou("John"));
        }

    }
}