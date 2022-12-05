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
using System.Collections.ObjectModel;

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
            //GoodsGrid.ItemsSource = SourceCore.MyBase.Goods.ToList();
            UpdateGrid(null);
        }

        public void UpdateGrid(Base.Goods Good)
        {
            if ((Good == null) && (GoodsGrid.ItemsSource != null))
            {
                Good = (Base.Goods)GoodsGrid.SelectedItem;
            }

            ObservableCollection<Base.Goods> Goods =
            new ObservableCollection<Base.Goods>(SourceCore.MyBase.Goods.ToList());
            GoodsGrid.ItemsSource = Goods;
            GoodsGrid.SelectedItem = Good;
        }


        private void GoToApplications(object sender, RoutedEventArgs e)
        {
            //here we will delete application
            if (System.Windows.MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                SourceCore.MyBase.Goods.Remove((Base.Goods)GoodsGrid.SelectedItem);
               // SourceCore.MyBase.Entry((Base.Goods)GoodsGrid.SelectedItem).State = EntityState.Deleted;
                SourceCore.MyBase.SaveChanges();
                UpdateGrid(null);

            }

        }
        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            { NavigationService.GoBack(); }
        }


        private void addNewGood(object sender, RoutedEventArgs e)
        {
            AddGood newWindow = new AddGood(this);
            newWindow.ShowDialog();
        }
    }
}
