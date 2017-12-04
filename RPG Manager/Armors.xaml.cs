using System.Windows;
using System.Windows.Input;
using RPGManager.Domain.Models;
using RPG_Manager.WPF;

namespace RPG_Manager
{
    using System;
    using System.Collections.Generic;
    using RPGManager.Domain.Enums;
    using RPGManager.Factory;
    using RPGManager.ILogic;

    /// <summary>
    ///     Interaction logic for Characters.xaml
    /// </summary>
    public partial class Armors : Window
    {
        private IArmorLogic AL = ArmorLogicFactory.getArmorSQLContext();
        private User user;
        private UITypes _uiStatus = UITypes.CreateNew;
        private List<Armor> armors = new List<Armor>();

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

        public Armors(User user)
        {
            InitializeComponent();
            this.user = user;
            this.cbType.Items.Clear();
            try 
            {
                foreach (ArmorTypes type in Enum.GetValues(typeof(ArmorTypes)))
                {
                    this.cbType.Items.Add(type);
                }
            }
            catch
            {
                this.cbType.Items.Add("Error loading armor types!");
            }
            if (!AL.checkArmors(user.Id))
            {
                UIStatus = UITypes.CreateNew;
            }
            else
            {
                armors = AL.GetAllArmors(user.Id);
                updateInputUI(armors.Count - 1);
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
                tbEquipmentID_HIDDEN.Text = "";
                tbArmorID_HIDDEN.Text = "";
                lbName.Content = "";
                tbName.Text = "";
                cbType.Text = "";
                tbPrice.Text = "";
                tbDefense.Text = "";
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
            if (!AL.checkArmors(user.Id))
            {
                UIStatus = UITypes.CreateNew;
                return;
            }
            tbPrice.Text = armors[i].Price.ToString();
            tbDefense.Text = armors[i].Defense.ToString();
            tbName.Text = armors[i].Name;
            lbName.Content = armors[i].Name;
            this.cbType.SelectedIndex = (int)armors[i].ArmorType;
            this.tbEquipmentID_HIDDEN.Text = armors[i].EquipmentId.ToString();
            this.tbArmorID_HIDDEN.Text = armors[i].ArmorId.ToString();
            if (i > 0)
            {
                iLeft.Visibility = Visibility.Visible;
            }
            else if (i <= 0)
            {
                iLeft.Visibility = Visibility.Hidden;
            }
            if (i < armors.Count - 1)
            {
                iRight.Visibility = Visibility.Visible;
            }
            else if (i >= armors.Count - 1)
            {
                iRight.Visibility = Visibility.Hidden;
            }
            UIStatus = UITypes.Default;
        }

        private void iIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* TODO: Add function to update icon picture */

            MessageBox.Show("Update icon.");
        }

        public bool checkInput()
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(this.cbType.Text) && !string.IsNullOrEmpty(
                this.tbPrice.Text) && !string.IsNullOrEmpty(this.tbDefense.Text))
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
                AL.insertArmor(new Armor()
                                   {
                                       AccountId = this.user.Id,
                                       ArmorType = (ArmorTypes)this.cbType.SelectedValue-1,
                                       EquipmentType = EquipmentTypes.Armor,
                                       Defense = Convert.ToInt32(this.tbDefense.Text),
                                       Name = this.tbName.Text,
                                       Price = float.Parse(this.tbPrice.Text)
                                   });
                UIStatus = UITypes.Default;
                this.armors = AL.GetAllArmors(user.Id);
                updateInputUI(this.armors.Count - 1);
            }
            else
            {
                MessageBox.Show("Input is incorrect");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = armors.FindIndex(a => a.EquipmentId == Convert.ToInt32(tbEquipmentID_HIDDEN.Text)) - 1;
            AL.deleteArmor(new Armor()
                               {
                                    Name  = this.tbName.Text,
                                    EquipmentId = Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text),
                                    Price = float.Parse(this.tbPrice.Text),
                                    AccountId = user.Id,
                                    ArmorType = (ArmorTypes)this.cbType.SelectedIndex,
                                    EquipmentType = EquipmentTypes.Armor,
                                    Defense = Convert.ToInt32(this.tbDefense.Text),
                                    ArmorId = Convert.ToInt32(this.tbArmorID_HIDDEN.Text)
                               });
            armors = this.AL.GetAllArmors(this.user.Id);
            if (index < 0) index = 0;
            updateInputUI(index);
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            AL.updateArmor(new Armor()
                                {
                                    Name = this.tbName.Text,
                                    EquipmentId = Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text),
                                    Price = float.Parse(this.tbPrice.Text),
                                    AccountId = user.Id,
                                    ArmorType = (ArmorTypes)this.cbType.SelectedIndex,
                                    EquipmentType = EquipmentTypes.Armor,
                                    Defense = Convert.ToInt32(this.tbDefense.Text),
                                    ArmorId = Convert.ToInt32(this.tbArmorID_HIDDEN.Text)
                                });
            armors = this.AL.GetAllArmors(this.user.Id);
            UIStatus = UITypes.Default;
            updateInputUI(armors.FindIndex(a => a.EquipmentId == Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text)));
        }

        private void iLeft_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(armors.FindIndex(a => a.EquipmentId == Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text)) - 1);
        }

        private void iRight_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(armors.FindIndex(a => a.EquipmentId == Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text)) + 1);
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