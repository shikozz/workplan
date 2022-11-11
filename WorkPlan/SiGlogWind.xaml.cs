using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing.Imaging;
//using WorkPlan.Base;

namespace WorkPlan
{
    /// <summary>
    /// Interaction logic for SiGlogWind.xaml
    /// </summary>
    public partial class SiGlogWind : Window
    {
        private Base.Entities DataBase;

        public SiGlogWind()
        {
            InitializeComponent();
            try
            {
                DataBase = new Base.Entities();
                //GetBase64ImageFromDb();
                //PutImageBase64InDb(@"D:\321.jpg");  
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения приложения.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Return) 
            {
                AuthorizProc();
            }
            if (e.Key == Key.Escape)
            { Close(); }
        }

        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {
            AuthorizProc();
        }

        private void AuthorizProc() 
        {
            Base.Users User = DataBase.Users.SingleOrDefault(U => U.Логин == LoginText.Text && U.Пароль.Equals(PasswordText.Password, StringComparison.CurrentCulture));
            if (User != null)
            {
                if (User.Права == "ADMIN")
                {

                    MainWindow window = new MainWindow(User.ID_employee);
                    window.Show();
                    Close();
                }
                else
                {
                    if (User.Права == "WORKER")
                    {
                        User window = new User();
                        window.Show();
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверно указан логин и/или пароль!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            };
        }

        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void PutImageBase64InDb(string iFile) 
        {
            string base64 = Convert.ToBase64String(File.ReadAllBytes(iFile));
            Base.pictures newpic = new Base.pictures();
            newpic.pic = base64;
            DataBase.pictures.Add(newpic);
            DataBase.SaveChanges();
        }
        private  void GetBase64ImageFromDb()
        {
            string base64FromDataBase = DataBase.pictures.SingleOrDefault(U => U.id_pic == 1902).pic;
           
            byte[] imageBytes = Convert.FromBase64String(base64FromDataBase);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);

            //image.Save("321.jpg", ImageFormat.Jpeg);

            string iImageName = @"D:\4IS2\Lebedev\WorkPlan\WorkPlan\Pictures\goods" + "." + "png";
            image.Save(iImageName, System.Drawing.Imaging.ImageFormat.Png);
        }


        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            SiGlogREGWind window = new SiGlogREGWind(DataBase);
            Close();
            window.ShowDialog();
        }

    }
}
