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
    /// Логика взаимодействия для redDepsList.xaml
    /// </summary>
    public partial class redDepsList : Page
    {
        public Base.Departments SelectedDep;
        private Base.Entities DataBase;
        private bool addOrRed = false;
        public redDepsList()
        {
            InitializeComponent();
            DataContext = this;
            addPanel.Visibility = Visibility.Hidden;
            DataBase = new Base.Entities();
            UpdateGrid(null);
        }

        public void UpdateGrid(Base.Departments department)
        {
            if ((department == null) && (AppGrid.ItemsSource != null))
            {
                department = (Base.Departments)AppGrid.SelectedItem;
            }

            ObservableCollection<Base.Departments> departments =
                new ObservableCollection<Base.Departments>(SourceCore.MyBase.Departments.ToList());
            AppGrid.ItemsSource = departments;
            AppGrid.SelectedItem = department;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if(addOrRed)
            {
                try
                {
                    var newDep = new Base.Departments();
                    newDep.Название = name.Text;
                    newDep.Кол_во_сотрудников = count.Text;
                    SourceCore.MyBase.Departments.Add(newDep);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(newDep);
                    addPanel.Visibility = Visibility.Collapsed;
                }
                catch
                {
                    MessageBox.Show("Перепроверьте данные");
                }
            }
            else
            {
                try
                {
                    var editDep = new Base.Departments();
                    editDep = SourceCore.MyBase.Departments.First(p => p.ID_department == SelectedDep.ID_department);
                    editDep.Название = name.Text;
                    editDep.Кол_во_сотрудников = count.Text;
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(editDep);
                    AppGrid.SelectedItem= editDep;
                    addPanel.Visibility = Visibility.Collapsed;
                }
                catch
                {
                    MessageBox.Show("Перепроверьте данные");
                }
            }
        }

        private void canBtn_Click(object sender, RoutedEventArgs e)
        {
            addPanel.Visibility = Visibility.Hidden;
        }

        private void delUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedDep = (Base.Departments)AppGrid.SelectedItem;
                if (MessageBox.Show("Удалить отдел?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    SourceCore.MyBase.Departments.Remove((Base.Departments)AppGrid.SelectedItem);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(null);
                }
            }
            catch
            {
                MessageBox.Show("Не выбран отдел");
            }
        }

        private void redUserBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedDep = (Base.Departments)AppGrid.SelectedItem;
            if (SelectedDep != null)
            {
                addBtn.Content = "Редактировать";
                mainLabel.Content = "Редактировать";

                addOrRed = false;
                name.Text = SelectedDep.Название;
                count.Text = SelectedDep.Кол_во_сотрудников;
                addPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Не выбран отдел");
            }
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            addBtn.Content = "Добавить";
            mainLabel.Content = "Добавить";
            addOrRed = true;
            name.Text = "";
            count.Text = "";
            addPanel.Visibility = Visibility.Visible;
        }
    }
}
