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
using TextBox = System.Windows.Controls.TextBox;
using System.Data.Entity;

namespace WorkPlan.Pages
{
    /// <summary>
    /// Interaction logic for Goods.xaml
    /// </summary>
    public partial class Goods : Page
    {
        Base.wpEntities DataBase;
        private Base.Goods SelectedApp;
        public Goods()
        {
            InitializeComponent();
            DataContext = this;
            UpdateGrid(null);
            DataBase = new Base.wpEntities();
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


        private void DeleteGood(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedApp = (Base.Goods)GoodsGrid.SelectedItem;
                Base.Applications checkApps = DataBase.Applications.SingleOrDefault(q => q.ID_goods == SelectedApp.ID_goods);
                if (System.Windows.MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    if (checkApps == null)
                    {
                        SourceCore.MyBase.Goods.Remove((Base.Goods)GoodsGrid.SelectedItem);
                        SourceCore.MyBase.SaveChanges();
                        UpdateGrid(null);
                    }
                    else 
                    {
                        System.Windows.MessageBox.Show("Вы не можете удалить товар, который в настоящий момент учавствует в заявке пользователя!");
                    }
                }
            }
            catch { System.Windows.MessageBox.Show("Вы не можете удалить товар, который в настоящий момент учавствует в заявке пользователя!"); }
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
