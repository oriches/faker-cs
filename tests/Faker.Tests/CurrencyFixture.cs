using System;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class CurrencyFixture
    {
        [Test]
        public void should_return_three_letter_currency_code()
        {
            var currency = Currency.ThreeLetterCode();
            Console.WriteLine($@"ThreeLetterCode=[{currency}]");
            Assert.That(currency.Length, Is.EqualTo(3));
        }

        [Test]
        public void should_return_currency_name()
        {
            var currency = Currency.Name();
            Console.WriteLine($@"Name=[{currency}]");
            Assert.That(currency, Is.Not.Empty);
        }
    }
}