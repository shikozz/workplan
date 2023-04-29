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
using WorkPlan.Base;

namespace WorkPlan.Pages
{
    /// <summary>
    /// Логика взаимодействия для redEmpList.xaml
    /// </summary>
    public partial class redEmpList : Page
    {
        public Base.Employee SelectedEmp;
        public Base.Departments SelectedDep;
        private Base.Entities DataBase;
        private bool addOrRed = false;
        public List<Departments> Dep { get; set; }
        public List<Specializations> Spec { get; set; }
        public redEmpList()
        {
            InitializeComponent();
            DataContext = this;
            UpdateGrid(null);
            DataBase = new Base.Entities();
            addPanel.Visibility = Visibility.Hidden;
        }

        public void UpdateGrid(Base.Employee emp)
        {
            if ((emp == null) && (AppGrid.ItemsSource != null))
            {
                emp = (Base.Employee)AppGrid.SelectedItem;
            }

            ObservableCollection<Base.Employee> emps =
                new ObservableCollection<Base.Employee>(SourceCore.MyBase.Employee.ToList());
            AppGrid.ItemsSource = emps;
            AppGrid.SelectedItem = emp;
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            addBtn.Content = "Добавить";
            mainLabel.Content = "Добавить";
            addOrRed = true;
            fio.Text = "";
            spec.Text = "";
            department.Text = "";
            ObservableCollection<Base.Departments> dep =
                new ObservableCollection<Departments>(SourceCore.MyBase.Departments.ToList());
            Dep = dep.ToList();
            department.ItemsSource = Dep;
            ObservableCollection<Base.Specializations> specl =
                new ObservableCollection<Specializations>(SourceCore.MyBase.Specializations.ToList());
            Spec = specl.ToList();
            spec.ItemsSource = Spec;
            addPanel.Visibility= Visibility.Visible;
        }

        private void redUserBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedEmp = (Base.Employee)AppGrid.SelectedItem;
            if (SelectedEmp != null)
            {
                addBtn.Content = "Редактировать";
                mainLabel.Content = "Редактировать";
                addOrRed = false;

                fio.Text = SelectedEmp.ФИО;
                ObservableCollection<Base.Specializations> specl =
                    new ObservableCollection<Specializations>(SourceCore.MyBase.Specializations.ToList());
                Spec = specl.ToList();
                spec.ItemsSource = Spec;
                ObservableCollection<Base.Departments> dep =
                    new ObservableCollection<Departments>(SourceCore.MyBase.Departments.ToList());
                Dep = dep.ToList();
                department.ItemsSource = Dep;
                addPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Не выбран сотрудник");
            }
        }

        private void delUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedEmp = (Base.Employee)AppGrid.SelectedItem;
                if (MessageBox.Show("Удалить сотрудника?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    SourceCore.MyBase.Employee.Remove((Base.Employee)AppGrid.SelectedItem);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(null);
                }
            }
            catch 
            {
                MessageBox.Show("Не выбран сотрудник");
            }
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
                    var specl = spec.SelectedItem as Specializations;
                    var dept = department.SelectedItem as Departments;
                    Base.Specializations setSpec = DataBase.Specializations.SingleOrDefault(M => M.id_specialization == specl.id_specialization) ;
                    Base.Departments setDep = DataBase.Departments.SingleOrDefault(U => U.ID_department == dept.ID_department);
                    var newEmp = new Base.Employee();
                    newEmp.ФИО = fio.Text;
                    newEmp.ID_specialization = specl.id_specialization;
                    newEmp.ID_department = dept.ID_department;
                    SourceCore.MyBase.Employee.Add(newEmp);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(newEmp);
                    addPanel.Visibility= Visibility.Collapsed;
                }
                catch
                {
                    MessageBox.Show("Перепроверьте данные");
                }
            }
            else
            {
                var specl = spec.SelectedItem as Specializations;
                var depts = department.SelectedItem as Departments;
                if (depts == null || specl == null)
                {
                    MessageBox.Show("Перепроверьте данные");
                }
                else
                {
                    try
                    {
                        var editEmp = new Base.Employee();
                        editEmp = SourceCore.MyBase.Employee.First(P => P.ID_employee == SelectedEmp.ID_employee);
                        editEmp.ФИО = fio.Text;
                        editEmp.ID_specialization= specl.id_specialization;
                        editEmp.ID_department = depts.ID_department;
                        SourceCore.MyBase.SaveChanges();
                        UpdateGrid(editEmp);
                        AppGrid.SelectedItem= editEmp;
                        addPanel.Visibility= Visibility.Collapsed;
                    }
                    catch
                    {
                        MessageBox.Show("Перепроверьте данные");
                    }
                }
            }
        }

        private void canBtn_Click(object sender, RoutedEventArgs e)
        {
            addPanel.Visibility = Visibility.Hidden;
        }
    }
}
