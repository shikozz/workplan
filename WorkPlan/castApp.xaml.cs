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

namespace WorkPlan
{
    /// <summary>
    /// Interaction logic for castApp.xaml
    /// </summary>
    public partial class castApp : Window
    {
        private Pages.userGoods goodsPage;
        private Base.Goods selectedGood;
        private Base.Entities DataBase;
        private int roleN;
        public castApp(Base.Goods SelectedGood, Pages.userGoods GoodsPage, int roleID)
        {
            InitializeComponent();
            DataContext = this;
            selectedGood = SelectedGood;
            goodsPage = GoodsPage;
            roleN = roleID;
            DataBase = new Base.Entities();
            init();
        }

        private void init()
        {
            Base.Users setUsers = DataBase.Users.SingleOrDefault(U => U.ID_user == roleN);
            Base.Employee setEmp = DataBase.Employee.SingleOrDefault(U => U.ID_employee == setUsers.ID_employee);
            Base.Departments setDep = DataBase.Departments.SingleOrDefault(U => U.ID_department == setEmp.ID_department);
            nametext.Text = selectedGood.Название;
            amounttext.Text = "0";
            deptext.Text = setDep.Название;
        }

        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {
            var newApp = new Base.Applications();
            Base.Users setUsers = DataBase.Users.SingleOrDefault(U => U.ID_user == roleN);
            Base.Employee setEmp = DataBase.Employee.SingleOrDefault(U => U.ID_employee == setUsers.ID_employee);
            Base.Status status = DataBase.Status.SingleOrDefault(U=>U.Статус=="Не расмотренно");
            newApp.ID_goods = selectedGood.ID_goods;
            newApp.ID_department = setEmp.ID_department;
            newApp.ID_status = status.ID_status;
            newApp.ID_creator = roleN;
            newApp.created_at= DateTime.Now;
            newApp.Количество = Convert.ToInt32(amounttext.Text);
            SourceCore.MyBase.Applications.Add(newApp);
            SourceCore.MyBase.SaveChanges();
            Close();
        }

        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void decrease(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(amounttext.Text) >= 1)
            {
                Int32 num = Convert.ToInt32(amounttext.Text);
                amounttext.Text = ((num - 1).ToString());
            }
        }

        private void increase(object sender, RoutedEventArgs e)
        {
            Int32 num = Convert.ToInt32(amounttext.Text);
            amounttext.Text = ((num + 1).ToString());
        }
    }
}
