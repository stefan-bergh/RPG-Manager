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
    public partial class Classes : Window
    {
        private User user;
        private ICategorieLogic CatL = CategorieLogicFactory.getCategorieSQLContext();
        private IClassLogic ClassL = ClassLogicFactory.getClassSQLContext();
        private UITypes _uiStatus = UITypes.CreateNew;
        private List<Class> classes = new List<Class>();
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


        public Classes(User user)
        {
            InitializeComponent();
            this.user = user;
            
            if (CatL.checkCategories(user.Id))
            {
                categories = CatL.GetAllCategorys(user.Id);
                foreach (ClassCategory categorie in categories)
                {
                    cbCategorie.Items.Add(categorie);
                }
            }
            else
            {
                cbCategorie.Items.Add("Please make a category for your classes first!");
            }
            if (!ClassL.checkClasses(user.Id))
            {
                UIStatus = UITypes.CreateNew;
            }
            else
            {
                classes = ClassL.GetAllClasses(user.Id);
                updateInputUI(classes.Count - 1);
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
                sLevel.Value = 1;
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
            if (!ClassL.checkClasses(user.Id))
            {
                UIStatus = UITypes.CreateNew;
                return;
            }
            sLevel.Value = classes[i].StartingLevel;
            tbName.Text = classes[i].Name;
            int cbValue = 0;
            foreach (ClassCategory cat in cbCategorie.Items)
            {
                if (cat.Id == classes[i].ClassCategoryId)
                {
                    break;
                }
                cbValue++;
            }
            cbCategorie.SelectedIndex = cbValue;
            lbName.Content = classes[i].Name;
            tbID_HIDDEN.Text = classes[i].Id.ToString();
            if (i > 0)
            {
                iLeft.Visibility = Visibility.Visible;
            }
            else if (i <= 0)
            {
                iLeft.Visibility = Visibility.Hidden;
            }
            if (i < classes.Count - 1)
            {
                iRight.Visibility = Visibility.Visible;
            }
            else if (i >= classes.Count - 1)
            {
                iRight.Visibility = Visibility.Hidden;
            }
            UIStatus = UITypes.Default;
        }
        public bool checkInput()
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(cbCategorie.Text) && cbCategorie.Text != "Please make a category for your classes first!")
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
                ClassL.insertClass(new Class(user.Id, categories[cbCategorie.SelectedIndex].Id, tbName.Text, (int)sLevel.Value));
                UIStatus = UITypes.Default;
                classes = ClassL.GetAllClasses(user.Id);
                updateInputUI(classes.Count - 1);
            }
            else
            {
                MessageBox.Show("Input is incorrect");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.ClassL.checkCharacterClasses(Convert.ToInt32(tbID_HIDDEN.Text)))
            {
                MessageBox.Show(
                    "This class is being used by existing characters.\r\nPlease make sure this class is no longer in use before attemptign to delete it.");
                return;
            }
            int index = classes.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)) - 1;
            ClassL.deleteClass(new Class(Convert.ToInt32(tbID_HIDDEN.Text), user.Id, categories[cbCategorie.SelectedIndex].Id, tbName.Text, (int)sLevel.Value));
            classes = ClassL.GetAllClasses(user.Id);
            if (index < 0) index = 0;
            updateInputUI(index);
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            ClassL.updateClass(new Class(Convert.ToInt32(tbID_HIDDEN.Text), user.Id, categories[cbCategorie.SelectedIndex].Id, tbName.Text, (int)sLevel.Value));
            classes = ClassL.GetAllClasses(user.Id);
            UIStatus = UITypes.Default;
            updateInputUI(classes.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)));
        }

        private void iLeft_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(classes.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)) - 1);
        }

        private void iRight_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(classes.FindIndex(a => a.Id == Convert.ToInt32(tbID_HIDDEN.Text)) + 1);
        }

        private void tbName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }
        }

        private void cbCategorie_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }
        }

        private void sLevel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }

        }
    }
}