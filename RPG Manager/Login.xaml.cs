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
using RPG_Manager.WPF;

namespace RPG_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        Database db = new Database();
        public Login()
        {
            InitializeComponent();
        }

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            btNew.Visibility = Visibility.Hidden;
            btLogin.Visibility = Visibility.Hidden;
            btCancel.Visibility = Visibility.Visible;
            btCreate.Visibility = Visibility.Visible;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            btNew.Visibility = Visibility.Visible;
            btLogin.Visibility = Visibility.Visible;
            btCancel.Visibility = Visibility.Hidden;
            btCreate.Visibility = Visibility.Hidden;
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if (db.checkUser(tbUser.Text ?? "", tbPass.Password ?? ""))
            {
                Positioning.openNewWindow(new Overview(), this);
            }
            else
            {
                MessageBox.Show("Login failed.");
            }
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Make account
        }
    }
}
