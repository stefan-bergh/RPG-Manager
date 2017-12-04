﻿using System.Windows;
using RPGManager.Domain.Models;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    using RPGManager.Domain.Enums;
    using RPGManager.Factory;
    using RPGManager.ILogic;

    /// <summary>
    ///     Interaction logic for Characters.xaml
    /// </summary>
    public partial class Characters : Window
    {
        private ICharacterLogic CL = CharacterLogicFactory.getCharacterSQLContext();
        private IClassLogic ClassL = ClassLogicFactory.getClassSQLContext();
        private User user;
        private UITypes _uiStatus = UITypes.CreateNew;
        private List<Character> characters = new List<Character>();
        private List<Class> classes = new List<Class>();

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

        public Characters(User user)
        {
            InitializeComponent();
            this.user = user;
            this.cbClasses.Items.Clear();
            if (this.ClassL.checkClasses(user.Id))
            {
                classes = ClassL.GetAllClasses(user.Id);
                foreach (Class cClass in classes)
                {
                    this.cbClasses.Items.Add(cClass);
                }
            }
            else
            {
                cbClasses.Items.Add("Please make a class for your characters first!");
            }
            if (!CL.checkCharacters(user.Id))
            {
                UIStatus = UITypes.CreateNew;
            }
            else
            {
                this.characters = CL.GetAllCharacters(user.Id);
                updateInputUI(characters.Count - 1);
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
                tbCharacterID_HIDDEN.Text = "";
                lbName.Content = "";
                tbName.Text = "";
                IudStartingLevel.Text = "";
                cbClasses.SelectedIndex = 0;
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
            if (!CL.checkCharacters(user.Id))
            {
                UIStatus = UITypes.CreateNew;
                return;
            }
            tbCharacterID_HIDDEN.Text = this.characters[i].Id.ToString();
            lbName.Content = this.characters[i].Name;
            tbName.Text = this.characters[i].Name;
            IudStartingLevel.Text = this.characters[i].StartingLevel.ToString();
            int cbValue = 0;
            foreach (Class cClass in this.cbClasses.Items)
            {
                if (cClass.Id == characters[i].ClassId)
                {
                    break;
                }
                cbValue++;
            }
            cbClasses.SelectedIndex = cbValue;
            if (i > 0)
            {
                iLeft.Visibility = Visibility.Visible;
            }
            else if (i <= 0)
            {
                iLeft.Visibility = Visibility.Hidden;
            }
            if (i < characters.Count - 1)
            {
                iRight.Visibility = Visibility.Visible;
            }
            else if (i >= characters.Count - 1)
            {
                iRight.Visibility = Visibility.Hidden;
            }
            UIStatus = UITypes.Default;
        }

        public bool checkInput()
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(this.cbClasses.Text) && !string.IsNullOrEmpty(
                this.IudStartingLevel.Text))
                return true;
            else
                return false;
        }

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            UIStatus = UITypes.CreateNew;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (checkInput())
            {
                Class cClass = (Class)this.cbClasses.SelectedValue;
                CL.insertCharacter(new Character()
                {
                    AccountId = user.Id,
                    ClassId = cClass.Id,
                    Name = this.tbName.Text,
                    StartingLevel = Convert.ToInt32(this.IudStartingLevel.Text)
                });

                UIStatus = UITypes.Default;
                this.characters = CL.GetAllCharacters(user.Id);
                updateInputUI(this.characters.Count - 1);
            }
            else
            {
                MessageBox.Show("Input is incorrect");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = characters.FindIndex(a => a.Id == Convert.ToInt32(this.tbCharacterID_HIDDEN.Text)) - 1;
            Class cClass = (Class)this.cbClasses.SelectedValue;
            CL.deleteCharacter(
                new Character()
                    {
                        Id = Convert.ToInt32(this.tbCharacterID_HIDDEN.Text),
                        AccountId = user.Id,
                        ClassId = cClass.Id,
                        Name = this.tbName.Text,
                        StartingLevel = Convert.ToInt32(this.IudStartingLevel.Text)
                    });
            characters = this.CL.GetAllCharacters(this.user.Id);
            if (index < 0) index = 0;
            updateInputUI(index);
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            Class cClass = (Class)this.cbClasses.SelectedValue;
            CL.updateCharacter(new Character()
                               {
                                   Id = Convert.ToInt32(this.tbCharacterID_HIDDEN.Text),
                                   AccountId = user.Id,
                                   ClassId = cClass.Id,
                                   Name = this.tbName.Text,
                                   StartingLevel = Convert.ToInt32(this.IudStartingLevel.Text)
                               });
            characters = this.CL.GetAllCharacters(this.user.Id);
            UIStatus = UITypes.Default;
            updateInputUI(characters.FindIndex(a => a.Id == Convert.ToInt32(this.tbCharacterID_HIDDEN.Text)));
        }

        private void iLeft_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(characters.FindIndex(a => a.Id == Convert.ToInt32(this.tbCharacterID_HIDDEN.Text)) - 1);
        }

        private void iRight_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(characters.FindIndex(a => a.Id == Convert.ToInt32(this.tbCharacterID_HIDDEN.Text)) + 1);
        }
        private void UI_Update(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }
        }

        private void UI_Update(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }
        }

        private void IudStartingLevel_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (UIStatus == UITypes.Default)
            {
                UIStatus = UITypes.InputChange;
            }
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