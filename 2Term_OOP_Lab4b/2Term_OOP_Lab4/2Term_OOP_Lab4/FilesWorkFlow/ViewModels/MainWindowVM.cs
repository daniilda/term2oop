using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Threading;

namespace _2Term_OOP_Lab4
{

    public class MainWindowVm : BaseViewModel
    {


        #region Private Properties

        private readonly DispatcherTimer _tm = new DispatcherTimer();
        private Charts[] _charts;
        private bool _isTimerActive = false;
        private int _timervalue;

        #endregion


        #region Public Properties

        private string _pathOut;
        public string PathOut
        {
            get => _pathOut;
            private set
            {
                _pathOut = value;
                OnPropertyChanged();
            }
        }


        private string _windowTitle;
        public string WindowTitle
        {
            get => _windowTitle;
            private set
            {
                _windowTitle = value;
                OnPropertyChanged();
            }
        }

        private Canvas _board;
        public Canvas Board
        {
            get => _board;
            private set
            {
                _board = value;
                OnPropertyChanged();
            }
        }

        private int _timer;
        public int Timer
        {
            get => _timer;
            private set
            {
                _timer = value;
                OnPropertyChanged();
            }
        }

        private string _time;
        public string Time
        {
            get => _time;
            set
            {
                if (!int.TryParse(value, out var x)) return;
                _time = value;
                OnPropertyChanged();
            }
        }
      

        #endregion

        #region Commands

        private Controler _createNewGraph;
        public Controler CreateNewGraph
        {
            get
            {
                return _createNewGraph ??
                       (_createNewGraph = new Controler(obj =>
                       {
                           Board.Children.Clear();
                           _charts = DiagramDrawing.GetRandomCharts();
                           Board.Children.Add(DiagramDrawing.GetPieChart(_charts, 500, 500));
                           Board = Board;

                       }));
            }
        }
        
        private Controler _recordNewGraph;
        public Controler RecordNewGraph
        {
            get
            {
                return _recordNewGraph ??
                       (_recordNewGraph = new Controler(obj =>
                       {
                           if (_charts == null) return;
                           if (PathOut == null)
                           {
                               FilesWork.WriteChartsInFile(@"../../newchart.txt", _charts);
                               PathOut = @"../../newchart.txt";
                           }

                       }));
            }
        }

        private Controler _readGraph;
        public Controler ReadGraph
        {
            get
            {
                return _readGraph ??
                       (_readGraph = new Controler(obj =>
                       {
                           if (FilesWork.GetChartsFromFile(PathOut, FileType.Txt) == null) return;
                           Board.Children.Clear();
                           Board.Children.Add(DiagramDrawing.GetPieChart(
                               FilesWork.GetChartsFromFile(PathOut, FileType.Txt),
                               500, 500));
                           Board = Board;
                       }));
            }
        }

        private Controler _openFile;
        public Controler OpenFile
        {
            get
            {
                return _openFile ??
                       (_openFile = new Controler(o =>
                       {
                           var fileDialog = new OpenFileDialog
                           {
                               Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                           };
                           
                           if (fileDialog.ShowDialog() == true)
                           {
                               PathOut = fileDialog.FileName;                    
                           }
                       }));
            }

        }

        private Controler _timerControl;
        public Controler TimerControl
        {
            get
            {
                return _timerControl ??
                       (_timerControl = new Controler(o =>
                       {
                           if (_isTimerActive)
                           {
                               _tm.Stop();
                               _isTimerActive = false;
                           } else
                           {
                               if (Time != null)
                               {
                                   _timervalue = Convert.ToInt32(Time);
                                   Timer = _timervalue;
                                   _tm.Start();
                                   _isTimerActive = true;
                               }
                               

                           }
                           
                       }));
            }

        }

        #endregion

        #region Events

        private void Tm_Tick(object sender, EventArgs e)
        {
            if (Timer == 1)
            {
                Timer -= 1;
                Board.Children.Clear();
                _charts = DiagramDrawing.GetRandomCharts();
                Board.Children.Add(DiagramDrawing.GetPieChart(_charts, 500, 500));
                Board = Board;
                Timer = _timervalue;
            } else
            {
                Timer -= 1;
            }
        }

        #endregion

        #region Methods
        #endregion

        public MainWindowVm()
        {
            WindowTitle = "Лабораторная работа 4: Кузнецов Даниил Андреевич";
           Board = DiagramDrawing.CreateCanvas(500, 500, Brushes.Transparent);
            {
                _tm.Interval = new TimeSpan(0, 0, 1);
                _tm.Tick += Tm_Tick;
            }

        }

    }
    
}