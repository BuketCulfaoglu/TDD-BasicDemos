using System.Collections;

namespace BasicDemos.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        private Character _character;

        [SetUp]
        public void Setup()
        {
            _character = new Character(CharacterType.Elf);
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

        [Test]
        public void Damage1001ThrowsArgumentOutOfRange()
        {
            Character c = new Character(CharacterType.Elf);

            Assert.Throws<ArgumentOutOfRangeException>(() => c.Damage(1001));
        }

        [Test]
        public void CharacterTypeWrongThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                int armor = (new Character((CharacterType)5)).Armor;
            });
        }

        [Test]
        public void DefaultCharacterArmorShouldBeGreaterThan30AndLessThan110()
        {
            Assert.That(_character.Armor, Is.GreaterThan(40).And.LessThan(110));

            Character c = new Character(CharacterType.Ork);
            Assert.That(c.Armor, Is.GreaterThan(30).And.LessThan(110));
            Assert.That(c.Armor, Is.InRange(50, 110));
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
        public void DefaultNameIsNull()
        {
            Character c = new Character(CharacterType.Elf);
            Assert.That(c.Name, Is.Null);
        }

        [Test]
        public void DefaultWearIs15()
        {
            Assert.That(_character.Wear, Is.EqualTo(15));
        }

        [Test]
        public void SetWearCorrect()
        {
            _character.ChangeWear(20);
            Assert.That(_character.Wear, Is.EqualTo(20));
        }

        [Test]
        public void ElfSpeedIsCorrect()
        {
            const double expectedSpeed = 1.7;

            Character c = new Character(CharacterType.Elf);

            Assert.That(c.Speed, Is.EqualTo(expectedSpeed));
        }

        [TestCase(100, 45)]
        [TestCase(80, 65)]
        public void HealthDamageReturnsCorrectValue(int damage, int expectedHealth)
        {
            _character.Damage(damage);
            Assert.That(_character.Health, Is.EqualTo(expectedHealth));
        }

        [TestCaseSource(typeof(DamageSource))]
        public void HealthDamageReturnsCorrectValueEnumerator(int damage, int expectedHealth)
        {
            _character.Damage(damage);
            Assert.That(_character.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void IsDeadKillCharacterReturnsTrue()
        {
            Character c = new Character(CharacterType.Elf);
            c.Damage(500);
            Assert.That(c.IsDead, Is.True);
        }

        [Test]
        public void ObjectCharacterType()
        {
            object c = new Character(CharacterType.Elf);
            Assert.That(c, Is.TypeOf<Character>());
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
        public void SameCharactersAreEqualByReference()
        {
            Character c1 = new Character(CharacterType.Elf);
            Character c2 = c1;

            Assert.That(c1, Is.SameAs(c2));
        }



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
        public void ShouldSetNameCorrect()
        {
            const string expected = "Marry";
            _character.Name = expected;

            Assert.That(_character.Name, Is.EqualTo(expected));
            Assert.That(_character.Name, Is.Not.Empty);
            Assert.That(_character.ToString(), Is.EqualTo(expected));

        }

        [Test]
        public void ShouldSetNameCaseInsensitive()
        {
            const string expectedUpperCase = "MARRY";
            const string expectedLowerCase = "marry";
            Character c = new Character(CharacterType.Elf, expectedUpperCase);

            Assert.That(c.Name, Is.EqualTo(expectedLowerCase).IgnoreCase);
        }


        [TearDown]
        public void Teardown()
        {
            _character.Dispose();
            _character = null;
        }
    }

    public class DamageSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new int[] { 100, 45 };
            yield return new int[] { 80, 65 };
        }
    }
}