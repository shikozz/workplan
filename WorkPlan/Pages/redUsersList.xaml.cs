using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using WorkPlan.Base;

namespace WorkPlan.Pages
{
    public partial class redUsersList : Page
    {
        public Base.Users SelectedUser;
        public Base.Employee SelectedEmp;
        private Base.Entities DataBase;
        private bool addOrRed = false;
        public List<Employee> Emp { get; set; }
        public redUsersList()
        {
            InitializeComponent();
            DataContext = this;
            UpdateGrid(null);
            DataBase = new Base.Entities();
            addPanel.Visibility = Visibility.Hidden;   
        }

        public void UpdateGrid(Base.Users user)
        {
            if((user == null)&&(AppGrid.ItemsSource != null))
            {
                user = (Base.Users)AppGrid.SelectedItem;
            }

            ObservableCollection<Base.Users> users =
                new ObservableCollection<Base.Users>(SourceCore.MyBase.Users.ToList());
            AppGrid.ItemsSource = users;
            AppGrid.SelectedItem = user;
        }

        private void canBtn_Click(object sender, RoutedEventArgs e)
        {
            addPanel.Visibility=Visibility.Hidden;
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            addBtn.Content = "Добавить";
            mainLabel.Content = "Добавить";
            addOrRed = true;
            login.Text = "";
            pass.Text = "";
            rights.Text = "";
            employee.Text="";
            addPanel.Visibility = Visibility.Visible;
            ObservableCollection<Base.Employee> emp =
                new ObservableCollection<Base.Employee>(SourceCore.MyBase.Employee.ToList());
            Emp = emp.ToList();
            employee.ItemsSource = Emp;
        }

        private void redUserBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedUser = (Base.Users)AppGrid.SelectedItem;
            if (SelectedUser != null)
            {
                addBtn.Content = "Редактировать";
                mainLabel.Content = "Редактировать";
                addPanel.Visibility = Visibility.Visible;
                addOrRed = false;
                login.Text = SelectedUser.Логин;
                pass.Text = SelectedUser.Пароль;
                rights.Text = SelectedUser.Права;
                ObservableCollection<Base.Employee> emp =
                    new ObservableCollection<Base.Employee>(SourceCore.MyBase.Employee.ToList());
                Emp = emp.ToList();
                Base.Employee setEmp = DataBase.Employee.SingleOrDefault(U => U.ID_employee == SelectedUser.ID_employee);
                employee.ItemsSource = Emp;
                employee.SelectedItem = setEmp;
            }
            else
            {
                MessageBox.Show("Не выбран пользователь");
            }
        }

        private void delUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedUser = (Base.Users)AppGrid.SelectedItem;
                if (SelectedUser.Права != "ADMIN")
                {
                    if (MessageBox.Show("Удалить пользователя?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        SourceCore.MyBase.Users.Remove((Base.Users)AppGrid.SelectedItem);
                        SourceCore.MyBase.SaveChanges();
                        UpdateGrid(null);
                    }
                }
                else
                {
                    if (MessageBox.Show("Удалить Администратора?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        SourceCore.MyBase.Users.Remove((Base.Users)AppGrid.SelectedItem);
                        SourceCore.MyBase.SaveChanges();
                        UpdateGrid(null);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не выбран пользователь");
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addOrRed)
            {
                try
                {
                    var empl = employee.SelectedItem as Employee;
                    Base.Employee setEmp = DataBase.Employee.SingleOrDefault(U => U.ID_employee == empl.ID_employee);
                    var newUser = new Base.Users();
                    newUser.Логин = login.Text;
                    newUser.Пароль = pass.Text;
                    newUser.Права = rights.Text;
                    newUser.ID_employee = empl.ID_employee;
                    SourceCore.MyBase.Users.Add(newUser);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(newUser);
                    addPanel.Visibility = Visibility.Collapsed;
                }
                catch
                {
                    MessageBox.Show("Перепроверьте данные");
                }
            }
            else
            {
                var empl = employee.SelectedItem as Employee;
                if (empl == null)
                {
                    MessageBox.Show("Перепроверьте данные");
                }
                else
                {
                    try
                    {
                        var EditUser = new Base.Users();
                        EditUser = SourceCore.MyBase.Users.First(p => p.ID_user == SelectedUser.ID_user);
                        EditUser.Логин = login.Text;
                        EditUser.Пароль = pass.Text;
                        EditUser.Права = rights.Text;
                        EditUser.ID_employee = empl.ID_employee;
                        SourceCore.MyBase.SaveChanges();
                        UpdateGrid(EditUser);
                        AppGrid.SelectedItem = EditUser;
                        addPanel.Visibility = Visibility.Collapsed;

                    }
                    catch
                    {
                        MessageBox.Show("Перепроверьте данные");
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}