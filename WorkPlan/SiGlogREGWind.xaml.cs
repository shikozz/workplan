using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkPlan
{

    /// <summary>
    /// Interaction logic for SiGlogREGWind.xaml
    /// </summary>
    public partial class SiGlogREGWind : Window
    {
        private Base.wpEntities DataBase;
        public Border myBorder;

        public SiGlogREGWind(Base.wpEntities DataBase)
        {
        
            InitializeComponent();
            this.DataBase = DataBase;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SiGlogWind window = new SiGlogWind();
            Close();
            window.ShowDialog();
        }
 

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            // Переброска необходимой информации во временные буферы
            String Password = PasswordPasswordBox.Password;
            Visibility Visibility = PasswordPasswordBox.Visibility;
            double Width = PasswordPasswordBox.ActualWidth;
            // Изменение подписи на кнопке
            PasswordButton.Content = Visibility == Visibility.Visible ? "Скрыть" : "Показать";
            // Переброска информации из TextBox'а в PasswordBox
            PasswordPasswordBox.Password = PasswordTextBox.Text;
            PasswordPasswordBox.Visibility = PasswordTextBox.Visibility;
            PasswordPasswordBox.Width = PasswordTextBox.Width;
            // Возврат информации из временных буферов в TextBox
            PasswordTextBox.Text = Password;
            PasswordTextBox.Visibility = Visibility;
            PasswordTextBox.Width = Width;

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            check.Text = " " + check.Text;
            if (captcha.Text == check.Text)
            {
                try
                {
                    // Создание и инициализация нового пользователя системы
                    
                    Base.Users User = new Base.Users();
                   
                    User.Логин = LoginTextBox.Text;
                    User.Пароль = PasswordPasswordBox.Password != "" ? PasswordPasswordBox.Password : PasswordTextBox.Text;
                    User.Права = "WORKER";
                    int result = Int32.Parse(IDTextBox.Text);
                    User.ID_employee = result;
                    // Добавление его в базу данных
                    DataBase.Users.Add(User);
                   
                    // Сохранение изменений
                    DataBase.SaveChanges();
                    SiGlogWind window = new SiGlogWind();
                    Close();
                    window.ShowDialog();
                }
                catch {
                    MessageBox.Show("Неправильные данные","Пердупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            else {
                MessageBox.Show("НИПРАВЕЛЬНА!",
                   "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                check.Text = "";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
                String allowchar = " ";
                allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
                allowchar += "1,2,3,4,5,6,7,8,9,0";
                //разделитель
                char[] a = { ',' };
                //расщепление массива по разделителю
                String[] ar = allowchar.Split(a);
                String pwd = " ";
                string temp = " ";
                Random r = new Random();
                for (int i = 0; i < 5; i++)
                {
                    temp = ar[(r.Next(0, ar.Length))];
                    pwd += temp;
                }
                captcha.Text = pwd;
        }
    }

}