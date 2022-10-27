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
using System.Windows.Shapes;

namespace BabkaTourist.PAges
{
    /// <summary>
    /// Логика взаимодействия для AddCountry.xaml
    /// </summary>
    public partial class AddCountry : Window
    {
        ApplicationContext db;
        AddPage AddPage;
        public AddCountry(ApplicationContext db, AddPage addPage)
        {
            InitializeComponent();
            this.db = db;
            this.AddPage = addPage;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = db.Countries.Where(p => p.Name == name.Text);
            if (t.Count() == 0)
            {
                Country country = new Country(name.Text);
                db.Countries.Add(country);
                db.SaveChanges();
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
