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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //В связи с ограничениями по времени разработки данного ДЗ под нож ушёл паттерн MVVW ,а так же было принято решение по такому случаю и принцип DRY выкинуть в корзину 
    {
        private static List<Bus> BusPark;
        private static List<Bus> InPark;
        private static List<Bus> OutPark;
        private static BusPark bp;
        public MainWindow() 
        {
            bp = new BusPark();
            BusPark = new List<Bus>();
            InPark = new List<Bus>();
            OutPark = new List<Bus>();
            InitializeComponent();
            busparkgrid.ItemsSource = BusPark;
            inparkgrid.ItemsSource = InPark;
            outparkgrid.ItemsSource = OutPark;

        }



        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //delete buspark
        {
            if (busparkgrid.SelectedItem != null)
            {
                bp.Remove((Bus) busparkgrid.SelectedItem);
                BusPark.Clear();
                OutPark.Clear();
                InPark.Clear();
                BusPark = bp.Buspark.ToList();
                OutPark = bp.OutPark.ToList();
                InPark = bp.InPark.ToList();
                busparkgrid.ItemsSource = BusPark;
                outparkgrid.ItemsSource = OutPark;
                inparkgrid.ItemsSource = InPark;
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) //add bus park
        {
            //bp.Add(1, "Name", 2, 0); //dev debug
            Add dialwnd = new Add(bp);
            if (dialwnd.ShowDialog() == true)
            {
                if (dialwnd.route.Text == "")
                {
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, null, (byte)dialwnd.status.SelectedIndex);
                } else
                bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, Convert.ToInt32(dialwnd.route.Text), (byte)dialwnd.status.SelectedIndex);
            }
            else
            {
            }
            BusPark.Clear();
            OutPark.Clear();
            InPark.Clear();
            BusPark = bp.Buspark.ToList();
            OutPark = bp.OutPark.ToList();
            InPark = bp.InPark.ToList();
            busparkgrid.ItemsSource = BusPark;
            outparkgrid.ItemsSource = OutPark; //Да, можно было запихнуть это в один метод, but what a point?
            inparkgrid.ItemsSource = InPark;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) //edit buspark
        {
            edit dialwnd = new edit(bp, (Bus) busparkgrid.SelectedItem);
            if (dialwnd.ShowDialog() == true)
            {
                if (dialwnd.route.Text == "")
                {
                    bp.Remove((Bus)busparkgrid.SelectedItem);
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, null, (byte)dialwnd.status.SelectedIndex);
                }
                else
                    bp.Remove((Bus)busparkgrid.SelectedItem);
                bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, Convert.ToInt32(dialwnd.route.Text), (byte)dialwnd.status.SelectedIndex);
            }
            else
            {
            }
            BusPark.Clear();
            OutPark.Clear();
            InPark.Clear();
            BusPark = bp.Buspark.ToList();
            OutPark = bp.OutPark.ToList();
            InPark = bp.InPark.ToList();
            busparkgrid.ItemsSource = BusPark;
            outparkgrid.ItemsSource = OutPark; //Да, можно было запихнуть это в один метод, but what a point?
            inparkgrid.ItemsSource = InPark;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) //Add inpark
        {

            //bp.Add(1, "Name", 2, 0); //dev debug
            Add dialwnd = new Add(bp);
            if (dialwnd.ShowDialog() == true)
            {
                if (dialwnd.route.Text == "")
                {
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, null, (byte)dialwnd.status.SelectedIndex);
                }
                else
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, Convert.ToInt32(dialwnd.route.Text), (byte)dialwnd.status.SelectedIndex);
            }
            else
            {
            }
            BusPark.Clear();
            OutPark.Clear();
            InPark.Clear();
            BusPark = bp.Buspark.ToList();
            OutPark = bp.OutPark.ToList();
            InPark = bp.InPark.ToList();
            busparkgrid.ItemsSource = BusPark;
            outparkgrid.ItemsSource = OutPark; //Да, можно было запихнуть это в один метод, but what a point?
            inparkgrid.ItemsSource = InPark;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e) //Del inpark
        {

            if (inparkgrid.SelectedItem != null)
            {
                bp.Remove((Bus)inparkgrid.SelectedItem);
                BusPark.Clear();
                OutPark.Clear();
                InPark.Clear();
                BusPark = bp.Buspark.ToList();
                OutPark = bp.OutPark.ToList();
                InPark = bp.InPark.ToList();
                busparkgrid.ItemsSource = BusPark;
                outparkgrid.ItemsSource = OutPark;
                inparkgrid.ItemsSource = InPark;
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e) //Edit inpark
        {

            edit dialwnd = new edit(bp, (Bus)inparkgrid.SelectedItem);
            if (dialwnd.ShowDialog() == true)
            {
                if (dialwnd.route.Text == "")
                {
                    bp.Remove((Bus)inparkgrid.SelectedItem);
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, null, (byte)dialwnd.status.SelectedIndex);
                }
                else
                    bp.Remove((Bus)inparkgrid.SelectedItem);
                bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, Convert.ToInt32(dialwnd.route.Text), (byte)dialwnd.status.SelectedIndex);
            }
            else
            {
            }
            BusPark.Clear();
            OutPark.Clear();
            InPark.Clear();
            BusPark = bp.Buspark.ToList();
            OutPark = bp.OutPark.ToList();
            InPark = bp.InPark.ToList();
            busparkgrid.ItemsSource = BusPark;
            outparkgrid.ItemsSource = OutPark; //Да, можно было запихнуть это в один метод, but what a point?
            inparkgrid.ItemsSource = InPark;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //add outpark
        {

            //bp.Add(1, "Name", 2, 0); //dev debug
            Add dialwnd = new Add(bp);
            if (dialwnd.ShowDialog() == true)
            {
                if (dialwnd.route.Text == "")
                {
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, null, (byte)dialwnd.status.SelectedIndex);
                }
                else
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, Convert.ToInt32(dialwnd.route.Text), (byte)dialwnd.status.SelectedIndex);
            }
            else
            {
            }
            BusPark.Clear();
            OutPark.Clear();
            InPark.Clear();
            BusPark = bp.Buspark.ToList();
            OutPark = bp.OutPark.ToList();
            InPark = bp.InPark.ToList();
            busparkgrid.ItemsSource = BusPark;
            outparkgrid.ItemsSource = OutPark; //Да, можно было запихнуть это в один метод, but what a point?
            inparkgrid.ItemsSource = InPark;
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e) //del outpark
        {

            if (outparkgrid.SelectedItem != null)
            {
                bp.Remove((Bus)outparkgrid.SelectedItem);
                BusPark.Clear();
                OutPark.Clear();
                InPark.Clear();
                BusPark = bp.Buspark.ToList();
                OutPark = bp.OutPark.ToList();
                InPark = bp.InPark.ToList();
                busparkgrid.ItemsSource = BusPark;
                outparkgrid.ItemsSource = OutPark;
                inparkgrid.ItemsSource = InPark;
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e) //edit outpark
        {

            edit dialwnd = new edit(bp, (Bus)outparkgrid.SelectedItem);
            if (dialwnd.ShowDialog() == true)
            {
                if (dialwnd.route.Text == "")
                {
                    bp.Remove((Bus)outparkgrid.SelectedItem);
                    bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, null, (byte)dialwnd.status.SelectedIndex);
                }
                else
                    bp.Remove((Bus)outparkgrid.SelectedItem);
                bp.Add(Convert.ToInt32(dialwnd.Num.Text), dialwnd.name.Text, Convert.ToInt32(dialwnd.route.Text), (byte)dialwnd.status.SelectedIndex);
            }
            else
            {
            }
            BusPark.Clear();
            OutPark.Clear();
            InPark.Clear();
            BusPark = bp.Buspark.ToList();
            OutPark = bp.OutPark.ToList();
            InPark = bp.InPark.ToList();
            busparkgrid.ItemsSource = BusPark;
            outparkgrid.ItemsSource = OutPark; //Да, можно было запихнуть это в один метод, but what a point?
            inparkgrid.ItemsSource = InPark;
        }

        private void busparkgrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bp.WriteToFile();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bp.ReadFromFile();
            BusPark.Clear();
            OutPark.Clear();
            InPark.Clear();
            BusPark = bp.Buspark.ToList();
            OutPark = bp.OutPark.ToList();
            InPark = bp.InPark.ToList();
            busparkgrid.ItemsSource = BusPark;
            outparkgrid.ItemsSource = OutPark;
            inparkgrid.ItemsSource = InPark;
        }
    }
}