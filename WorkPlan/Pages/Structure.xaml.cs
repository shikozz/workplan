using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для Structure.xaml
    /// </summary>
    public partial class Structure : Page
    {
        public List<Employee> Emp { get; set; }
        private Base.Entities DataBase;
        public Structure()
        {
            InitializeComponent();
            DataBase= new Base.Entities();
            loadStructure();
        }

        public void loadStructure()
        {
            Base.Specializations sSpecTest = DataBase.Specializations.SingleOrDefault(U => U.Name_specialization.Contains("Руководитель"));
            Base.Employee sEmpTest = DataBase.Employee.First(U=>U.ID_specialization == sSpecTest.id_specialization);
            var label = new Label
            {
                Content = sEmpTest.ФИО + " - Руководитель",
                FontSize = 40,
                HorizontalAlignment= HorizontalAlignment.Center,
            };
            stackTest.Children.Add(label);

            Base.Specializations sSpec1Test = DataBase.Specializations.SingleOrDefault(U => U.Name_specialization.Contains("Бухгалтер"));
            Base.Employee sEm1pTest = DataBase.Employee.First(U => U.ID_specialization == sSpec1Test.id_specialization);
            var label1 = new Label
            {
                Content = sEm1pTest.ФИО+" - Главный Бухгалтер",
                FontSize = 40,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            stackTest.Children.Add(label1);
            var rect = new Rectangle
            {
                Height = 1,
            };
            rect.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            stackTest.Children.Add(rect);
            var stackHor = new StackPanel
            {
                Orientation = Orientation.Vertical
            };
            stackTest.Children.Add(stackHor);
            foreach (Base.Departments department in DataBase.Departments)
            {
                if(department.Название!= "Отдел кадров")
                {
                    var stackPanelAdd = new StackPanel
                    {
                        
                    };
                    var namelabel = new Label
                    {
                        Content = department.Название,
                        FontSize=25,
                        FontWeight= FontWeights.Heavy,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    stackPanelAdd.Children.Add(namelabel);
                    Base.Specializations sSpecDep = DataBase.Specializations.SingleOrDefault(U => U.Name_specialization.Contains("Начальник"));
                    Base.Employee sEmpDep = DataBase.Employee.First(U => U.ID_specialization == sSpecDep.id_specialization && U.ID_department == department.ID_department );

                    var labell = new Label
                    {
                        Content = sEmpDep.ФИО + " - Начальник",
                        FontSize=20,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    stackPanelAdd.Children.Add(labell);
                    Base.Specializations sSpecDep1 = DataBase.Specializations.SingleOrDefault(U => U.Name_specialization.Contains("Зам"));
                    Base.Employee sEmpDep1 = DataBase.Employee.First(U => U.ID_specialization == sSpecDep1.id_specialization && U.ID_department == department.ID_department);
                    var labelll = new Label
                    {
                        Content = sEmpDep1.ФИО +" - Заместитель начальника",
                        FontSize = 20,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    stackPanelAdd.Children.Add(labelll);
                    var rect1 = new Rectangle
                    {
                        Height = 1,
                    };
                    rect1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
                    stackPanelAdd.Children.Add(rect1);
                    stackHor.Children.Add(stackPanelAdd);
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
