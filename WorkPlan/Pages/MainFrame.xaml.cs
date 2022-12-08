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

namespace WorkPlan.Pages
{
    /// <summary>
    /// Interaction logic for MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        int role = 0;
        private Window mainWindow;
        private double _width;
        public MainFrame(int roleN, double width, double height, Window MainWindow)
        {
            InitializeComponent();
            role = roleN;
            mainWindow = MainWindow;
            _width = width;
            //redraw(width);
            //mainWindow.wid
            init(role);
        }

        public void init(int role)
        {
            if (role == 700)
            {
                goods.Content = "Все товары";
                apps.Content = "Все заявки";
            }
            else
            {
                goods.Content = "Все товары";
                apps.Content = "Мои заявки";
            }
        }

        public void redraw(double width)
        {
            double widthneed = ((MainWindow)Window.GetWindow(this)).widthNow();
            btnLight.Width = widthneed * 0.3;
            btnLight.Height = widthneed * 0.3;
            btnLight1.Width = widthneed * 0.3;
            btnLight1.Height = widthneed * 0.3;
            leftPanel.Margin = new Thickness(0, 0, btnLight.Width * 0.3, 0);
            rigthPanel.Margin = new Thickness(btnLight1.Width * 0.3, 0, 0, 0);
            goods.FontSize = Math.Round(widthneed * 0.05);
            apps.FontSize = Math.Round(widthneed * 0.05);
        }

        private void btnLight_Click(object sender, RoutedEventArgs e)
        {
            if (role == 700)
            {
                Goods goods = new Goods();
                NavigationService.Navigate(goods);
            }
            else
            {
                userGoods uGoods = new userGoods(role);
                NavigationService.Navigate(uGoods);
            }
        }

        private void btnLight1_Click(object sender, RoutedEventArgs e)
        {
            if (role == 700)
            {
                Applications apps = new Applications();
                NavigationService.Navigate(apps);
            }
            else
            {
                userApps uApps = new userApps(role);
                NavigationService.Navigate(uApps);
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            redraw(_width);
        }
    }
}
