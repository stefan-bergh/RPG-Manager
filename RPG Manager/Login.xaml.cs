using System.Windows;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Database db = new Database();

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
            if (true) //db.checkUser(tbUser.Text ?? "", tbPass.Password ?? ""))
                Positioning.openNewWindow(new Overview(), this);
            else
                MessageBox.Show("Login failed.");
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Make account
        }
    }
}