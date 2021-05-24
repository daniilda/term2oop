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
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для endgameWndw.xaml
    /// </summary>
    public partial class endgameWndw : Window
    {

        XandOes game = new XandOes();

        public endgameWndw()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var game = new XandOes();
            if (game.getGM() > 3)
            {
                this.DialogResult = false;
                this.Hide();
            }
            

            else
            {
                game.setGM(1);
                this.DialogResult = true;
                this.Hide();
            }
        }

        internal void init(byte GM)
        {
            if (GM == 2)
            {
                PlayerName.Text = game.Player1Name;
                Status.Text = "ПОБЕДИЛ";
                this.Title = "К - Н: ПОБЕДИЛ" + game.Player1Name;
            } else if (GM == 3)
            {
                PlayerName.Text = game.Player2Name;
                Status.Text = "ПОБЕДИЛ";
                this.Title = "К - Н: ПОБЕДИЛ" + game.Player2Name;
            }
            else if (GM == 0)
            {
                PlayerName.Text = "";
                Status.Text = "НИЧЬЯ";
                this.Title = "К - Н: НИЧЬЯ" + game.Player1Name;
            } else if (GM == 4)
            {
                PlayerName.Text = game.Player1Name;
                Status.FontSize = 36;
                Status.Text = "ПОБЕДИЛ В ЭТОЙ ИГРЕ";
                this.Title = "К - Н: ПОБЕДИЛ" + game.Player1Name;
                cont.Content = "Новая игра";
            } else if (GM == 5)
            {
                PlayerName.Text = game.Player2Name;
                Status.FontSize = 36;
                Status.Text = "ПОБЕДИЛ В ЭТОЙ ИГРЕ";
                this.Title = "К - Н: ПОБЕДИЛ" + game.Player2Name;
                cont.Content = "Новая игра";
            } else if (GM == 6)
            {
                PlayerName.Text = "";
                Status.Text = "НИЧЬЯ";
                this.Title = "К - Н: НИЧЬЯ" + game.Player2Name;
                cont.Content = "Новая игра";
            }
        }

        
    }
}
