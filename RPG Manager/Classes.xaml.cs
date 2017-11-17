﻿using System.Windows;
using RPGManager.Domain.Models;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    /// <summary>
    ///     Interaction logic for Characters.xaml
    /// </summary>
    public partial class Classes : Window
    {
        private User user;

        public Classes(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        #region MenuCode
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
        #endregion
    }
}