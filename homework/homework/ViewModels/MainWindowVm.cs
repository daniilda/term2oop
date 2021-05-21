using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows.Baml2006;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using homework.Models;

namespace homework
{
    public class MainWindowVm : BaseViewModel
    {

        #region Private Properties
        

        #endregion

        #region Public Properties

        private List<Bus> _buspark;
        public List<Bus> BusPark
        {
            get => _buspark;
            set
            {
                _buspark = value;
                OnPropertyChanged();
            }
        }
        
        private List<Bus> _inpark;
        public List<Bus> InPark
        {
            get => _inpark;
            set
            {
                _inpark = value;
                OnPropertyChanged();
            }
        }
        
        private List<Bus> _outpark;
        public List<Bus> OutPark
        {
            get => _outpark;
            set
            {
                _outpark = value;
                OnPropertyChanged();
            }
        }
        
        #endregion

        #region Controllers
        
        private Controller _request;
        public Controller Request
        {
            get
            {
                return _request ??
                       (_request = new Controller(obj =>
                           {
                           }
                       ));
            }
        }
        
        
        #endregion

        public MainWindowVm()
        {
        }




    }
}