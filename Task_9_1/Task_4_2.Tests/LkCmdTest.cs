// LookCommandTests.cs
using NUnit.Framework;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LookCommandTests
    {
        private Player _player;
        private Bag _bag;
        private Item _gem, _torch;
        private LookCommand _look;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("Sean", "A Developer");
            _gem = new Item(new[] { "gem" }, "Red Gem", "A bright red gem");
            _bag = new Bag(new[] { "bag" }, "Leather Bag", "A small leather bag");
            _torch = new Item(new[] { "torch" }, "Torch", "A wooden torch");
            _player.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_torch);
            _look = new LookCommand();
        }

        [Test]
        public void Test_LookAtMe_ReturnsPlayerDescription()
        {
            var result = _look.Execute(_player, new[] { "look", "at", "inventory" });
            Assert.AreEqual(_player.FullDescription, result);
        }

        [Test]
        public void Test_LookAtGem_ReturnsGemDescription()
        {
            var result = _look.Execute(_player, new[] { "look", "at", "gem" });
            Assert.AreEqual(_gem.FullDescription, result);
        }

        [Test]
        public void Test_LookAtUnk_ReturnsNotFound()
        {
            var result = _look.Execute(_player, new[] { "look", "at", "ruby" });
            Assert.AreEqual("I cannot find the ruby", result);
        }

        [Test]
        public void Test_LookAtGemInMe_ReturnsGemDescription()
        {
            var result = _look.Execute(_player, new[] { "look", "at", "gem", "in", "inventory" });
            Assert.AreEqual(_gem.FullDescription, result);
        }

        [Test]
        public void Test_LookAtTorchInBag_ReturnsTorchDescription()
        {
            var result = _look.Execute(_player, new[] { "look", "at", "torch", "in", "bag" });
            Assert.AreEqual(_torch.FullDescription, result);
        }

        [Test]
        public void Test_LookAtGemInNoBag_ReturnsBagNotFound()
        {
            var result = _look.Execute(_player, new[] { "look", "at", "gem", "in", "sack" });
            Assert.AreEqual("I cannot find the sack", result);
        }

        [Test]
        public void Test_LookAtNoGemInBag_ReturnsGemNotFound()
        {
            var result = _look.Execute(_player, new[] { "look", "at", "ruby", "in", "bag" });
            Assert.AreEqual("I cannot find the ruby", result);
        }

        [Test]
        public void Test_InvalidLook_ReturnsErrorMessage()
        {
            Assert.AreEqual("I don't know how to look like that", _look.Execute(_player, new[] { "look", "around" }));
            Assert.AreEqual("Error in look input", _look.Execute(_player, new[] { "hello", "at", "gem" }));
            Assert.AreEqual("What do you want to look at?", _look.Execute(_player, new[] { "look", "around", "gem" }));
            Assert.AreEqual("What do you want to look in?", _look.Execute(_player, new[] { "look", "at", "gem", "inside", "bag" }));
        }
    }
}
