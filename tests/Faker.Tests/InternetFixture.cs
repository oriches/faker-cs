using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class InternetFixture
    {
        [Test]
        public void Should_Create_Email_Address()
        {
            var email = Internet.Email();
            Console.WriteLine($@"Email=[{email}]");

            Assert.IsTrue(Regex.IsMatch(email, @".+@.+\.\w+"));
        }

        [Test]
        public void Should_Create_Email_Address_From_Given_Name()
        {
            var email = Internet.Email("Bob Smith");
            Console.WriteLine($@"Email=[{email}]");

            Assert.IsTrue(Regex.IsMatch(email, @"bob[_\.]smith@.+\.\w+"));
        }

        [Test]
        public void Should_Create_Free_Email()
        {
            var email = Internet.FreeEmail();
            Console.WriteLine($@"Email=[{email}]");

            Assert.IsTrue(Regex.IsMatch(email, @".+@(gmail|hotmail|yahoo)\.com"));
        }

        [Test]
        public void Should_Create_User_Name()
        {
            var username = Internet.UserName();
            Console.WriteLine($@"UserName=[{username}]");

            Assert.IsTrue(Regex.IsMatch(username, @"[a-z]+((_|\.)[a-z]+)?"));
        }

        [Test]
        public void Should_Create_User_Name_From_Given_Name()
        {
            var username = Internet.UserName("Bob Smith");
            Console.WriteLine($@"UserName=[{username}]");

            Assert.IsTrue(Regex.IsMatch(username, @"bob[_\.]smith"));
        }

        [Test]
        public void Should_Get_Domain_Name()
        {
            var domain = Internet.DomainName();
            Console.WriteLine($@"DomainName=[{domain}]");

            Assert.IsTrue(Regex.IsMatch(domain, @"\w+\.\w+"));
        }

        [Test]
        public void Should_Get_Domain_Word()
        {
            var word = Internet.DomainWord();
            Console.WriteLine($@"DomainWord=[{word}]");

            Assert.IsTrue(Regex.IsMatch(word, @"^\w+$"));
        }

        [Test]
        public void Should_Get_Domain_Suffix()
        {
            var suffix = Internet.DomainSuffix();
            Console.WriteLine($@"DomainSuffix=[{suffix}]");

            Assert.IsTrue(Regex.IsMatch(suffix, @"^\w+(\.\w+)?"));
        }
    }
}