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
    public partial class edit : Window
    {
        BusModel bus;
        BusPark nbp;
        Bus oldb;
        public edit(BusPark bp, Bus old)
        {
            InitializeComponent();
            bus = new BusModel();
            DataContext = bus;
            nbp = bp;
            oldb = old;
            Num.Text = old.Num.ToString();
            name.Text = old.DriverName;
            route.Text = old.Route.ToString();
            status.SelectedIndex = old.Status;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Добавление
        {
            if (int.TryParse(Num.Text, out int k) && (int.TryParse(route.Text, out int b) || route.Text == "") && name.Text != "")
            {
                if (nbp.CheckNum(k) && oldb.Num != k)
                    MessageBox.Show("Данный номер уже занят!");
                else
                {
                    this.DialogResult = true;
                }

            }
            else
            {
                MessageBox.Show("Неправильно введены данные");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Num.Text = oldb.Num.ToString();
            name.Text = oldb.DriverName;
            route.Text = oldb.Route.ToString();
            status.SelectedIndex = oldb.Status;
        }
    }
}

