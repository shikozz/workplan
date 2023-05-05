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
        private bool loadStrc = true;
        private int depNum = 0;

        public Structure()
        {
            InitializeComponent();
            DataBase = new Base.Entities();
            loadStructure();
            backButton.Background = new ImageBrush(new BitmapImage(
new Uri("xmark.png", UriKind.Relative)));
        }

        public void loadStructure()
        {
            List<int> depIds = new List<int>();
            stackTest.Children.Clear();
            int str = DataBase.Structure.Count();

            Base.Structure strucMain = DataBase.Structure.SingleOrDefault(U => U.roleo == "mainman");
            if (strucMain == null)
            {
                var lostlabel = new Label
                {
                    Content = "Не назначен руководитель",
                    FontSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                var btnMainAdd = new Button
                {
                    Content = "Добавить руководителя",
                    Width = 30,
                    Height = 30,
                };
                Style style = this.FindResource("addStyle") as Style;
                btnMainAdd.Style = style;
                btnMainAdd.Click += addMain;
                stackTest.Children.Add(lostlabel);
                stackTest.Children.Add(btnMainAdd);
            }
            else
            {
                Base.Employee sEmpTest = DataBase.Employee.First(U => U.ID_employee == strucMain.id_Emp);
                Base.Specializations specTest = DataBase.Specializations.First(U => U.id_specialization == sEmpTest.ID_specialization);
                var label = new Label
                {
                    Content = sEmpTest.ФИО + " - " + specTest.Name_specialization,
                    FontSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                var btn = new Button
                {
                    Content = "Удалить",
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 30,
                    Height = 30,
                };
                Style style = this.FindResource("testStyle") as Style;
                btn.Style = style;
                btn.Click += delMain;
                stackTest.Children.Add(label);
                stackTest.Children.Add(btn);
            }

            Base.Structure strucBuh = DataBase.Structure.SingleOrDefault(U => U.roleo == "buh");
            if (strucBuh == null)
            {
                var lostlabel = new Label
                {
                    Content = "Не назначен бухгалтер",
                    FontSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                var btnMainAdd = new Button
                {
                    Content = "Добавить Бухгалтера",
                    Width = 30,
                    Height = 30,
                };
                Style style = this.FindResource("addStyle") as Style;
                btnMainAdd.Style = style;
                btnMainAdd.Click += addBuh;
                stackTest.Children.Add(lostlabel);
                stackTest.Children.Add(btnMainAdd);
            }
            else
            {
                Base.Employee sEm1pTest = DataBase.Employee.First(U => U.ID_employee == strucBuh.id_Emp);
                Base.Specializations specTest1 = DataBase.Specializations.First(U => U.id_specialization == sEm1pTest.ID_specialization);
                var label1 = new Label
                {
                    Content = sEm1pTest.ФИО + " - " + specTest1.Name_specialization,
                    FontSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                var btn = new Button
                {
                    Content = "Удалить",
                    Width = 30,
                    Height = 30,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                Style style = this.FindResource("testStyle") as Style;
                btn.Style = style;
                btn.Click += delBuh;
                stackTest.Children.Add(label1);
                stackTest.Children.Add(btn);
            }

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
                if (department.Название != "Отдел кадров")
                {
                    depIds.Add(department.ID_department);
                    var stackPanelAdd = new StackPanel
                    {

                    };
                    var namelabel = new Label
                    {
                        Content = department.Название,
                        FontSize = 25,
                        FontWeight = FontWeights.Heavy,
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    stackPanelAdd.Children.Add(namelabel);

                    Base.Structure strMain = DataBase.Structure.SingleOrDefault(U => U.roleo == "mainDep_" + department.ID_department.ToString());

                    if (strMain != null)
                    {
                        Base.Employee empMain = DataBase.Employee.SingleOrDefault(U => U.ID_employee == strMain.id_Emp);
                        var labeldepMain = new Label
                        {
                            Content = empMain.ФИО + " - Начальник",
                            FontSize = 20,
                            HorizontalAlignment = HorizontalAlignment.Center,
                        };
                        var btn = new Button
                        {
                            Style = null,
                            Content = "Удалить начальника отдела "+department.Название,
                            VerticalAlignment = VerticalAlignment.Center,
                            Width=30,
                            Height=30,
                            FontSize=1,
                        };
                        Style style = this.FindResource("testStyle") as Style;
                        btn.Style= style;
                        btn.Background = new ImageBrush(new BitmapImage(
new Uri("xmark.png", UriKind.Relative)));
                        btn.Click += delDepMain;
                        stackPanelAdd.Children.Add(labeldepMain);
                        stackPanelAdd.Children.Add(btn);
                    }
                    else
                    {
                        var lostlabel = new Label
                        {
                            Content = "Не назначен руководитель отдела",
                            FontSize = 20,
                            HorizontalAlignment = HorizontalAlignment.Center,
                        };
                        var btnMainAdd = new Button
                        {
                            Content = "Добавить руководителя в отдел "+department.Название,
                            Width = 30,
                            Height = 30,
                        };
                        Style style = this.FindResource("addStyle") as Style;
                        btnMainAdd.Style= style;
                        if (depNum == 0)
                        {
                            depNum = department.ID_department;
                        }
                        btnMainAdd.Name = "";
                        btnMainAdd.Click += addDepMain;
                        stackPanelAdd.Children.Add(lostlabel);
                        stackPanelAdd.Children.Add(btnMainAdd);
                    }

                    Base.Structure strZam = DataBase.Structure.SingleOrDefault(U => U.roleo == "zamDep_" + department.ID_department.ToString());
                    if (strZam != null)
                    {
                        Base.Employee empZam = DataBase.Employee.SingleOrDefault(U => U.ID_employee == strZam.id_Emp);
                        var labelDepZam = new Label
                        {
                            Content = empZam.ФИО + " - Зам. начальника",
                            FontSize = 20,
                            HorizontalAlignment = HorizontalAlignment.Center,
                        };
                        var btn = new Button
                        {
                            Content = "Удалить зама начальника отдела "+department.Название,
                            VerticalAlignment = VerticalAlignment.Center,
                            Width = 30,
                            Height = 30,
                        };
                        Style style = this.FindResource("testStyle") as Style;
                        btn.Style = style;
                        btn.Click += delDepZam;
                        stackPanelAdd.Children.Add(labelDepZam);
                        stackPanelAdd.Children.Add(btn);
                    }
                    else
                    {
                        var lostlabel = new Label
                        {
                            Content = "Не назначен зам руководитель отдела",
                            FontSize = 20,
                            HorizontalAlignment = HorizontalAlignment.Center,
                        };
                        var btnMainAdd = new Button
                        {
                            Content = "Добавить зама руководителя отдела "+department.Название,
                            Width = 30,
                            Height = 30,
                        };
                        Style style = this.FindResource("addStyle") as Style;
                        btnMainAdd.Style = style;
                        if (depNum == 0)
                        {
                            depNum = department.ID_department;
                        }
                        btnMainAdd.Click += addDepZam;
                        stackPanelAdd.Children.Add(lostlabel);
                        stackPanelAdd.Children.Add(btnMainAdd);
                    }
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

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void createNewStructure()
        {

        }

        private void delDepZam(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                string content = button.Content.ToString();
                content = content.Substring(31);
                Base.Departments dep = DataBase.Departments.Single(U => U.Название == content);
                DataBase.Configuration.ValidateOnSaveEnabled = false;
                Base.Structure str = DataBase.Structure.Single(U => U.roleo == "zamDep_" + dep.ID_department);
                DataBase.Entry(str).State = System.Data.Entity.EntityState.Deleted;
                DataBase.SaveChanges();
                loadStructure();

            }
            finally
            {
                DataBase.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        private void delDepMain(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                string content = button.Content.ToString();
                content = content.Substring(26);
                Base.Departments dep = DataBase.Departments.Single(U => U.Название == content);
                DataBase.Configuration.ValidateOnSaveEnabled = false;
                Base.Structure str = DataBase.Structure.Single(U => U.roleo == "mainDep_" + dep.ID_department);
                DataBase.Entry(str).State = System.Data.Entity.EntityState.Deleted;
                DataBase.SaveChanges();
                loadStructure();
            }
            finally
            {
                DataBase.Configuration.ValidateOnSaveEnabled = true;
            }
            depNum = 0;
        }

        private void delBuh(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.Configuration.ValidateOnSaveEnabled = false;
                Base.Structure str = DataBase.Structure.Single(U => U.roleo == "buh");
                DataBase.Entry(str).State = System.Data.Entity.EntityState.Deleted;
                DataBase.SaveChanges();
                loadStructure();

            }
            finally
            {
                DataBase.Configuration.ValidateOnSaveEnabled = true;
            }
            depNum = 0;
        }

        private void delMain(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.Configuration.ValidateOnSaveEnabled = false;
                Base.Structure str = DataBase.Structure.Single(U => U.roleo == "mainman");
                DataBase.Entry(str).State = System.Data.Entity.EntityState.Deleted;
                DataBase.SaveChanges();
                loadStructure();

            }
            finally
            {
                DataBase.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        private void addBuh(object sender, RoutedEventArgs e)
        {
            addToStructure window = new addToStructure("buh", 0, this);
            window.ShowDialog();
        }

        private void addMain(object sender, RoutedEventArgs e)
        {
            addToStructure window = new addToStructure("mainman", 0, this);
            window.ShowDialog();
        }

        private void addDepMain(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string content = button.Content.ToString();
            content = content.Substring(30);
            Base.Departments depint = DataBase.Departments.Single(U => U.Название == content);
            addToStructure window = new addToStructure("mainDep_", depint.ID_department, this);
            depNum = 0;
            window.ShowDialog();
        }

        private void addDepZam(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string content = button.Content.ToString();
            content= content.Substring(34);
            Base.Departments depInt = DataBase.Departments.Single(U => U.Название == content);
            addToStructure window = new addToStructure("zamDep_", depInt.ID_department, this);
            depNum = 0;
            window.ShowDialog();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Foreground = new ImageBrush(new BitmapImage(
new Uri("xmark.png", UriKind.Relative)));
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Foreground = new ImageBrush(new BitmapImage(
new Uri("xmark.png", UriKind.Relative)));
        }

        private void backButton_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
