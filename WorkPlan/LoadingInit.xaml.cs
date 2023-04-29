using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WorkPlan
{
    /// <summary>
    /// Логика взаимодействия для LoadingInit.xaml
    /// </summary>
    public partial class LoadingInit : Window
    {
        private Base.Entities DataBase;
        public LoadingInit()
        {
            InitializeComponent();
            try
            {
                DataBase = new Base.Entities();
                checkIfAdminPresent();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения приложения.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
        }

        public void checkIfAdminPresent()
        {   
            Base.Users User = DataBase.Users.SingleOrDefault(U=> U.Права == "ADMIN");
            if (User != null) 
            {
                SiGlogWind window = new SiGlogWind();
                window.Show();
                Close();
            }
            else
            {
                CreateAdmin window = new CreateAdmin(DataBase);
                window.Show();
                Close();
            }
        }
    }
}
