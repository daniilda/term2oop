using System.Windows.Navigation;
using _2Term_OOP_Lab5.Models.Classes;

namespace _2Term_OOP_Lab5.Models
{
    public class BankAccounts
    {

        #region Public Properties
        
        private decimal _moneyBasicAmount = 0;

        public decimal MoneyBasicAmount
        {
            get => (_moneyBasicAmount/_currencyK);
            set => _moneyBasicAmount = value * _currencyK;
        }

        public decimal MoneyAmount
        {
            get => _moneyBasicAmount;
            set => _moneyBasicAmount = value;
        }

        private byte _currency = 0;
        public byte Currency
        {
            get => _currency;
            set
            {
                _currency = value;
                switch (Currency)
                {
                    case 0:
                        _currencyK = Currencies.Rub;
                        break;
                    case 1:
                        _currencyK =  Currencies.Brl;
                        break;
                    case 2:
                        _currencyK =  Currencies.Jpy;
                        break;
                    default:
                        _currencyK =  Currencies.Rub;
                        break;
                }
            }
        } // 0 = RUB, 1 = BRL, 2 = JPY;




        #endregion

        #region Private Properties

        private decimal _currencyK = 1.00m;

        #endregion

        #region Private Methods



        #endregion

        #region Methods



        #endregion

    }
}