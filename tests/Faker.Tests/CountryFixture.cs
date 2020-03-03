using System;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class CountryFixture
    {
        [Test]
        public void should_return_two_letter_country_code()
        {
            var currency = Country.TwoLetterCode();
            Console.WriteLine($@"TwoLetterCode=[{currency}]");
            Assert.That(currency.Length, Is.EqualTo(2));
        }

        [Test]
        public void should_return_country_name()
        {
            var name = Country.Name();
            Console.WriteLine($@"Name=[{name}]");
            Assert.That(name, Is.Not.Empty);
        }
    }
}