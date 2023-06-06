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
    /// Interaction logic for Applications.xaml
    /// </summary>
    public partial class Applications : Page
    {
        private bool filterMain;
        public Base.Applications SelectedApp;
        public Applications()
        {
            InitializeComponent();
            DataContext = this;
            //GoodsGrid.ItemsSource = SourceCore.MyBase.Goods.ToList();
            UpdateGrid(null,false);
        }

        public void UpdateGrid(Base.Applications application, bool filter)
        {
            if ((application == null) && (AppGrid.ItemsSource != null))
            {
                application = (Base.Applications)AppGrid.SelectedItem;
            }
            comboFilter.ItemsSource = SourceCore.MyBase.Departments.ToList();
            if(filter)
            {
                Base.Departments selected = comboFilter.SelectedItem as Base.Departments;
                ObservableCollection<Base.Applications> applications =
new ObservableCollection<Base.Applications>(SourceCore.MyBase.Applications.Where(Q=>Q.ID_department==selected.ID_department).ToList());
                AppGrid.ItemsSource = applications;
                AppGrid.SelectedItem = application;
            }
            else
            {
                ObservableCollection<Base.Applications> applications =
new ObservableCollection<Base.Applications>(SourceCore.MyBase.Applications.ToList());
                AppGrid.ItemsSource = applications;
                AppGrid.SelectedItem = application;
                filterMain = true;
            }

        }
        private void GoToApplications(object sender, RoutedEventArgs e)
        {
            SelectedApp = (Base.Applications)AppGrid.SelectedItem;
            appRedaction newWindow = new appRedaction(SelectedApp,this);
            newWindow.ShowDialog();
        }
        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //????????????????????????HELP
            if (e.Key == Key.Escape)
            { NavigationService.GoBack(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.FinalPlan());
        }

        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterMain)
            {
                UpdateGrid(null, true);
            }
        }

        private void resetfilter_Click(object sender, RoutedEventArgs e)
        {
            filterMain = false;
            comboFilter.SelectedItem = null;
            UpdateGrid(null, false);
        }
    }
}