using System.Collections.Generic;
using System.Windows.Documents;

namespace _2Term_OOP_Lab5.Models.Classes
{
    public static class Currencies
    {
        public const decimal Rub = 1.00m;
        public const decimal Brl = 14.15m;
        public const decimal Jpy = 70.92m;
        public static List<string> GetCurrenciesList()
        {
            var list = new List<string> {"RUB", "BRL", "JPY"};
            return list;
            }
    }
}