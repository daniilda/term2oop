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

        private static DbConnection connection;

        #endregion

        #region Public Properties

        private string testtext;

        public string Testtext
        {
            get => testtext;
            set
            {
                testtext = value;
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
                       (_request = new Controller(async obj =>
                           {
                               if (await connection.test())
                               {
                                   Testtext = "Connected";
                               }
                               Testtext = "NotConnected";
                           }
                       ));
            }
        }
        
        
        #endregion

        public MainWindowVm()
        {
            connection = new DbConnection();
        }




    }
}