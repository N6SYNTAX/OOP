using NUnit.Framework;
using Task_3_1;

namespace Task_3_1.Tests
{
    [TestFixture]
    public class IdentifiableObjectTests
    {
        private IdentifiableObject obj;

        [SetUp]
        public void SetUp()
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



        // Test that privilege escalation with the correct pin updates the first identifier.

        [Test]
        public void Test_PrivilegeEscalation()
        {
            var idents = new string[] { "T1000", "Terminator" };
            var obj = new IdentifiableObject(idents);
            obj.PrivilegeEscalation("8669");

            Assert.AreEqual("1-13", obj.FirstId);
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
}