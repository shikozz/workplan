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

namespace WorkPlan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Base.Entities DataBase;
        public Base.Users User { get; set; }
        public Base.Employee Employee { get; set; }

        public MainWindow(int Role)
        {
            InitializeComponent();
            try
            {
                DataBase = new Base.Entities();
                //GetBase64ImageFromDb();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения приложения.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
            RootFrame.Navigate(new Pages.MainFrame(Role));
            getName(Role);
        }

        public void getName(int Role) 
        {
            Base.Users User = DataBase.Users.SingleOrDefault(U => U.ID_employee == Role);
            int emcode = User.ID_employee;
            Base.Employee Employee = DataBase.Employee.SingleOrDefault(U => U.ID_employee == emcode);
            text.Text = Employee.ФИО;
            userButton.Content = User.Права;
        }

        public void navigation(string name) 
        {
        //    RootFrame();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) 
            { Close();  }
        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            SiGlogWind window = new SiGlogWind();
            window.Show();
            Close();
        }
    }
}
