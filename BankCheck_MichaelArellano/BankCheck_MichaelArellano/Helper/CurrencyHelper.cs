using System.Globalization;
using Softest.Numbers.InWords;

namespace BankingCheck_MichaelArellano.Helper
{ 
    public static class CurrencyHelper
    {
        public static string CurrencyToWords(decimal amountInNumber)
        {
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

            var amountInWords = generator.CurrencyInWords(amountInNumber, options) ;

            return amountInWords.Substring(0, 1).ToUpper() + amountInWords.Substring(1);
        }
    }
}