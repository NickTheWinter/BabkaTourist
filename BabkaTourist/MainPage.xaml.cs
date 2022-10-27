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
        AddPage addPage;
        List<Tour> tours = new List<Tour>();
        string default_search = "Поиск";
        public MainPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
            addPage = new AddPage(db,this);
            UpdateList(false);
        }

        public void UpdateList(bool last)
        {
            if (!last)
            {
                tours = db.Tours.ToList();
                list.ItemsSource = tours;
            }
            else
            {
                tours.Add(db.Tours.Last());
                list.UpdateLayout();
            }
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
            NavigationService.Navigate(addPage);
        }
        private void list_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Tour tour = (Tour)e.Row.DataContext;
            List<Tour> taken_s = db.Tours.Where(t => t.Id == tour.Id).ToList();
            if (taken_s.Count != 0)
            {
                e.Row.Foreground = Brushes.LightSkyBlue;
            }
            else
            {
                e.Row.Foreground = Brushes.White;
            }

        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tour tour= list.SelectedValue as Tour;
            Tour item = db.Tours.Find(tour.Id);

            addPage.Clear();
            addPage.EditTour(item);
            NavigationService.Navigate(addPage);

        }
    }
}
