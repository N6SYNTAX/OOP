using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{

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

            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsTrue(item.AreYou("bronze sword"));
        }

        [Test]
        public void Test_ShortDescription()
        {

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
}