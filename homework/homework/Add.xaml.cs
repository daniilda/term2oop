using homework.Models;
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

namespace homework
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        BusModel bus;
        BusPark nbp;
        public Add(BusPark bp)
        {
            InitializeComponent();
            bus = new BusModel();
            DataContext = bus;
            nbp = bp;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Добавление
        {
            if(int.TryParse(Num.Text, out int k) && (int.TryParse(route.Text, out int b) || route.Text == "") && name.Text != "")
            {
                if (nbp.CheckNum(k))
                    MessageBox.Show("Данный номер уже существует!");
                else
                {
                    this.DialogResult = true;
                }
               
            } else
            {
                MessageBox.Show("Неправильно введены данные");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Num.Text = nbp.Lastnum().ToString();
        }
    }
}
