using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkPlan
{
    /// <summary>
    /// Логика взаимодействия для PrintPreview.xaml
    /// </summary>
    /// 
    public partial class PrintPreview : Window
    {
        public Base.Entities DataBase;
        public PrintPreview()
        {
            InitializeComponent();
            DataContext = this;
            DataBase = new Base.Entities();
            UpdateGrid(null);
        }

        public void UpdateGrid(Base.Applications application)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("totalprice");
            if ((application == null) && (printGrid.ItemsSource != null))
            {
                application = (Base.Applications)printGrid.SelectedItem;
            }
            Base.Status setstatus = DataBase.Status.SingleOrDefault(Q => Q.Статус == "Принято");
            ObservableCollection<Base.Applications> applications =
            new ObservableCollection<Base.Applications>(SourceCore.MyBase.Applications.Where(Q => Q.ID_status == setstatus.ID_status).ToList());
            printGrid.ItemsSource = applications;
            printGrid.SelectedItem = application;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog p =new System.Windows.Controls.PrintDialog ();
            if(p.ShowDialog() == true)
            {
                p.PrintVisual(this,"Printing");
            }
        }
    }
}
