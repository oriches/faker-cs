using System;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Faker.Tests
{
    [TestFixture]
    public class NameFixture
    {
        [Test]
        public void Should_Get_FullName()
        {
            var name = Name.FullName();
            Console.WriteLine($@"Name=[{name}]");
            Assert.IsTrue(Regex.IsMatch(name, @"^(\w+\.? ?){2,3}$"));
        }

        [Test]
        public void Should_Get_FullName_With_Standard_Format()
        {
            var name = Name.FullName(NameFormats.Standard);
            Console.WriteLine($@"Name=[{name}]");
            Assert.IsTrue(Regex.IsMatch(name, @"^[A-Za-z\/\s\.'\-]+? [A-Za-z\/\s\.'\-]+?$"));
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
    }
}