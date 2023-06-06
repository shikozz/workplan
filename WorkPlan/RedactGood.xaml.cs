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
using System.Windows.Shapes;

namespace WorkPlan
{
    /// <summary>
    /// Логика взаимодействия для RedactGood.xaml
    /// </summary>
    public partial class RedactGood : Window
    {
        private Pages.Goods goodsPage;
        private Base.Goods selectedGood;
        public RedactGood(Pages.Goods GoodsPage, Base.Goods selected)
        {
            InitializeComponent();
            DataContext = this;
            goodsPage = GoodsPage;
            selectedGood = selected;
            initial();
        }

        public void initial()
        {
            Base.Goods sg = SourceCore.MyBase.Goods.Single(Q=>Q.ID_goods==selectedGood.ID_goods);
            nametext.Text = sg.Название;
            amounttext.Text = Convert.ToInt32(sg.Цена).ToString();
            codetext.Text = sg.code.ToString();
        }
        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var NewGood = new Base.Goods();
                NewGood = SourceCore.MyBase.Goods.Single(Q=>Q.ID_goods==selectedGood.ID_goods);
                NewGood.Название = nametext.Text;
                NewGood.Цена = Convert.ToDecimal(amounttext.Text);
                NewGood.code = codetext.Text;
                SourceCore.MyBase.SaveChanges();
                goodsPage.UpdateGrid(null);
                goodsPage.GoodsGrid.SelectedItem = NewGood;
                goodsPage.GoodsGrid.UpdateLayout();
                goodsPage.GoodsGrid.ScrollIntoView(goodsPage.GoodsGrid.SelectedItem);
                Close();
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите название, используя любые символы, и укажите цену, используя только цифры");
            }
        }

        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void increase(object sender, RoutedEventArgs e)
        {
            Int32 num = Convert.ToInt32(amounttext.Text);
            amounttext.Text = ((num + 10).ToString());
        }

        private void decrease(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(amounttext.Text) >= 10)
            {
                Int32 num = Convert.ToInt32(amounttext.Text);
                amounttext.Text = ((num - 10).ToString());
            }
        }

        private void nametext_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void nametext_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void nametext_GotFocus(object sender, RoutedEventArgs e)
        {
            if (nametext.Text.Equals("Введите сюда"))
            {
                nametext.Text = "";
                nametext.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void nametext_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nametext.Text.Equals(""))
            {
                nametext.Text = "Введите сюда";
                nametext.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
