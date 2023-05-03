using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WorkPlan.Pages
{
    /// <summary>
    /// Interaction logic for userApps.xaml
    /// </summary>
    public partial class userApps : Page
    {
        private int roleN = 0;
        private Base.Applications SelectedApp;
        public Base.Entities DataBase;
        public string status;
        public userApps(int roleID)
        {
            InitializeComponent();
            DataContext = this;
            DataBase = new Base.Entities();
            roleN = roleID;
            //GoodsGrid.ItemsSource = SourceCore.MyBase.Goods.ToList();
            UpdateGrid(null);
            AppGrid.UpdateLayout();
        }
        public void UpdateGrid(Base.Applications application)
        {
            if ((application == null) && (AppGrid.ItemsSource != null))
            {
                application = (Base.Applications)AppGrid.SelectedItem;
            }
            Base.Users setUsers = DataBase.Users.SingleOrDefault(U => U.ID_user == roleN);
            Base.Employee setEmp = DataBase.Employee.SingleOrDefault(U => U.ID_employee == setUsers.ID_employee);
            ObservableCollection<Base.Applications> applications =
            new ObservableCollection<Base.Applications>(SourceCore.MyBase.Applications.Where(U => U.ID_department == setEmp.ID_department).ToList());
            AppGrid.ItemsSource = applications;
            AppGrid.SelectedItem = application;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

        }

        private void GoToApplications(object sender, RoutedEventArgs e)
        {
            SelectedApp = (Base.Applications)AppGrid.SelectedItem;
            Base.Status setStatus = DataBase.Status.SingleOrDefault(U => U.ID_status == SelectedApp.ID_status);
            if (SelectedApp.ID_creator != roleN)
            {
                MessageBox.Show("Вы не можете редактировать чужую заявку!");
            }
            else
            {
                if (setStatus.Статус != "Принято" || setStatus.Статус!="Закрыто")
                {
                    castRedact newWindow = new castRedact(SelectedApp, this);
                    newWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Вы не можете редактировать эту заявку!");
                }
            }
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            SelectedApp = (Base.Applications)AppGrid.SelectedItem;
            Base.Status setStatus = DataBase.Status.SingleOrDefault(U => U.ID_status == SelectedApp.ID_status);
            if (SelectedApp.ID_creator != roleN)
            {
                MessageBox.Show("Вы не можете удалить чужую заявку!");
            }
            else
            {
                if (setStatus.Статус != "Принято" || setStatus.Статус != "Закрыто")
                {
                    if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        SourceCore.MyBase.Applications.Remove((Base.Applications)AppGrid.SelectedItem);
                        SourceCore.MyBase.SaveChanges();
                        UpdateGrid(null);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не можете удалить эту заявку!");
                }
            }
        }

    }
}
