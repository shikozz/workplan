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
    /// Interaction logic for castRedact.xaml
    /// </summary>
    public partial class castRedact : Window
    {
        private Pages.userApps appPage;
        private Base.Applications SelectedApp;
        private Base.Entities DataBase;
        public castRedact(Base.Applications selectedItem, Pages.userApps AppPage)
        {
            InitializeComponent();
            DataContext = this;
            SelectedApp = selectedItem;
            DataBase = new Base.Entities();
            appPage = AppPage;
            init();
        }

        private void init() 
        {
            Base.Goods setGood = DataBase.Goods.SingleOrDefault(U => U.ID_goods == SelectedApp.ID_goods);
            Base.Status setStatus = DataBase.Status.SingleOrDefault(U => U.ID_status == SelectedApp.ID_status);
            Base.Departments setDep = DataBase.Departments.SingleOrDefault(U => U.ID_department == SelectedApp.ID_department);
            nametext.Text = setGood.Название;
            statustext.Text = setStatus.Статус;
            deptext.Text = setDep.Название;
            amounttext.Text = SelectedApp.Количество.ToString();
        }

        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var EditApp = new Base.Applications();
                EditApp = SourceCore.MyBase.Applications.First(P => P.ID_application == SelectedApp.ID_application);
                EditApp.Количество = Convert.ToInt32(amounttext.Text);
                SourceCore.MyBase.SaveChanges();
                appPage.UpdateGrid(null);
                appPage.AppGrid.SelectedItem = EditApp;
                appPage.AppGrid.UpdateLayout();
                appPage.AppGrid.ScrollIntoView(appPage.AppGrid.SelectedItem);
                Close();
            }
            catch 
            {
                MessageBox.Show("Пожалуйста, укажите количество, используя цифры");
            }
        }

        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void increase(object sender, RoutedEventArgs e)
        {
            Int32 num = Convert.ToInt32(amounttext.Text);
            amounttext.Text = ((num + 1).ToString());
        }

        private void decrease(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(amounttext.Text) >= 1)
            {
                Int32 num = Convert.ToInt32(amounttext.Text);
                amounttext.Text = ((num - 1).ToString());
            }
        }
    }
}
