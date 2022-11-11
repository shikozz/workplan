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
    /// Interaction logic for AddApplication.xaml
    /// </summary>
    public partial class AddApplication : Window
    {
        public AddApplication()
        {
            InitializeComponent();
        }

        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
