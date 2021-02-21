using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class NameFixture
    {
        private static readonly Regex FullNamRegex = new Regex(@"(\w+\.?\'? ?){2,3}$", RegexOptions.Compiled);

        [Test]
        public void Should_Get_FullName()
        {
            var name = Name.FullName();
            Console.WriteLine($@"Name=[{name}]");

            Assert.IsTrue(FullNamRegex.IsMatch(name));
        }

        [Test]
        public void Should_Get_FullName_Seeded()
        {
            const int amount = 100;
            var expected = new string[amount];
            RandomNumber.SetSeed(4321);
            for (var i = 0; i < amount; i++)
            {
                expected[i] = Name.FullName();
            }
            RandomNumber.SetSeed(4321);
            for (var i = 0; i < amount; i++)
            {
                var actual = Name.FullName();
                Assert.AreEqual(expected[i], actual, $"Not equal at position {i}");
            }
        }

        [Test]
        public void Should_Get_FullName_With_Standard_Format()
        {
            var name = Name.FullName(NameFormats.Standard);
            Console.WriteLine($@"Name=[{name}]");

            Assert.IsTrue(Regex.IsMatch(name, @"^\w+\.? \w+\'?\.?$"));
        }

        [Test]
        public void Should_Get_FullName_With_Standard_With_Middle_Format()
        {
            var name = Name.FullName(NameFormats.StandardWithMiddle);
            Console.WriteLine($@"Name=[{name}]");

            Assert.IsTrue(Regex.IsMatch(name, @"^\w+\.? \w+\.? \w+\'?\.?$"));
        }

        [Test]
        public void Should_Get_Prefix()
        {
            var prefix = Name.Prefix();
            Console.WriteLine($@"Prefix=[{prefix}]");

            Assert.IsTrue(Regex.IsMatch(prefix, @"^[A-Z][a-z]+\.?$"));
        }

        [Test]
        public void Should_Get_Suffix()
        {
            var suffix = Name.Suffix();
            Console.WriteLine($@"Suffix=[{suffix}]");

            Assert.IsTrue(Regex.IsMatch(suffix, @"^[A-Z][A-Za-z]*\.?$"));
        }

        [Test]
        public void Validate_FullName_Regular_Expressions()
        {
            var firstNames = Resources.Name.First.Split(Config.Separator).ToArray();
            var lastNames = Resources.Name.Last.Split(Config.Separator).ToArray();

            var fullNames = firstNames.SelectMany(firstName => lastNames,
                (firstName, lastName) => $"{firstName.Trim()} {lastName.Trim()}").ToArray();

            foreach (var fullName in fullNames)
            {
                var match = FullNamRegex.IsMatch(fullName);
                if (!match)
                    Console.WriteLine($@"Name=[{fullName}]");

                Assert.IsTrue(match);
            }
        }
    }
}