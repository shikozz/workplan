using System;
using System.Collections.Generic;
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

namespace WorkPlan.Pages
{
    /// <summary>
    /// Interaction logic for MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        private Base.Entities DataBase;
        int role = 0;
        private Window mainWindow;
        private double _width;
        private string userRole;
        public MainFrame(int roleN, double width, double height, Window MainWindow)
        {
            InitializeComponent();
            role = roleN;
            mainWindow = MainWindow;
            _width = width;
            //redraw(width);
            //mainWindow.wid
            DataBase = new Base.Entities();
            init(role);
        }

        public void init(int role)
        {
            Base.Users UserFind = DataBase.Users.SingleOrDefault(U => U.ID_user == role);
            userRole = UserFind.Права;
            if (userRole=="ADMIN" || userRole=="MAINBUH")
            {
                goods.Content = "Все товары";
                apps.Content = "Все заявки";
                admPanel.Content = "Редактировать списки";
                admPanel.Click += admPanel_Click;
                if (userRole == "MAINBUH")
                {
                    admPanel.Content = "Структура организации";
                    admPanel.Click += admPanel_Click1;
                }
            }
            else
            {
                goods.Content = "Все товары";
                apps.Content = "Мои заявки";
                admPanel.Content = "Структура организации";
                admPanel.Click += admPanel_Click1;
            }
        }


        public void redraw(double width)
        {
            double widthneed = ((MainWindow)Window.GetWindow(this)).widthNow();
            btnLight.Width = widthneed * 0.3;
            btnLight.Height = widthneed * 0.3;
            btnLight1.Width = widthneed * 0.3;
            btnLight1.Height = widthneed * 0.3;
            leftPanel.Margin = new Thickness(0,0,btnLight.Width*0.3,0);
            rigthPanel.Margin = new Thickness(btnLight1.Width*0.3,0,0,0);
            goods.FontSize = Math.Round(widthneed * 0.05);
            apps.FontSize = Math.Round(widthneed * 0.05);
        }

        private void btnLight_Click(object sender, RoutedEventArgs e)
        {
            if (userRole=="ADMIN")
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
            if (userRole == "ADMIN" || userRole == "MAINBUH")
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

        private void admPanel_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel= new AdminPanel();
            NavigationService.Navigate(adminPanel);
        }

        private void admPanel_Click1(object sender, RoutedEventArgs e)
        {
            Structure strPanel = new Structure();
            NavigationService.Navigate(strPanel);
        }
    }
}
