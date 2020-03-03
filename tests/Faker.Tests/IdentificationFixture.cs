using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class IdentificationFixture
    {
        [Test]
        public void Should_Create_SSN()
        {
            var ssn = Identification.SocialSecurityNumber();
            Console.WriteLine($@"SSN=[{ssn}]");
            Assert.IsTrue(Regex.IsMatch(ssn, @"\d{3}-\d{2}-\d{4}"));
        }

        [Test]
        public void Should_Create_MBI()
        {
            var mbi = Identification.MedicareBeneficiaryIdentifier();
            Console.WriteLine($@"MBI=[{mbi}]");
            Assert.IsTrue(Regex.IsMatch(mbi, @"\b[1-9][AC-HJKMNP-RT-Yac-hjkmnp-rt-y][AC-HJKMNP-RT-Yac-hjkmnp-rt-y0-9][0-9]-?[AC-HJKMNP-RT-Yac-hjkmnp-rt-y][AC-HJKMNP-RT-Yac-hjkmnp-rt-y0-9][0-9]-?[AC-HJKMNP-RT-Yac-hjkmnp-rt-y]{2}\d{2}\b"));
        }

        [Test]
        public void Should_Create_UKNationalInsuranceNumber()
        {
            var nin = Identification.UKNationalInsuranceNumber();
            Console.WriteLine($@"NIN=[{nin}]");
            Assert.IsTrue(Regex.IsMatch(nin, @"^\s*[a-zA-Z]{2}(?:\s*\d\s*){6}[a-zA-Z]?\s*$"));
        }
    }
}