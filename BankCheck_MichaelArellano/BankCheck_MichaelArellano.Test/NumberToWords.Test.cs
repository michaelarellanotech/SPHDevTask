using System;

using NUnit.Framework;
using Softest.Numbers.InWords;

namespace BankingCheck_MichaelArellano.Helper.Test
{

    [TestFixture]
    public class NumberToWordsTest
    {

        [SetUp]
        public void init()
        {
           
        }

        [TestCase(0.01, "zero dollars and 1/100 cent")]
        [TestCase(0.99, "zero dollars and 99/100 cents")]
        [TestCase(1.99, "one dollar and 99/100 cents")]
        [TestCase(100.00, "one hundred dollars")]
        [TestCase(9999.00, "nine thousand nine hundred and ninety-nine dollars")]
        [TestCase(12345.25, "twelve thousand three hundred and forty-five dollars and 25/100 cents")]
        public void NumberToWordsTestCases
            (decimal amountDecimal, string expectedAmountInWords)
        {
            // Arrange
            INumberInWords generator = InWordsFactory.GetGenerator(LanguageType.English_GB);

            var options = new CurrencyInWordsOptions
            {
                Decimals = 2,
                FractionStyle = FractionPartStyle.AsFraction,
                MainCurrency = new Noun { Singular = "dollar", Plural = "dollars" },
                FormatString = "{0} {1} {2} {3} {4}",
                HideZeroFractionPart = true,
                AllowNounReordering = false,
                FormatString_ZeroFraction = "{0} {1}",
                FractionalCurrency = new Noun { Singular = "cent", Plural = "cents" },                 
            };

            // Act
            string amountInWords = generator.CurrencyInWords(amountDecimal, options);

            // Assert
            Assert.That(amountInWords, Is.EqualTo(expectedAmountInWords));
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
    
}