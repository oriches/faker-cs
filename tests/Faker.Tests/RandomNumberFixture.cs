using System;
using System.Linq;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class RandomNumberFixture
    {
        [TestCase(1, "Coin flip")] // 0 ... 1 Coin flip
        [TestCase(6, "6 sided die")] // 0 .. 6
        [TestCase(9, "Random single digit")] // 0 ... 9
        [TestCase(20, "D20")] // 0 ... 20  The signature dice of the dungeons and dragons
        public void Should_Yield_All_ValuesWithinRange(int maxValue, string testName)
        {
            var maxExclusiveLimit = maxValue + 1;
            Console.WriteLine($@"RandomNumber.Next [{testName}]");
            var results = Enumerable.Range(0, maxExclusiveLimit).ToDictionary(k => k, k => false);
            do
            {
                var randValue = RandomNumber.Next(0, maxExclusiveLimit);
                results[randValue] = true;
                Console.WriteLine($@"RandomNumber.Next(0,{maxExclusiveLimit})=[{randValue}]");
            } while (!results.All(j => j.Value));

            Assert.IsTrue(results.Select(z => z.Value).All(y => y));
        }

        [Test]
        public void Should_Create_Zero()
        {
            var zero = RandomNumber.Next(0, 0);
            Console.WriteLine($@"RandomNumber.Next(0,0)=[{zero}]");

            Assert.IsTrue(zero == 0);
        }

        [Test]
        public void Should_Create_Same_With_Seed()
        {
            const int amount = 1000;
            var expected = new int[amount];
            RandomNumber.SetSeed(4321);
            for (var i = 0; i < amount; i++)
            {
                expected[i] = RandomNumber.Next();
            }
            RandomNumber.SetSeed(4321);
            for (var i = 0; i < amount; i++)
            {
                var actual = RandomNumber.Next();
                Assert.AreEqual(expected[i], actual, $"Not equal at position {i}");
            }
        }

        [Test]
        public void Should_Generate_Maximum()
        {
            var result = false;
            for (var i = 0; i < 1000000; i++)
            {
                var number = RandomNumber.Next(0, 1);
                if (number == 1)
                {
                    result = true;
                    break;
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void Should_Generate_Minimum()
        {
            var result = false;
            for (var i = 0; i < 1000000; i++)
            {
                var number = RandomNumber.Next(0, 1);
                if (number == 0)
                {
                    result = true;
                    break;
                }
            }

            Assert.IsTrue(result);
        }
    }
}