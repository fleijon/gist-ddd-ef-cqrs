using System;
using System.Collections.Generic;

namespace SharedKernel
{
    public partial class Currency : ValueObject<Currency>
    {
        public static Currency USDollar => new Currency("USD", "$");
        public static Currency Euro => new Currency("EUR", "€");

        public static Currency FromCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            return code switch
            {
                "USD" => new Currency(USDollar.Code, USDollar.Symbol),
                "EUR" => new Currency(Euro.Code, Euro.Symbol),
                _ => throw new BusinessRuleException($"Invalid code {code}")
            };
        }

        public static List<string> SupportedCurrencies()
        {
            return new List<string>() { USDollar.Code, Euro.Code };
        }
    }

    /// <summary>
    /// <see href=https://github.com/falberthen/EcommerceDDD/blob/master/src/EcommerceDDD.Domain/SharedKernel/Currency.cs>Source</see>
    /// </summary>
    public partial class Currency : ValueObject<Currency>
    {
        public string Code { get; }
        public string Symbol { get; }

        internal Currency(string code, string symbol)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new BusinessRuleException("Code cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(symbol))
                throw new BusinessRuleException("Symbol cannot be null or whitespace.");

            Code = code;
            Symbol = symbol;
        }

        protected override bool EqualsCore(Currency other)
        {
            return Code == other.Code && Symbol == other.Symbol;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Code.GetHashCode();
                hashCode = (hashCode * 397) ^ Symbol.GetHashCode();
                return hashCode;
            }
        }
    }
}