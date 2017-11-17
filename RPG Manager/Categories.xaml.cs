using System;
using System.Collections.Generic;
using System.Windows;
using RPGManager.Domain.Enums;
using RPGManager.Domain.Models;
using RPGManager.Factory;
using RPGManager.ILogic;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    /// <summary>
    ///     Interaction logic for Characters.xaml
    /// </summary>
    public partial class Categories : Window
    {
        private ICategorieLogic UL = CategorieLogicFactory.getClassSQLContext();
        private User user;
        private UITypes _uiStatus = UITypes.CreateNew;
        private List<ClassCategory> categories = new List<ClassCategory>();

        public UITypes UIStatus
        {
            get => _uiStatus;
            set
            {
                _uiStatus = value;
                if (_uiStatus == UITypes.Default)
                {
                    updateButtonUI(1);
                }
                if (_uiStatus == UITypes.CreateNew)
                {
                    updateButtonUI(2);
                }
                if (_uiStatus == UITypes.InputChange)
                {
                    updateButtonUI(3);
                }
            }
        }

        public Categories(User user)
        {
            InitializeComponent();
            this.user = user;
            if (!UL.checkCategories(user.Id))
            {
                UIStatus = UITypes.CreateNew;
            }
            else
            {
                categories = UL.GetAllCategorys(user.Id);
                updateInputUI(categories.Count-1);
                UIStatus = UITypes.Default;
            }
        }

        public void updateButtonUI(int UI)
        {
            // Default UI layout
            if (UI == 1)
            {
                btNew.Visibility = Visibility.Visible;
                btSave.Visibility = Visibility.Hidden;
                btUpdate.Visibility = Visibility.Hidden;
                btDelete.Visibility = Visibility.Visible;
            }
            // While making a new item
            else if (UI == 2)
            {
                btNew.Visibility = Visibility.Hidden;
                btSave.Visibility = Visibility.Visible;
                btUpdate.Visibility = Visibility.Hidden;
                btDelete.Visibility = Visibility.Hidden;
                tbID_HIDDEN.Text = "";
                lbName.Content = "";
                tbName.Text = "";
                tbDescription.Text = "";
            }
            // While editing an existing item
            else if (UI == 3)
            {
                btNew.Visibility = Visibility.Hidden;
                btSave.Visibility = Visibility.Hidden;
                btUpdate.Visibility = Visibility.Visible;
                btDelete.Visibility = Visibility.Visible;
            }
        }

        public void updateInputUI(int i)
        {
            tbDescription.Text = categories[i].Description;
            tbName.Text = categories[i].Name;
            lbName.Content = categories[i].Name;
            tbID_HIDDEN.Text = categories[i].Id.ToString();
            if (i > 0)
            {
                iLeft.Visibility = Visibility.Visible;
            }
            else if (i <= 0)
            {
                iLeft.Visibility = Visibility.Hidden;
            }
            if (i < categories.Count-1)
            {
                iRight.Visibility = Visibility.Visible;
            }
            else if (i >= categories.Count-1)
            {
                iRight.Visibility = Visibility.Hidden;
            }
            UIStatus = UITypes.Default; 
        }

        public bool checkInput()
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbDescription.Text))
                return true;
            else
                return false;
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

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            UIStatus = UITypes.CreateNew;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkInput())
            {
                UL.insertCategory(new ClassCategory(user.Id, tbName.Text, tbDescription.Text));
                UIStatus = UITypes.Default;
                categories = UL.GetAllCategorys(user.Id);
                updateInputUI(categories.Count-1);
            }
            else
            {
                MessageBox.Show("Input is incorrect");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            categories = UL.GetAllCategorys(user.Id);
            UL.deleteCategory(new ClassCategory(user.Id, Convert.ToInt32(tbID_HIDDEN.Text), tbName.Text, tbDescription.Text));
            updateInputUI(categories.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)) -1);
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            UL.updateCategory(new ClassCategory(user.Id, Convert.ToInt32(tbID_HIDDEN.Text), tbName.Text, tbDescription.Text));
            UIStatus = UITypes.Default;
            updateInputUI(categories.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)));
        }

        private void iLeft_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(categories.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)) - 1);
        }

        private void iRight_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(categories.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)) + 1);
        }

        private void tbName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }
        }

        private void tbDescription_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }

        }
    }
}