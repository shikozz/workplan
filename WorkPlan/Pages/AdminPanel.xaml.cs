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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
            adminLabel.Content = "Адмнистратора\n  ";
            fstBlock.Text = "1. Создайте новый отдел нажав на \nкнопку";
            fstLabel.Text = "Редактировать список Отделов\n  ";
            scnBlock.Text = "2. Создайте нового сотрудника\nнажав на кнопку";
            scnLabel.Text = "Редактировать список Сотрудников\n  ";
            thrBlock.Text = "3. (Опционально) Создайте нового\nпользователя нажав на кнопку";
            thrLabel.Text = "Редактировать список Пользователей";
            fouBlock.Text = "Или выдайте сотруднику его номер,\nчтобы он зарегистрировался сам";
        }

        private void redUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.redUsersList());
        }

        private void redEmp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.redEmpList());
        }

        private void redDep_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.redDepsList());
        }

        private void redSpec_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.redSpecList());
        }

        private void structure_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Structure());
        }
    }
}
