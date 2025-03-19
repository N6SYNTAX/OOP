using NUnit.Framework;
using Task_3_1;

namespace Task_3_1.Tests
{
    [TestFixture]
    public class IdentifiableObjectTests
    {

        [Test]
        public void AreYou_ValidIdentifier_ReturnsTrue()
        {
            var idents = new string[] { "studentid", "john", "doe" };
            var obj = new IdentifiableObject(idents);
            bool result = obj.AreYou("john");
            Assert.IsTrue(result);
        }


        [Test]
        public void AreYou_InvalidIdentifier_ReturnsFalse()
        {
            var idents = new string[] { "studentid", "john", "doe" };
            var obj = new IdentifiableObject(idents);
            bool result = obj.AreYou("jane");
            Assert.IsFalse(result);
        }

        // Test that AreYou works in a case-insensitive manner.
        [Test]
        public void AreYou_CaseInsensitive_ReturnsTrue()
        {
            var idents = new string[] { "JohnDoe", "StudentID" };
            var obj = new IdentifiableObject(idents);
            bool result1 = obj.AreYou("johndoe");
            bool result2 = obj.AreYou("STUDENTid");
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        // Test that FirstId returns the first identifier when identifiers are present.
        [Test]
        public void FirstId_WithIdentifiers_ReturnsFirstIdentifier()
        {
            var idents = new string[] { "first", "second", "third" };
            var obj = new IdentifiableObject(idents);
            Assert.AreEqual("first", obj.FirstId);
        }

        // Test that FirstId returns an empty string when there are no identifiers.
        [Test]
        public void FirstId_NoIdentifiers_ReturnsEmptyString()
        {
            var obj = new IdentifiableObject(new string[] { });
            Assert.AreEqual(string.Empty, obj.FirstId);
        }

        // Test that after adding an identifier, the object can recognize it.
        [Test]
        public void AddIdentifier_NewIdentifier_CanBeFound()
        {
            var idents = new string[] { "alpha" };
            var obj = new IdentifiableObject(idents);
            obj.AddIdentifier("beta");
            Assert.IsTrue(obj.AreYou("beta"));
        }

        // Test that after removing an identifier, the object no longer recognizes it.
        [Test]
        public void RemoveIdentifier_ExistingIdentifier_CannotBeFound()
        {
            var idents = new string[] { "gamma" };
            var obj = new IdentifiableObject(idents);
            obj.RemoveIdentifier("gamma");
            Assert.IsFalse(obj.AreYou("gamma"));
        }

        // Test that privilege escalation with the correct pin updates the first identifier.

        [Test]
        public void PrivilegeEscalation_CorrectPin_UpdatesFirstIdentifier()
        {
            var idents = new string[] { "original", "other" };
            var obj = new IdentifiableObject(idents);
            obj.PrivilegeEscalation("8669");
            Assert.AreEqual("1-13", obj.FirstId);
        }

        // Test that privilege escalation with an incorrect pin does not update the first identifier.
        [Test]
        public void PrivilegeEscalation_IncorrectPin_DoesNotUpdateFirstIdentifier()
        {
            var idents = new string[] { "original", "other" };
            var obj = new IdentifiableObject(idents);
            obj.PrivilegeEscalation("0000");
            Assert.AreEqual("original", obj.FirstId);
        }
    }
    [TestFixture]
    public class ItemTests
    {
        // Test that the item is identifiable (inherits AreYou functionality)
        [Test]
        public void Item_IsIdentifiable_ReturnsTrueForValidIdentifier()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            Item item = new Item(idents, "bronze sword", "A sword made of bronze.");

            // The item should recognize its identifiers (in a case-insensitive manner)
            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsTrue(item.AreYou("BRONZE SWORD"));
        }

        // Test that the Name property returns the correct item name
        [Test]
        public void Item_NameProperty_ReturnsCorrectName()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            Item item = new Item(idents, "bronze sword", "A sword made of bronze.");

            Assert.AreEqual("bronze sword", item.Name);
        }

        // Test that ShortDescription returns the proper formatted string "a [name] ([first id])"
        [Test]
        public void Item_ShortDescription_ReturnsCorrectFormat()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            Item item = new Item(idents, "bronze sword", "A sword made of bronze.");
            // Expected: first identifier is "sword"
            string expected = "a bronze sword (sword)";
            Assert.AreEqual(expected, item.ShortDescription);
        }

        // Test that LongDescription returns the full description provided during construction
        [Test]
        public void Item_LongDescription_ReturnsFullDescription()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            string desc = "A finely crafted bronze sword with intricate designs.";
            Item item = new Item(idents, "bronze sword", desc);
            Assert.AreEqual(desc, item.LongDescription);
        }

        // Test that privilege escalation with the correct pin updates the first identifier
        // (Assumes your implementation updates the first identifier to "1-13" when pin "8669" is used)
        [Test]
        public void Item_PrivilegeEscalation_CorrectPin_UpdatesFirstIdentifier()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            Item item = new Item(idents, "bronze sword", "A sword made of bronze.");

            // Call privilege escalation with the correct pin ("8669")
            item.PrivilegeEscalation("8669");
            // Now the first identifier should be updated to "1-13"
            Assert.AreEqual("1-13", item.FirstId);
        }

        // Test that privilege escalation with an incorrect pin does not update the first identifier
        [Test]
        public void Item_PrivilegeEscalation_IncorrectPin_DoesNotUpdateFirstIdentifier()
        {
            string[] idents = new string[] { "sword", "bronze sword" };
            Item item = new Item(idents, "bronze sword", "A sword made of bronze.");

            // Call privilege escalation with an incorrect pin
            item.PrivilegeEscalation("0000");
            // The first identifier should remain unchanged ("sword")
            Assert.AreEqual("sword", item.FirstId);
        }
    }
}