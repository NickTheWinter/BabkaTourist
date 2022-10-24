using BabkaTourist.DBClacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        ApplicationContext db;
        const string tagBtn_name = "add_tagBtn";
        const string locBtn_name = "add_locBtn";
        const string emplBtn_name = "add_emplBtn";
        const string addBtn = "Добавить запись";
        const string editBtn = "Изменить запись";
        public AddPage(ApplicationContext db)
        {
            InitializeComponent();
            this.db = db;
        }
        private void Open_Add_0_Page(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case tagBtn_name:
                    //Add_tag add_tag_window = new Add_tag(this, db, "tag");
                    //add_tag_window.Show();
                    break;
                case locBtn_name:
                    //Add_tag add_loc_window = new Add_tag(this, db, "loc");
                    //add_loc_window.Show();
                    break;
                case emplBtn_name:
                    //Add_employee add_empl_window = new Add_employee(this, db);
                    //add_empl_window.Show();
                    break;

            }
        }
        private void del_location_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_location.Text == "")
            {
                MessageBox.Show("Значение пусто");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Действительно удалить данное расположение?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    //Location location = db.Locations.Where(l => l.name == ComboBox_location.Text).FirstOrDefault();
                    //db.Locations.Remove(location);
                    //db.SaveChanges();
                    //ComboBox_location.Items.Clear();
                    //Update_ListLocations(false);

                }
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
            //DoubleAnimation animation = new DoubleAnimation();
            //animation.From = 1;
            //animation.To = 0;
            //animation.Duration = TimeSpan.FromSeconds(2);
            //switch (Add_btn.Content)
            //{
            //    case addBtn:
            //        if (name.Text != "" && ComboBox_location.Text != "" && number.Text != "" && count_things.Text != "0" && select_tags.Children.Count > 0)
            //        {
            //            Thing thing = new Thing();

            //            thing.count = Convert.ToInt32(count_things.Text);
            //            thing.name = name.Text;
            //            thing.number = number.Text;

            //            foreach (Grid item in select_tags.Children)
            //            {
            //                var borders = item.Children;
            //                Border border = (Border)borders[0];
            //                string tag_selected = (string)((Label)border.Child).Content;
            //                thing.Tags.Add(db.Tags.Where(t => t.name == tag_selected).FirstOrDefault());
            //            }

            //            try
            //            {
            //                foreach (Thing_employees item in thing_s)
            //                {
            //                    if (item.Count != null && item.Date != null)
            //                    {
            //                        string[] fio = item.SelectedName.Split(' ');
            //                        Employee employee = db.Employees.Where(e => e.surname == fio[0]).Where(e => e.name == fio[1]).Where(e => e.patronymic == fio[2]).FirstOrDefault();
            //                        Taken_things taken_Things = new Taken_things();
            //                        taken_Things.employee = employee;
            //                        taken_Things.thing = editing_thing;
            //                        taken_Things.count = item.Count;
            //                        taken_Things.date = item.Date;
            //                        taken_Things.comm = item.Comm;
            //                        thing.Taken_Things.Add(taken_Things);

            //                    }

            //                }
            //            }
            //            catch { }

            //            Location location = db.Locations.Where(l => l.name == ComboBox_location.Text).FirstOrDefault();
            //            location.Things.Add(thing);
            //            db.Things.Add(thing);
            //            db.SaveChanges();
            //            main_Page.Update_list(true);
            //        }
            //        save_img.Opacity = 1;
            //        save_img.BeginAnimation(Image.OpacityProperty, animation);
            //        break;

            //    case editBtn:
            //        editing_thing.name = name.Text;
            //        editing_thing.number = number.Text;
            //        editing_thing.count = Convert.ToInt32(count_things.Text);
            //        editing_thing.Tags.Clear();
            //        foreach (Grid item in select_tags.Children)
            //        {
            //            var borders = item.Children;
            //            Border border = (Border)borders[0];
            //            string tag_selected = (string)((Label)border.Child).Content;
            //            editing_thing.Tags.Add(db.Tags.Where(t => t.name == tag_selected).FirstOrDefault());
            //        }

            //        editing_thing.Taken_Things.Clear();

            //        foreach (Thing_employees item in thing_s)
            //        {
            //            if (item.Count != null && item.Date != null)
            //            {
            //                string[] fio = item.SelectedName.Split(' ');
            //                Employee employee = db.Employees.Where(e => e.surname == fio[0]).Where(e => e.name == fio[1]).Where(e => e.patronymic == fio[2]).FirstOrDefault();
            //                Taken_things taken_Things = new Taken_things();
            //                taken_Things.employee = employee;
            //                taken_Things.thing = editing_thing;
            //                taken_Things.count = item.Count;
            //                taken_Things.date = item.Date;
            //                taken_Things.comm = item.Comm;
            //                editing_thing.Taken_Things.Add(taken_Things);
            //            }

            //        }


            //        foreach (Location loc in db.Locations)
            //        {
            //            if (loc.Things.Where(t => t.id == editing_thing.id).Count() != 0)
            //            {
            //                loc.Things.Remove(editing_thing);
            //                break;
            //            }
            //        }

            //        Location location_add = db.Locations.Where(l => l.name == ComboBox_location.Text).FirstOrDefault();
            //        location_add.Things.Add(editing_thing);
            //        db.SaveChanges();

            //        editing_item.Name = editing_thing.name;
            //        editing_item.Number = editing_thing.number;
            //        editing_item.Location = ComboBox_location.Text;
            //        editing_item.Count = editing_thing.count;
            //        string tags = "";
            //        int count = 1;
            //        foreach (Tag tag in editing_thing.Tags)
            //        {
            //            if (count == editing_thing.Tags.Count)
            //                tags += tag.name;
            //            else
            //                tags += tag.name + "; ";
            //        }
            //        editing_item.Tag = tags;
            //        main_Page.list.Items.Refresh();
            //        save_img.Opacity = 1;
            //        save_img.BeginAnimation(Image.OpacityProperty, animation);
            //        break;
            //}
        }
        private void Del_thing(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Действительно удалить данную деталь?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                //db.Things.Remove(editing_thing);
                //db.SaveChanges();
                //main_Page.things.Clear();
                //main_Page.Update_list(false);
                //window1.frame.Navigate(main_Page);
            }
        }
    }
}
