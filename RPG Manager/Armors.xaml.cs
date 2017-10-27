using System.Windows;
using System.Windows.Input;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    /// <summary>
    ///     Interaction logic for Characters.xaml
    /// </summary>
    public partial class Armors : Window
    {
        public Armors()
        {
            InitializeComponent();
        }

        private void btOverview_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Overview(), this);
        }

        private void btCharacters_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Characters(), this);
        }

        private void btClasses_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Classes(), this);
        }

        private void btCategories_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Categories(), this);
        }

        private void btItems_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Items(), this);
        }

        private void btArmors_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Armors(), this);
        }

        private void btWeapons_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Weapons(), this);
        }

        private void btSkills_Click(object sender, RoutedEventArgs e)
        {
            Positioning.openNewWindow(new Skills(), this);
        }

        private void iIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* TODO: Add function to update icon picture */

            MessageBox.Show("Update icon.");
        }
    }
}