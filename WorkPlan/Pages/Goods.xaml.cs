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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace WorkPlan.Pages
{
    /// <summary>
    /// Interaction logic for Goods.xaml
    /// </summary>
    public partial class Goods : Page
    {
        public Goods()
        {
            InitializeComponent();
            DataContext = this;
            GoodsGrid.ItemsSource = SourceCore.MyBase.Goods.ToList();
            
        }

        private void GoToApplications(object sender, RoutedEventArgs e)
        {

        }
    }
}
