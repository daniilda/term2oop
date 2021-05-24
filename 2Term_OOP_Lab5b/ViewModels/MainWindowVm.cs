using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Baml2006;
using _2Term_OOP_Lab4;
using _2Term_OOP_Lab5.Models;
using _2Term_OOP_Lab5.Models.Classes;

namespace _2Term_OOP_Lab5
{
    public class MainWindowVm : BaseViewModel
    {

        #region Private Properties

        private static BankOperations _bank;

        private static IDialogService _dialogService;
        

        #endregion

        #region Public Properties
        
        public decimal FirstBankAccount
        {
            get =>  Math.Round(_bank.GetAmountOfMoney(false),2);
            set
            {
                _bank.SetAmountOfMoney(value, false);
                OnPropertyChanged();
            }
        }
        
        public decimal SecondBankAccount
        {
            get => Math.Round(_bank.GetAmountOfMoney(true),2);
            set
            {
                _bank.SetAmountOfMoney(value, true);
                OnPropertyChanged();
            }
        }
        
        private decimal _transactionAmount;
        public decimal TransactionAmount
        {
            get => _transactionAmount;
            set
            {
                _transactionAmount = value; 
                OnPropertyChanged();
            }
        }

        private List<string> _currencyList;
        public List<string> CurrencyList
        {
            get
            {
                _currencyList = Currencies.GetCurrenciesList();
                return _currencyList;
            }

        }
        
        // ReSharper disable once InconsistentNaming
        public int SelectedCurrencyFBA
        {
            get => _bank.GetCurrency(false);
            set
            {
                if (value == _bank.GetCurrency(false) || _bank.GetAmountOfMoney(false) == 0)
                {
                    _bank.SetCurrencyOfAccount((byte) value, false);
                    FirstBankAccount = _bank.GetAmountOfMoney(false);
                    OnPropertyChanged();
                }
                else
                {
                    var dialog = new YesNoDialogViewModel("Коммисия", $"{FirstBankAccount * 0.01m}");
                    var result = _dialogService.OpenDialog(dialog);
                    if (result == DialogResult.Yes) _bank.SetCurrencyOfAccount((byte) value, false);
                    FirstBankAccount = _bank.GetAmountOfMoney(false);
                    SelectedCurrencyFBA = _bank.GetCurrency(false);
                    OnPropertyChanged();
                }
            }
        }
        
        

        // ReSharper disable once InconsistentNaming
        public byte SelectedCurrencySBA
        {
            get => _bank.GetCurrency(true);
            set
            {
                if (value == _bank.GetCurrency(true) || _bank.GetAmountOfMoney(true) == 0)
                {
                    _bank.SetCurrencyOfAccount((byte) value, true);
                    SecondBankAccount = _bank.GetAmountOfMoney(true);
                    OnPropertyChanged();
                }
                else
                {
                    var dialog = new YesNoDialogViewModel("Комисcия", $"Комиссия за конвертацию составит {SecondBankAccount * 0.01m}");
                    var result = _dialogService.OpenDialog(dialog);
                    if (result == DialogResult.Yes) _bank.SetCurrencyOfAccount((byte) value, true);
                    SecondBankAccount = _bank.GetAmountOfMoney(true);
                    SelectedCurrencySBA = _bank.GetCurrency(true);
                    OnPropertyChanged();
                }
            }
        }
        
        private byte _selectedCurrencyT = 0;

        public byte SelectedCurrencyT
        {
            get => _selectedCurrencyT;
            set
            {
                _selectedCurrencyT = value;
                OnPropertyChanged();
            }
        }

        private bool _typeOfTransaction = true;

        public bool TypeOfTransaction
        {
            get => _typeOfTransaction;
            set
            {
                _typeOfTransaction = value;
                OnPropertyChanged();
            }
        }

        

        #endregion

        #region Controllers

        private Controller _makeTransaction;
        public Controller MakeTransaction
        {
            get
            {
                return _makeTransaction ??
                       (_makeTransaction = new Controller(obj =>
                       {
                           switch (_bank.PreTransaction(_transactionAmount, _selectedCurrencyT, _typeOfTransaction, out var fee))
                           {
                               case 0:
                                   var dialog = new YesNoDialogViewModel("Внимание", $"Перевод будет выполнен без комиссии");
                                   var result = _dialogService.OpenDialog(dialog);
                                   if (result == DialogResult.Yes) _bank.MakeTransaction(_transactionAmount, _selectedCurrencyT, _typeOfTransaction);
                                   FirstBankAccount = _bank.GetAmountOfMoney(false);
                                   SecondBankAccount = _bank.GetAmountOfMoney(true);
                                   break;
                               case 1:
                                   var dialog1 = new YesNoDialogViewModel("Внимание", $"Для первого счёта комиссия составит {fee[0]}, для второго счета {fee[1]}");
                                   var result1 = _dialogService.OpenDialog(dialog1);
                                   if (result1 == DialogResult.Yes) _bank.MakeTransaction(_transactionAmount, _selectedCurrencyT, _typeOfTransaction);
                                   FirstBankAccount = _bank.GetAmountOfMoney(false);
                                   SecondBankAccount = _bank.GetAmountOfMoney(true);
                                   break;
                               case 2:
                                   var dialog2 = new AlertDialogViewModel("Внимание", "Недостаточно средств для совершения операции");
                                   var result2 = _dialogService.OpenDialog(dialog2);
                                   break;
                               default:
                                   break;
                           }
                               
                       }));
            }
        }
        
        

        #endregion

        public MainWindowVm()
        {
            _dialogService = new DialogService();
            _bank = new BankOperations();
        }




    }
}