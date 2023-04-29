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
using System.Text.RegularExpressions;

namespace WorkPlan
{

    /// <summary>
    /// Interaction logic for SiGlogREGWind.xaml
    /// </summary>
    public partial class CreateAdmin : Window
    {
        private Base.Entities DataBase;
        public Border myBorder;

        public CreateAdmin(Base.Entities DataBase)
        {
        
            InitializeComponent();
            this.DataBase = DataBase;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    // Создание и инициализация нового пользователя системы
                    
                    string passwordstring = PasswordPasswordBox.Text;                   
                        Base.Users User = new Base.Users();
                        Base.Users UserFind = DataBase.Users.SingleOrDefault(U => U.Логин == LoginTextBox.Text);
                if (UserFind == null)
                {
                    User.Логин = LoginTextBox.Text;
                    User.Пароль = passwordstring;
                    User.Права = "ADMIN";
                    // Добавление его в базу данных
                    DataBase.Users.Add(User);

                    // Сохранение изменений
                    DataBase.SaveChanges();
                    SiGlogWind window = new SiGlogWind();
                    Close();
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Данный логин уже занят!", "Пердупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    LoginTextBox.Text = "";
                }
                }
                catch {
                   MessageBox.Show("Неправильные данные","Пердупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
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
        }
    }

}