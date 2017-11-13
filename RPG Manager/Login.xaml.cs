using System.Windows;
using RPGManager.Domain.Models;
using RPGManager.Factory;
using RPGManager.ILogic;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public IUserLogic UL = UserLogicFactory.getUserLogic();

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
            if (UL.checkAccountDetails(tbUser.Text, tbPass.Password))
            {
                User user = UL.getUser(tbUser.Text, tbPass.Password);
                Positioning.openNewWindow(new Overview(user), this);
            }
            else
            {
                MessageBox.Show("Login failed.");
            }
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Creating an account is only possible on the website.");
        }
    }
}