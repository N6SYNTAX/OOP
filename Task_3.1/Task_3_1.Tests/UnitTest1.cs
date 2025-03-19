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
}
