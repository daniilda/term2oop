using System.Runtime.InteropServices.WindowsRuntime;
using _2Term_OOP_Lab5.Models.Classes;

namespace _2Term_OOP_Lab5.Models
{
    public class BankOperations
    {
        #region Private Properties

        private static BankAccounts _firstAccount;
        private static BankAccounts _secondAccount;

        #endregion

        #region Public Methods

        #region Actions with accounts
        
        public void SetAmountOfMoney(decimal amount, bool number)
        {
            if (!number)
            {
                _firstAccount.MoneyBasicAmount = amount;
            }
            else
            {
                _secondAccount.MoneyBasicAmount = amount;
            }
        }

        public void SetCurrencyOfAccount(byte currency, bool number)
        {
            if (!number)
            {
                _firstAccount.Currency = currency;
                _firstAccount.MoneyBasicAmount -= _firstAccount.MoneyBasicAmount * 0.01m;
            }
            else
            {
                _secondAccount.Currency = currency;
                _secondAccount.MoneyBasicAmount -= _secondAccount.MoneyBasicAmount * 0.01m;
            }
        }

        public decimal GetAmountOfMoney(bool number)
        {
            return !number ? _firstAccount.MoneyBasicAmount : _secondAccount.MoneyBasicAmount;
        }

        public byte GetCurrency(bool number)
        {
            return !number ? _firstAccount.Currency : _secondAccount.Currency;
        }
        
        #endregion

        #region Transactions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="number"></param>
        /// <param name="trasactionfee"></param>
        /// <returns>0#Successful with no fee // 1#Successful with fee // 2#NotEnoughMoney</returns>
        public byte PreTransaction(decimal amount, byte currency, bool number, out decimal[] trasactionfee)
        {
            if (currency == 0) amount = amount * Currencies.Rub;
            if (currency == 1) amount = amount * Currencies.Brl;
            if (currency == 2) amount = amount * Currencies.Jpy;
            var original = amount;
            var secondfee = 0.00m;
            var transactions = 0;
            trasactionfee = new decimal[2];
            trasactionfee[0] = 0;
            trasactionfee[1] = 0;
            if (amount == 0)
            {
                return 5;
            }
            if (number)
            {
                
                if (currency != _firstAccount.Currency)
                {
                    amount = _convert(amount, _firstAccount.Currency, currency);
                    transactions += 1;
                }
                
                if (currency != _secondAccount.Currency)
                {
                    secondfee = _convert(original, currency, _secondAccount.Currency);
                    transactions += 1;
                }
                
                if (_firstAccount.MoneyBasicAmount < amount)
                {
                        trasactionfee[0] = amount - original;
                        return 2;
                }
                
                if (transactions == 0)
                {
                        return 0;
                }
                
                trasactionfee[0] = amount - original;
                if (secondfee != 0) trasactionfee[1] = secondfee - original;
                return 1;

            }
            else
            {
                if (currency != _secondAccount.Currency)
                {
                    amount = _convert(amount, _secondAccount.Currency, currency);
                    transactions += 1;
                }
                
                if (currency != _firstAccount.Currency)
                {
                    secondfee = _convert(original, currency, _firstAccount.Currency);
                    transactions += 1;
                }
                
                if (_secondAccount.MoneyBasicAmount < amount)
                {
                    trasactionfee[0] = amount - original;
                    return 2;
                }
                
                if (transactions < 1)
                {
                    return 0;
                }
                
                trasactionfee[0] = amount - original;
                trasactionfee[1] = secondfee - original;
                return 1;
                
            }
        }
        public void MakeTransaction(decimal amount, byte currency, bool number)
        {
            if (currency == 0) amount = amount * Currencies.Rub;
            if (currency == 1) amount = amount * Currencies.Brl;
            if (currency == 2) amount = amount * Currencies.Jpy;
            var original = amount;
            if (number)
            {
                if (currency != _firstAccount.Currency)
                {
                    amount = _convert(amount, _firstAccount.Currency, currency); //Количество которое должно сняться с первого аккаунта
                }
                
                if (currency != _secondAccount.Currency)
                {
                    original -= (_convert(original, currency, _secondAccount.Currency) - original); //Количество которое должно зачислиться
                }
                _secondAccount.MoneyAmount = _secondAccount.MoneyAmount + original;
                _firstAccount.MoneyAmount = _firstAccount.MoneyAmount - amount;
            }
            else
            {
                if (currency != _secondAccount.Currency)
                {
                    amount = _convert(amount, _secondAccount.Currency, currency);
                }
                
                if (currency != _firstAccount.Currency)
                {
                    original -= (_convert(original, currency, _secondAccount.Currency) - original);
                }
                _firstAccount.MoneyAmount = _firstAccount.MoneyAmount + original;
                _secondAccount.MoneyAmount = _secondAccount.MoneyAmount - amount;
            }
        }

        #endregion

        #endregion

        #region Private Methods
        
        private decimal _convert(decimal amount, byte curfrom , byte curto)
        {
           return amount + amount * 0.01m;
        }

        #endregion


        public BankOperations()
        {
            _firstAccount = new BankAccounts();
            _secondAccount = new BankAccounts();
        }

    }
}