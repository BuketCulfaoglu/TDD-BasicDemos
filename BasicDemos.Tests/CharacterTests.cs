namespace BasicDemos.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void ShouldSetName()
        {
            const string expected = "Marry";
            Character c = new Character(CharacterType.Elf, expected);

            Assert.That(c.Name, Is.EqualTo(expected));
            Assert.That(c.Name, Is.Not.Empty);
            Assert.That(c.Name, Contains.Substring("rry"));
        }

        [Test]
        public void ShouldSetNameCaseInsensitive()
        {
            const string expectedUpperCase = "MARRY";
            const string expectedLowerCase = "marry";
            Character c = new Character(CharacterType.Elf, expectedUpperCase);

            Assert.That(c.Name, Is.EqualTo(expectedLowerCase).IgnoreCase);
        }

        [Test]
        public void DefaultHealtIs100()
        {
            const int expectedHealth = 100;

            Character c = new Character(CharacterType.Elf);

            Assert.That(c.Health, Is.EqualTo(expectedHealth));
            Assert.That(c.Health, Is.Positive);
        }

        [Test]
        public void ElfSpeedIsCorrect()
        {
            const double expectedSpeed = 1.7;

            Character c = new Character(CharacterType.Elf);

            Assert.That(c.Speed, Is.EqualTo(expectedSpeed));
        }

        [Test]
        public void OrkSpeedIsCorrect()
        {
            const double expectedSpeed = 1.4;

            Character c = new Character(CharacterType.Ork);

            Assert.That(c.Speed, Is.EqualTo(expectedSpeed));
        }

        [Test]
        public void OrkSpeedIsCorrectWithTolerance()
        {
            const double expectedSpeed = 0.3 + 1.1;

            Character c = new Character(CharacterType.Ork);

            Assert.That(c.Speed, Is.EqualTo(expectedSpeed).Within(0.5));
            Assert.That(c.Speed, Is.EqualTo(expectedSpeed).Within(1).Percent);
        }

        [Test]
        public void DefaultCharacterArmorShouldBeGreaterThan30AndLessThan100()
        {
            Character c = new Character(CharacterType.Elf);
            Assert.That(c.Armor, Is.GreaterThan(30).And.LessThan(100));
            Assert.That(c.Armor, Is.InRange(50, 100));
        }

        [Test]
        public void DefaultNameIsNull()
        {
            Character c = new Character(CharacterType.Elf);
            Assert.That(c.Name, Is.Null);
        }

        [Test]
        public void IsDeadKillCharacterReturnsTrue()
        {
            Character c = new Character(CharacterType.Elf);
            c.Damage(500);
            Assert.That(c.IsDead, Is.True);
        }

        [Test]
        public void SameCharactersAreEqualByReference()
        {
            Character c1 = new Character(CharacterType.Elf);
            Character c2 = c1;

            Assert.That(c1, Is.SameAs(c2));
        }

        [Test]
        public void ObjectCharacterType()
        {
            object c = new Character(CharacterType.Elf);
            Assert.That(c, Is.TypeOf<Character>());
        }

        [Test]
        public void Damage1001ThrowsArgumentOutOfRange()
        {
            Character c = new Character(CharacterType.Elf);

            Assert.Throws<ArgumentOutOfRangeException>(() => c.Damage(1001));
        }

        [Test]
        public void CollectionTests()
        {
            var c = new Character(CharacterType.Elf);
            c.Weaponry.Add("Knife");
            c.Weaponry.Add("Pistol");
            c.Weaponry.Add("Shotgun");

            Assert.That(c.Weaponry, Is.Not.Empty);
            Assert.That(c.Weaponry, Contains.Item("Knife"));
            Assert.That(c.Weaponry, Has.Exactly(3).Length);
            Assert.That(c.Weaponry, Has.Exactly(1).EndWith("gun"));
            Assert.That(c.Weaponry, Is.Unique);
            Assert.That(c.Weaponry, Is.Ordered);

            var c2 = new Character(CharacterType.Ork);
            c2.Weaponry.Add("Knife");
            c2.Weaponry.Add("Pistol");
            c2.Weaponry.Add("Shotgun");

            Assert.That(c.Weaponry, Is.EquivalentTo(c2.Weaponry));
        }
    }
}
