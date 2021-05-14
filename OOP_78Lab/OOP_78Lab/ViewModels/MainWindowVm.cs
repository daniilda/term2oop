using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows.Baml2006;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOP_78Lab
{
    public class MainWindowVm : BaseViewModel
    {

        #region Private Properties
        

        #endregion

        #region Public Properties

        private List<Shape> _canvChildren;
        public List<Shape> CanvChildren
        {
            get => _canvChildren;
            set
            {
                _canvChildren = value;
                OnPropertyChanged();
            } 
        }


        private Canvas _canv;
        public Canvas Canv
        {
            get => _canv;
            set
            {
                _canv = value;
                OnPropertyChanged();
            }
        }
        
        
        private string _info;
        public string Info
        {
            get => _info;
            set
            {
                _info = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Controllers
        
        private Controller _create;
        public Controller Create
        {
            get
            {
                return _create ??
                       (_create = new Controller(obj => {}
                       ));
            }
        }
        
        
        #endregion

        public MainWindowVm()
        {

        }




    }
}