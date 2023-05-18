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
using System.Drawing.Printing;

namespace WorkPlan.Pages
{
    /// <summary>
    /// Логика взаимодействия для FinalPlan.xaml
    /// </summary>
    public partial class FinalPlan : Page
    {
        public Base.Entities DataBase;
        public FinalPlan()
        {
            InitializeComponent();
            DataContext = this;
            DataBase = new Base.Entities();
            UpdateGrid(null);
        }

        public void UpdateGrid(Base.Applications application)
        {
            if ((application == null) && (AppGrid.ItemsSource != null))
            {
                application = (Base.Applications)AppGrid.SelectedItem;
            }
            Base.Status setstatus = DataBase.Status.SingleOrDefault(Q=>Q.Статус=="Принято");
            ObservableCollection<Base.Applications> applications =
            new ObservableCollection<Base.Applications>(SourceCore.MyBase.Applications.Where(Q=>Q.ID_status==setstatus.ID_status).ToList());
            AppGrid.ItemsSource = applications;
            AppGrid.SelectedItem = application;
        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
/*            PrintDialog p =new PrintDialog();
            if(p.ShowDialog() == true)
            {
                p.PrintVisual(AppGrid,"Printing");
            }*/
        PrintPreview pp = new PrintPreview();
            pp.Show();
        }
    }
}
