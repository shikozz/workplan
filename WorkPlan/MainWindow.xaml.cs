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
using WorkPlan.Pages;

namespace WorkPlan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Base.wpEntities DataBase;
        public Base.Users User { get; set; }
        public Base.Employee Employee { get; set; }
        int roleNum = 0;

        public MainWindow(int Role)
        {
            InitializeComponent();
            roleNum = Role;
            navigation(Role);
            sizeCombo.Items.Add("100%");
            sizeCombo.Items.Add("150%");
            sizeCombo.Items.Add("200%");
            sizeCombo.SelectedIndex = 0;
        }

        public void getName(int Role) 
        {
            userButton.Content = "Выйти из аккаунта";
            Base.Users User = DataBase.Users.SingleOrDefault(U => U.ID_user == Role);
            int emcode = Convert.ToInt32(User.ID_employee);
            Base.Employee Employee = DataBase.Employee.SingleOrDefault(U => U.ID_employee == emcode);
            Base.Departments dep = DataBase.Departments.SingleOrDefault(u => u.ID_department == Employee.ID_department);
            if (User.Права == "ADMIN") 
            {
                text.Text = Employee.ФИО + " - " + User.Права;
            }
            else
            {
                text.Text = Employee.ФИО + "\n" + dep.Название;
            }
        }

        public void navigation(int role) 
        {
            try
            {
                DataBase = new Base.wpEntities();
                //GetBase64ImageFromDb();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения приложения.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
            RootFrame.Navigate(new Pages.MainFrame(role, this.Width,this.Height,this));
            getName(role);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Escape) { Close();  }
            if (e.Key == Key.Escape)
            { navigation(roleNum); }
        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            SiGlogWind window = new SiGlogWind();
            window.Show();
            Close();
        }

        public double widthNow()
        {
            return this.Width;
        }

        private void gohome(object sender, RoutedEventArgs e)
        {
            navigation(roleNum);
        }

        private void closeapp(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Выйти из приложения?", "Выход", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void closeAppText(object sender, MouseButtonEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Выйти из приложения?", "Выход", MessageBoxButton.OKCancel, MessageBoxImage.Stop) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }



        private void sizeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sizeCombo.SelectedItem.ToString() == "100%")
            {
                this.Width = 700;
                this.Height = 500;
              // WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            }
            if (sizeCombo.SelectedItem.ToString() == "150%") 
            {
                this.Width = 1050;
                this.Height = 750;
               // WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            }
            if (sizeCombo.SelectedItem.ToString() == "200%")
            {
                this.Width = 1400;
                this.Height = 1000;
                //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
               // WindowStartupLocation.Manual = 0;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           // WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
