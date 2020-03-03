using System;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class FinanceFixture
    {
        [Test]
        public void should_return_an_isin()
        {
            var isin = Finance.Isin();
            Console.WriteLine($@"ISIN=[{isin}]");
            Assert.That(isin, Is.Not.Empty);
            Assert.That(isin.Length, Is.EqualTo(12));
        }

        [Test]
        public void should_return_a_ticker()
        {
            var ticker = Finance.Ticker();
            Console.WriteLine($@"Ticker=[{ticker}]");
            Assert.That(ticker, Is.Not.Empty);
        }

        [Test]
        public void should_return_a_coupon()
        {
            var coupon = Finance.Coupon();
            Console.WriteLine($@"Coupon=[{coupon}]");
            Assert.That(coupon, Is.GreaterThan(0));
        }

        [Test]
        public void should_return_a_maturity_in_the_future()
        {
            var date = DateTime.Now.Date;
            var maturity = Finance.Maturity();

            Assert.That(maturity, Is.GreaterThan(date));
            Assert.That((maturity - date).TotalDays, Is.GreaterThan(180));
        }

        [Test]
        public void should_return_a_maturity_in_the_past()
        {
            var date = DateTime.Now.Date;
            var maturity = Finance.Maturity(-120, -6);

            Assert.That(maturity, Is.LessThan(date));
        }

        [Test]
        public void should_return_a_credit_bond_name()
        {
            var bondName = Finance.Credit.BondName();
            Console.WriteLine($@"BondName=[{bondName}]");
            Assert.That(bondName, Is.Not.Empty);
        }

        [Test]
        public void should_return_a_credit_bond()
        {
            var bond = Finance.Credit.BondClass();
            Console.WriteLine($@"Bond=[{bond}]");
            Assert.That(bond, Is.Not.Null);
        }
    }
}