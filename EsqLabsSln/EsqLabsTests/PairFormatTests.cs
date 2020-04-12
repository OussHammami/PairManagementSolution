using EsqLabsSln.Converters;
using EsqLabsSln.Helpers;
using EsqLabsSln.Models;
using NUnit.Framework;

namespace EsqLabsTests
{
    public class PairFormatTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("plane", true)]
        [TestCase("plane123", true)]
        [TestCase("123=", false)]
        [TestCase("plane,", false)]
        [Test]
        public void TestValidFormatPair(string text, bool expValidation)
        {
            bool validationResult = PairHelper.ValidFormat(text);
            Assert.AreEqual(expValidation, validationResult);
        }

        [TestCase("plane = airbus", false)]
        [TestCase("plane == airbus", false)]
        [TestCase("name = airbus765", true)]
        [TestCase("value = 756", true)]
        [TestCase("name == airbus765", false)]
        [TestCase("value == 756", false)]
        [TestCase("name =", false)]
        [TestCase("value =", false)]
        [Test]
        public void TestValidFormatFilter(string text, bool expValidation)
        {
            bool validationResult = PairHelper.ValidFilterFormat(text);
            Assert.AreEqual(expValidation, validationResult);
        }

        [TestCase("plane = airbus", true)]
        [TestCase("plane == airbus", false)]
        [TestCase("plane123 = airbus765", true)]
        [TestCase("123 = 756", true)]
        [TestCase("plane", false)]
        [TestCase("=", false)]
        [Test]
        public void TestTryParsePair(string text, bool expectedParse)
        {
            bool ParseResult = PairConverter.TryParse(text, out Pair outPair);
            Assert.AreEqual(expectedParse, ParseResult);
        }
    }
}