using System.Windows;
using System.Windows.Input;
using RPGManager.Domain.Models;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    /// <summary>
    ///     Interaction logic for Characters.xaml
    /// </summary>
    public partial class Items : Window
    {
        private User user;

        public Items(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btOverview_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Overview(user), this);
        }

        private void btCharacters_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Characters(user), this);
        }

        private void btClasses_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Classes(user), this);
        }

        private void btCategories_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Categories(user), this);
        }

        private void btItems_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Items(user), this);
        }

        private void btArmors_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Armors(user), this);
        }

        private void btWeapons_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Weapons(user), this);
        }

        private void btSkills_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Skills(user), this);
        }

        private void iIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* TODO: Add function to update icon picture */

            MessageBox.Show("Update icon.");
        }
    }
}