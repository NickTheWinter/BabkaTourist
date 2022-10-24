using BabkaTourist.DBClacces;
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

namespace BabkaTourist.PAges
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ApplicationContext db;
        List<Tour> tours = new List<Tour>();
        string default_search = "Поиск";
        public MainPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != default_search && search.Text != "" && list != null)
            {
                var filter_name = tours.Where(t => t.Name.ToLower().Contains(search.Text.ToLower()));
                list.ItemsSource = filter_name;
            }
            else
            {
                if (list != null)
                    list.ItemsSource = tours;
            }
        }
        private void Got_focus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Text == default_search)
                box.Text = "";
        }

        private void Lost_focus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Text == "")
                box.Text = default_search;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(db));
        }
        private void list_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //Data_thing thing = (Data_thing)e.Row.DataContext;
            //List<Taken_things> taken_s = db.Taken_Things.Where(t => t.id_thing == thing.id).ToList();
            //if (taken_s.Count != 0)
            //{
            //    e.Row.Foreground = Brushes.LightSkyBlue;
            //}
            //else
            //{
            //    e.Row.Foreground = Brushes.White;
            //}

        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // Data_thing thing = list.SelectedValue as Data_thing;
           // Thing item = db.Things.Find(thing.id);
           //
           // add_Page.Clear();
           // add_Page.Edit_thing(item, thing);
           // window1.frame.Navigate(add_Page);

        }
    }
}
