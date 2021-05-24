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

namespace OOP_78Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbConnection connection;
        ServerRequester sr;
        static string rawst;
        static List<News> newslist;
        public MainWindow()
        {
            InitializeComponent();
            connection = new DbConnection();
            sr = new ServerRequester();
            raw.IsReadOnly = true;
            raw.Background = Brushes.White;
            newslist = new List<News>();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (newslist.Count != 0)
            {
                newslist.Clear();
            }
            rawst = sr.MakeRequest();
            raw.Text = rawst;
            newslist = Editor.GetNews(rawst);
            edited.ItemsSource = newslist;
            
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await connection.UpdateDb(newslist);
        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            if (newslist.Count!=0){
                newslist.Clear();
            }
            
            newslist = await connection.GetDataFromDb();
            edited.ItemsSource = newslist;
        }
    }
}