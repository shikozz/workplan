using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
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
    public class GrouppedItem
    {
        public int appId { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
        public int year { get; set; }
        public int Id { get; set; }
        public string IdString { get; set; }
        public decimal sum1 { get; set; }
        public decimal sum2 { get; set; }
        public decimal sum3 { get; set; }
        public decimal sumA { get; set; }
        public int idNum { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public partial class PrintPreview : Window
    {
        public Base.Entities DataBase;
        public PrintPreview()
        {
            InitializeComponent();
            DataContext = this;
            DataBase = new Base.Entities();
            UpdatePrintGrid(null);

        }

        public void UpdatePrintGrid(Base.Applications application)
        {
            if ((application == null) && (printGrid.ItemsSource != null))
            {
                application = (Base.Applications)printGrid.SelectedItem;
            }
            Base.Status setstatus = DataBase.Status.SingleOrDefault(Q => Q.Статус == "Принято");
            ObservableCollection<Base.Applications> applications =
            new ObservableCollection<Base.Applications>(SourceCore.MyBase.Applications.Where(Q => Q.ID_status == setstatus.ID_status).ToList());
            var groupedData = applications
                 .GroupBy(item => item.ID_goods)
                 .Select((group, index )=>
                 {
                     var totalValue = group.Sum(item => item.TotalPrice);
                     var yearS = group.Min(item=>item.year);
                     var y1p = group.Sum(item=>item.year1price);
                     var y2p = group.Sum(item => item.year2price);
                     var y3p = group.Sum (item=>item.year3price);
                     var yAp = group.Sum(item => item.yearAprice);
                     var amount = group.Sum(item=>item.Количество);
                     return new GrouppedItem
                     {
                         idNum = SourceCore.MyBase.Goods.Single(Q=>Q.ID_goods == group.Key).ID_goods,
                         Id = (index + 1),
                         Name = SourceCore.MyBase.Goods.Single(Q=>Q.ID_goods==group.Key).Название,
                         year = Convert.ToInt32(yearS),
                         Sum = totalValue,
                         sum1 = (decimal)y1p,
                         sum2 = (decimal)y2p,
                         sum3 = (decimal)y3p,
                         sumA = (decimal)yAp,
                         code = SourceCore.MyBase.Goods.Single(Q=>Q.ID_goods==group.Key).code,
                         description = "Закупка товара \"" + SourceCore.MyBase.Goods.Single(Q=>Q.ID_goods==group.Key).Название+ "\" в количестве "+amount+"шт.",
                     };
                 }) 
                 .Select(item =>
                 {
                     item.IdString = item.Id.ToString("D4");
                     return item;
                 });
            var groupedCollection = new ObservableCollection<GrouppedItem>(groupedData);
            printGrid.ItemsSource = groupedCollection;
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
