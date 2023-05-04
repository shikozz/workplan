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
using System.Windows.Shapes;
using WorkPlan.Base;

namespace WorkPlan
{
    /// <summary>
    /// Логика взаимодействия для addToStructure.xaml
    /// </summary>
    public partial class addToStructure : Window
    {
        public Pages.Structure strParent;
        public string RoleName;
        public int depNum;
        public string depFull;
        public addToStructure(string rolename,int depnum, Pages.Structure parent)
        {
            InitializeComponent();
            RoleName = rolename;
            depNum = depnum;
            strParent = parent;
            emp.ItemsSource = SourceCore.MyBase.Employee.ToList();
            depFull = rolename + depNum;
        }

        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {
            var CurrentEmp = emp.SelectedItem as Employee;
            switch(RoleName)
            {
                case "mainman":
                    var NewEmp = new Base.Structure();
                    NewEmp.id_Emp = CurrentEmp.ID_employee;
                    NewEmp.roleo = RoleName;
                    SourceCore.MyBase.Structure.Add(NewEmp);
                    SourceCore.MyBase.SaveChanges();
                    break;
                case "buh":
                    var NewEmpBuh = new Base.Structure();
                    NewEmpBuh.id_Emp = CurrentEmp.ID_employee;
                    NewEmpBuh.roleo = RoleName;
                    SourceCore.MyBase.Structure.Add(NewEmpBuh);
                    SourceCore.MyBase.SaveChanges();
                    break;
                case "mainDep_":
                    var newDepMain = new Base.Structure();
                    newDepMain.id_Emp = CurrentEmp.ID_employee;
                    newDepMain.roleo = depFull;
                    SourceCore.MyBase.Structure.Add(newDepMain);
                    SourceCore.MyBase.SaveChanges();
                    break;
                case "zamDep_":
                    var newDepZam = new Base.Structure();
                    newDepZam.id_Emp = CurrentEmp.ID_employee;
                    newDepZam.roleo = depFull;
                    SourceCore.MyBase.Structure.Add(newDepZam);
                    SourceCore.MyBase.SaveChanges();
                    break;
            }
            strParent.loadStructure();
            Close();
        }

        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
