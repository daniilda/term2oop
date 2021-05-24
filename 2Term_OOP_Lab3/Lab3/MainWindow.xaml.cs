using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        GraphicsCanv graphicscanv = new GraphicsCanv();
        XandOes game = new XandOes();
        List<Line> LineList = new List<Line>();
        double cellX;
        double cellY;

        public async void startgame()
        {
            game.setGM(10);
            for (int i = 9; i > -1; i--)
            {
             
                for (int j = 0; j < 10; j++)
                {
                    await Task.Delay(5);
                    board.Children.Add(graphicscanv.getZeroDrawing(i, j, board.Width, board.Height, 10, 10));
                }
            }

            initGrid(LineList);
            game.setGM(1);
                   
        }

        bool isArrayFull (byte[,] arr)
        {
            for (int i=0; i < 10; i++)
            {
                for (int j=0; j < 10; j++)
                {
                    if (arr[i, j] == 0)
                        return false;
                    else continue;
                }
            }
            return true;
        }

        void endgame(int x1,int y1, int x2, int y2)
        {
            endgameWndw nwin = new endgameWndw();
            board.Children.Add(graphicscanv.winLine(x1, y1, x2, y2));
            nwin.init(game.getGM());
            if (nwin.ShowDialog() == true)
            {
                initGrid(LineList);
                game.init_boardData(10, 10);
                Counter.Text = $"{game.Player1count}:{game.Player2count}";
            } 

        }


        void initGrid(List<Line> __LineList)
        {
            board.Children.Clear();
            for (int i = 0; i < __LineList.Count; i++)
            {
                board.Children.Add(__LineList[i]);
            }
            turnbox.Children.Clear();
            putCrossTurn(graphicscanv.getCrossDrawing(0, 0, turnbox.Width, turnbox.Height, 1, 1));
            this.Title = "Крестики - Нолики: Игра  X";

        }

        void putCrossOnBoard(List<Line> __LineList)
        {
            for (int i = 0; i < __LineList.Count; i++)
            {
                board.Children.Add(__LineList[i]);
            }
        }

        void putCross(List<Line> __LineList)
        {
            for (int i = 0; i < __LineList.Count; i++)
            {
                Cross.Children.Add(__LineList[i]);
            }
        }

        void putCrossTurn(List<Line> __LineList)
        {
            for (int i = 0; i < __LineList.Count; i++)
            {
                turnbox.Children.Add(__LineList[i]);
            }
        }

        double calculateCellCoord(double x, double y, out double yout)
        {
            double xout;
            xout = Math.Floor(x/(board.Width/10));
            yout = Math.Floor(y/(board.Height/10));
            return xout;
        }

        public MainWindow()
        {
            InitializeComponent();
            LineList = graphicscanv.getGridListOfLines(board.Width, board.Height, 10, 10, Brushes.Black, 1);
            initGrid(LineList);
            game.init_boardData(10, 10);
            Player1.Text = game.Player1Name;
            Player2.Text = game.Player2Name;
            Zero.Children.Add(graphicscanv.getZeroDrawing(0, 0, Zero.Width, Zero.Height, 1, 1));
            putCross(graphicscanv.getCrossDrawing(0, 0, Cross.Width, Cross.Height, 1, 1));
            Counter.Text = $"{game.Player1count}:{game.Player2count}";
            startgame();

        }


        private void Window_Initialized(object sender, EventArgs e)
        {

        }

        private void board_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            
            Point __point = Mouse.GetPosition(board);
            cellX = calculateCellCoord(__point.X, __point.Y, out cellY);
            if (game.getGM() == 1)
            {
                if (!game.getTurn())
                {
                    if (game.checkPos(cellX, cellY))
                    {
                        
                            
                        putCrossOnBoard(graphicscanv.getCrossDrawing(cellX, cellY, board.Width, board.Height, 10, 10));
                        game.set_boardData(cellX, cellY);
                        if (game.checkWin(cellX, cellY, out int x1, out int y1, out int x2, out int y2))
                        {
                            game.setGM(2);
                            game.Player1count = game.Player1count + 1;
                            endgame(x1, y1, x2, y2);
                        } else if (!isArrayFull(game.get_boardData()))
                        { 
                        game.setTurn();
                            turnbox.Children.Clear();
                            turnbox.Children.Add(graphicscanv.getZeroDrawing(0, 0, turnbox.Width, turnbox.Height, 1, 1));
                            this.Title = "Крестики - Нолики: Игра  O";
                           
                        } else
                        {
                            game.setGM(0);
                            endgame(0, 0, 0, 0);
                        }
                            
                       
                    }
                } else
                {
                    if (game.checkPos(cellX, cellY))
                    {
                        board.Children.Add(graphicscanv.getZeroDrawing(cellX, cellY, board.Width, board.Height, 10, 10));
                        game.set_boardData(cellX, cellY);
                        if (game.checkWin(cellX, cellY, out int x1, out int y1, out int x2, out int y2))
                        {
                            game.setGM(3);
                            game.Player2count = game.Player2count + 1;
                            endgame(x1, y1, x2, y2);
                        }
                        else if (!isArrayFull(game.get_boardData())) { 
                            game.setTurn();
                        turnbox.Children.Clear();
                        putCrossTurn(graphicscanv.getCrossDrawing(0, 0, turnbox.Width, turnbox.Height, 1, 1));
                        this.Title = "Крестики - Нолики: Игра  X";
                        }
                        else
                            {
                        game.setGM(0);
                        endgame(0, 0, 0, 0);
                             }

                    }
                    
                }

            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            initGrid(LineList);
            game.init_boardData(10, 10);
            if (game.getTurn())
                game.setTurn();
            game.setGM(1);
            //game.Player1count = 0;
            //game.Player2count = 0;
            //Counter.Text = $"{game.Player1count}:{game.Player2count}";

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new Window1();
            this.Hide();
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (game.Player1count > game.Player2count && game.getGM() != 10)
            {
                var win = new endgameWndw();
                game.setGM(4);
                win.init(game.getGM());
                if (win.ShowDialog() == false)
                {
                    var wins = new Window1();
                    this.Hide();
                    wins.Show();

                }


            } else if (game.Player2count > game.Player1count && game.getGM() != 10)
            {
                var win = new endgameWndw();
                game.setGM(5);
                win.init(game.getGM());
                if (win.ShowDialog() == false)
                {
                    var wins = new Window1();
                    this.Hide();
                    wins.Show();
                }

            } else if (game.Player1count == game.Player2count && game.getGM() != 10)
            {
                var win = new endgameWndw();
                game.setGM(6);
                win.init(game.getGM());
                if (win.ShowDialog() == false)
                {
                    var wins = new Window1();
                    this.Hide();
                    wins.Show();
                }

            } 
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
 }

