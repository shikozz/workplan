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

namespace WorkPlan.Pages
{
    /// <summary>
    /// Логика взаимодействия для redSpecList.xaml
    /// </summary>
    public partial class redSpecList : Page
    {
        public Base.Specializations SelectedSpec;
        private Base.Entities DataBase;
        private bool addOrRed = false;
        public redSpecList()
        {
            InitializeComponent();
            DataContext= this;
            addPanel.Visibility = Visibility.Hidden;
            DataBase = new Base.Entities();
            UpdateGrid(null);
        }
        public void UpdateGrid(Base.Specializations specialization)
        {
            if ((specialization == null) && (AppGrid.ItemsSource != null))
            {
                specialization = (Base.Specializations)AppGrid.SelectedItem;
            }

            ObservableCollection<Base.Specializations> specializations =
                new ObservableCollection<Base.Specializations>(SourceCore.MyBase.Specializations.ToList());
            AppGrid.ItemsSource = specializations;
            AppGrid.SelectedItem = specialization;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void canBtn_Click(object sender, RoutedEventArgs e)
        {
            addPanel.Visibility = Visibility.Hidden;
        }

        private void delUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedSpec = (Base.Specializations)AppGrid.SelectedItem;
                if (MessageBox.Show("Удалить должность?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    SourceCore.MyBase.Specializations.Remove((Base.Specializations)AppGrid.SelectedItem);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(null);
                }
            }
            catch
            {
                MessageBox.Show("Не выбрана должность");
            }
        }
        private void redUserBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedSpec = (Base.Specializations)AppGrid.SelectedItem;
            if (SelectedSpec != null)
            {
                addBtn.Content = "Редактировать";
                mainLabel.Content = "Редактировать";

                addOrRed = false;
                name.Text = SelectedSpec.Name_specialization;
                addPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Не выбрана должность");
            }
        }
        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            addBtn.Content = "Добавить";
            mainLabel.Content = "Добавить";
            addOrRed = true;
            name.Text = "";
            addPanel.Visibility = Visibility.Visible;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addOrRed)
            {
                try
                {
                    var newSpec = new Base.Specializations();
                    newSpec.Name_specialization= name.Text;
                    SourceCore.MyBase.Specializations.Add(newSpec);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(newSpec);
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
                    var editSpec = new Base.Specializations();
                    editSpec = SourceCore.MyBase.Specializations.First(p => p.id_specialization == SelectedSpec.id_specialization);
                    editSpec.Name_specialization = name.Text;
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(editSpec);
                    AppGrid.SelectedItem = editSpec;
                    addPanel.Visibility = Visibility.Collapsed;
                }
                catch
                {
                    MessageBox.Show("Перепроверьте данные");
                }
            }
        }
    }
}
