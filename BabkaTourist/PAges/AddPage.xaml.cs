using BabkaTourist.DBClacces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace BabkaTourist.PAges
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        ApplicationContext db;
        public Tour editingTour;
        const string addBtn = "Добавить запись";
        const string editBtn = "Изменить запись";
        ObservableCollection<Hotel> hotel_s = new ObservableCollection<Hotel>();
        public ObservableCollection<String> country_s { get; set; } = new();
        MainPage MainPage;
        public AddPage(ApplicationContext db,MainPage mainPage)
        {
            InitializeComponent();
            this.db = db;
            list.ItemsSource = hotel_s;
            MainPage = mainPage;
            Update_ListTypes(false);
            Update_ListCountry(false);
            DataContext = this;
        }

        public void EditTour(Tour tour)
        {
            editingTour = tour;
            name.Text = tour.Name;
            Description.Text = tour.Description;
            Combo_boxType.Text = tour.Type.Name;
            count_bilets.Text = tour.TicketCount.ToString();
            Actual.IsChecked = tour.isActual;
            Price.Text = tour.Price.ToString();
            foreach (Hotel item in tour.Hotels)
            {
                hotel_s.Add(item);
            }

            Add_btn.Content = editBtn;
        }
        public void Clear()
        {
            name.Clear();
            Description.Clear();
            Combo_boxType.Text = "";
            count_bilets.Text = "0";
            Add_btn.Content = addBtn;
            Actual.IsChecked = false;
            list.Items.Refresh();
        }
        private void Open_Add_0_Page(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType(db,this);
            addType.Show();
        }
        public void Update_ListTypes(bool last)
        {
            List<DBClacces.Type> types = db.Types.ToList();
            if (!last)
            {
                foreach (DBClacces.Type type in types)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#262626"));
                    item.HorizontalContentAlignment = HorizontalAlignment.Center;
                    item.Foreground = Brushes.White;
                    item.Content = type.Name;
                    Combo_boxType.Items.Add(item);
                }
            }
            else
            {

                ComboBoxItem item = new ComboBoxItem();
                item.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#262626"));
                item.HorizontalContentAlignment = HorizontalAlignment.Center;
                item.Foreground = Brushes.White;
                item.Content = types.Last().Name;
                Combo_boxType.Items.Add(item);
            }
        }
        public void Update_ListCountry(bool last)
        {
            List<Country> countries = db.Countries.ToList();
            if (!last)
            {
                foreach (Country item in countries)
                {
                    country_s.Add(item.Name);
                }
            }
            else
            {
                country_s.Add(countries.Last().Name);
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string old_text = ((TextBox)sender).Text;
            string pattern = "(?i)[a-zа-я]";
            try
            {
                int i = Convert.ToInt32(old_text);
            }
            catch
            {
                ((TextBox)sender).Text = Regex.Replace(old_text, pattern, String.Empty);
            }
        }
        private void Update_count(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var parent3 = button.Parent;
            var parent2 = ((Grid)parent3).Parent;
            var parent1 = ((Border)parent2).Parent;
            var box = ((Grid)parent1).Children.OfType<TextBox>().FirstOrDefault();
            int count = 0;
            try
            {
                count = Convert.ToInt32(((TextBox)box).Text);
            }
            catch { }

            switch (button.Name)
            {
                case "plus":
                    count++;
                    ((TextBox)box).Text = Convert.ToString(count);
                    break;
                case "minus":
                    if (count != 0)
                    {
                        count--;
                        ((TextBox)box).Text = Convert.ToString(count);
                    }
                    break;
            }
        }
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0;
            animation.Duration = TimeSpan.FromSeconds(2);
            switch (Add_btn.Content)
            {
                case addBtn:
                    if (name.Text != "" && Combo_boxType.Text != "" && count_bilets.Text != "0" && Description.Text != "")
                    {
                        Tour tour = new Tour();
                        tour.Name = name.Text;
                        tour.Description = Description.Text;
                        tour.Price = float.Parse(Price.Text);
                        tour.TicketCount = int.Parse(count_bilets.Text);
                        tour.isActual = Actual.IsChecked.Value;
                        DBClacces.Type type = db.Types.Where(x => x.Name == Combo_boxType.Text).FirstOrDefault();
                        tour.Type = type;
                        db.Tours.Add(tour);
                        db.SaveChanges();
                        save_img.Opacity = 1;
                        save_img.BeginAnimation(Image.OpacityProperty, animation);
                    }
                    break;
                case editBtn:
                    editingTour.Name = name.Text;
                    editingTour.Description = Description.Text;
                    editingTour.Price= float.Parse(Price.Text);
                    editingTour.TicketCount = int.Parse(count_bilets.Text);
                    editingTour.isActual = Actual.IsChecked.Value;
                    db.SaveChanges();

                    save_img.Opacity = 1;
                    save_img.BeginAnimation(Image.OpacityProperty, animation);
                    break;
            }
        }
        private void Del_thing(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Действительно удалить данный тур?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                db.Tours.Remove(editingTour);
                db.SaveChanges();
                MainPage.UpdateList(false);
                NavigationService.GoBack();
            }
        }

        private void add_emplBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCountry addCountry = new AddCountry(db, this);
            addCountry.Show();
        }
    }
}
