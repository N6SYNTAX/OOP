using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class BagTests
    {
        private Bag Sack;
        private Bag Briefcase;
        private Item Apple;
        private Item Bannana;
        private Item Sword;
        private Item Shield;

        [SetUp]
        public void BagSetup()
        {
            Briefcase = new Bag(new string[] { "me", "brief" }, "Briefcase", "A leather Briefcase");
            Sack = new Bag(new string[] { "me", "sack" }, "Sack", "A canvas sack");
            Apple = new Item(new string[] { "a" }, "Apple", "A Delicious Fruit");
            Bannana = new Item(new string[] { "b" }, "Bannana", "A Fuit with A Peel");
            Sword = new Item(new string[] { "W" }, "Bronze Sword", "A feirce fighting instrument");
            Shield = new Item(new string[] { "S" }, "Wooden Shield", "Will protect you... I guess");

        }
        [Test]
        public void Bag_LocatesItem()
        {
            Sack.Inventory.Put(Apple);

            Assert.IsTrue(Sack.Inventory.HasItem("a"));
        }

        [Test]
        public void Bag_LocatesSelf()
        {
            Assert.AreSame(Sack, Sack.Locate("sack"));
        }

        [Test]
        public void Bag_LocatesNothing()
        {
            Assert.IsNull(Sack.Locate("Carrot"));
        }

        [Test]
        public void Bag_FullDescription()
        {

            Sack.Inventory.Put(Apple);
            Sack.Inventory.Put(Sword);

            ;

            Assert.That(Sack.FullDescription, Does.Contain($"In the {Sack.Name} you can see:"));
            Assert.That(Sack.FullDescription, Does.Contain(Apple.ShortDescription));
            Assert.That(Sack.FullDescription, Does.Contain(Sword.ShortDescription));


        }

        [Test]
        public void Bag_InBag()
        {

            Briefcase.Inventory.Put(Apple);
            Sack.Inventory.Put(Briefcase);
            Assert.AreSame(Briefcase, Sack.Locate("brief"));
            Assert.IsNull(Sack.Locate("a"));
        }

        [Test]
        public void Bag_PrivilegedItem()
        {
            Briefcase.Inventory.Put(Apple);
            Sack.Inventory.Put(Briefcase);
            var secret = new Item(new[] { "secret" }, "Secret", "A hidden secret");
            secret.PrivilegeEscalation("8669");
            Briefcase.Inventory.Put(secret);
            Sack.Inventory.Put(Briefcase);

            Assert.IsNull(Sack.Locate(secret.FirstId));
        }
    }
}
