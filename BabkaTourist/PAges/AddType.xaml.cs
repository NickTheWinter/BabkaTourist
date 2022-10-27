using BabkaTourist.DBClacces;
using System.Linq;
using System.Windows;

namespace BabkaTourist.PAges
{
    /// <summary>
    /// Логика взаимодействия для AddType.xaml
    /// </summary>
    public partial class AddType : Window
    {
        ApplicationContext db;
        AddPage AddPage;
        public AddType(ApplicationContext db,AddPage addPage)
        {
            InitializeComponent();
            this.db = db;
            this.AddPage = addPage;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = db.Types.Where(p => p.Name == name.Text);
            if (t.Count() == 0)
            {
                Type type = new Type(name.Text, description.Text);
                db.Types.Add(type);
                db.SaveChanges();
                AddPage.Update_ListTypes(true);
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text == "Название")
            {
                name.Text = "";
            }
        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Название";
            }
        }

        private void description_GotFocus(object sender, RoutedEventArgs e)
        {
            if (description.Text == "Описание")
            {
                description.Text = "";
            }
        }

        private void description_LostFocus(object sender, RoutedEventArgs e)
        {
            if (description.Text == "")
            {
                description.Text = "Описание";
            }
        }
    }
}
