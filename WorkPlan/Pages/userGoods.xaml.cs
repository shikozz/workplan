using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WorkPlan.Pages
{
    /// <summary>
    /// Interaction logic for userGoods.xaml
    /// </summary>
    public partial class userGoods : Page
    {
        public Base.Goods SelectedGood;
        private int roleN;
        public userGoods(int roleID)
        {
            InitializeComponent();
            DataContext = this;
            roleN = roleID;
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
            SelectedGood = (Base.Goods)GoodsGrid.SelectedItem;
            castApp newWindow =new castApp(SelectedGood,this,roleN);
            newWindow.ShowDialog();

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

        }
        private void filterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox.Text != "Введите название товара")
            {
                GoodsGrid.ItemsSource = SourceCore.MyBase.Goods.Where(Q => Q.Название.Contains(textbox.Text)).ToList();
            }
        }

        private void filterText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (filterText.Text == "Введите название товара")
            {
                filterText.Text = "";
                filterText.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void filterText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (filterText.Text == "")
            {
                filterText.Text = "Введите название товара";
                filterText.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
