using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        private Item _testItem1;
        private Item _testItem2;
        private Player _testPlayer;


        [SetUp]
        public void PlayerSetup()
        {
            _testPlayer = new Player("Sean", "A Developer");
            Item _testItem1 = new Item(new string[] { "silver", "hat" }, "A silver Hat", "A very shiny silver hat");
            Item _testItem2 = new Item(new string[] { "light", " torch" }, "A Torch", "A Torch to light the path");
            _testPlayer.Inventory.Put(_testItem1);
            _testPlayer.Inventory.Put(_testItem2);
        }

        [Test]
        public void Identifiable_Player()
        {
            bool result = _testPlayer.AreYou("me");
            Assert.IsTrue(result);
        }

        public void Locate_Item()
        {
            Assert.That(_testPlayer.Locate("light"), Is.EqualTo(_testItem2));
        }

        public void Locate_Player()
        {
            Assert.That(_testPlayer.Locate("me"), Is.EqualTo(_testPlayer));
        }

        public void Locate_Nothing()
        {
            Assert.That(_testPlayer.Locate("x"), Is.EqualTo(null));
        }

        public void FullDescription()
        {
            Assert.AreEqual("A Torch to light the path", _testItem2.FullDescription);
        }



    }
}