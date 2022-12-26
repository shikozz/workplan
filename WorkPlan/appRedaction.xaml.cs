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
    /// Interaction logic for appRedaction.xaml
    /// </summary>
    public partial class appRedaction : Window
    {
        private Pages.Applications appPage;
        private Base.Applications SelectedApp;
        private Base.wpEntities DataBase;
        public appRedaction(Base.Applications selectedItem, Pages.Applications AppPage)
        {
            InitializeComponent();
            DataContext = this;
            SelectedApp = selectedItem;
            DataBase = new Base.wpEntities();
            appPage = AppPage;
            initAppRed();
        }

        private void initAppRed() 
        {
            Base.Goods setGood = DataBase.Goods.SingleOrDefault(U => U.ID_goods == SelectedApp.ID_goods);
            Base.Status setStatus = DataBase.Status.SingleOrDefault(U => U.ID_status == SelectedApp.ID_status);
            Base.Departments setDep = DataBase.Departments.SingleOrDefault(U => U.ID_department == SelectedApp.ID_department);
            nametext.Text = setGood.Название;
            deptext.Text = setDep.Название;
            amounttext.Text = SelectedApp.Количество.ToString();
            combo.ItemsSource = SourceCore.MyBase.Status.ToList();
            combo.Text = setStatus.Статус;
        }

        private void AppRedactionClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var EditApp = new Base.Applications();
                EditApp = SourceCore.MyBase.Applications.First(p => p.ID_application == SelectedApp.ID_application);
                EditApp.Количество = Convert.ToInt32(amounttext.Text);
                EditApp.Status = (Base.Status)combo.SelectedItem;
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
            amounttext.Text = ((num + 10).ToString());
        }

        private void decrease(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(amounttext.Text) >= 10)
            {
                Int32 num = Convert.ToInt32(amounttext.Text);
                amounttext.Text = ((num - 10).ToString());
            }
        }
    }
}
