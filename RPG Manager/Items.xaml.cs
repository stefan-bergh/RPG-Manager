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
    public partial class Items : Window
    {
        private IItemLogic IL = ItemLogicFactory.getItemSQLContext();
        private User user;
        private UITypes _uiStatus = UITypes.CreateNew;
        private List<Item> items = new List<Item>();

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

        public Items(User user)
        {
            InitializeComponent();
            this.user = user;
            if (!IL.checkItems(user.Id))
            {
                UIStatus = UITypes.CreateNew;
            }
            else
            {
                items = IL.GetAllItems(user.Id);
                updateInputUI(items.Count - 1);
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
                tbItemID_HIDDEN.Text = "";
                lbName.Content = "";
                tbName.Text = "";
                tbPrice.Text = "";
                tbEffect.Text = "";
                tbRepeat.Text = "";
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
            if (!IL.checkItems(user.Id))
            {
                UIStatus = UITypes.CreateNew;
                return;
            }
            tbPrice.Text = items[i].Price.ToString();
            tbEffect.Text = items[i].Effect;
            tbRepeat.Text = items[i].Repeat.ToString();
            tbName.Text = items[i].Name;
            lbName.Content = items[i].Name;
            this.tbEquipmentID_HIDDEN.Text = items[i].EquipmentId.ToString();
            this.tbItemID_HIDDEN.Text = items[i].ItemId.ToString();
            if (i > 0)
            {
                iLeft.Visibility = Visibility.Visible;
            }
            else if (i <= 0)
            {
                iLeft.Visibility = Visibility.Hidden;
            }
            if (i < items.Count - 1)
            {
                iRight.Visibility = Visibility.Visible;
            }
            else if (i >= items.Count - 1)
            {
                iRight.Visibility = Visibility.Hidden;
            }
            UIStatus = UITypes.Default;
        }

        public bool checkInput()
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(this.tbEffect.Text) && !string.IsNullOrEmpty(
                this.tbPrice.Text) && !string.IsNullOrEmpty(this.tbRepeat.Text))
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
                IL.insertItem(new Item()
                {
                    AccountId = this.user.Id,
                    EquipmentType = EquipmentTypes.Item,
                    Repeat = Convert.ToInt32(this.tbRepeat.Text),
                    Effect = this.tbEffect.Text,
                    Name = this.tbName.Text,
                    Price = float.Parse(this.tbPrice.Text)
                });
                UIStatus = UITypes.Default;
                this.items = IL.GetAllItems(user.Id);
                updateInputUI(this.items.Count - 1);
            }
            else
            {
                MessageBox.Show("Input is incorrect");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = items.FindIndex(a => a.EquipmentId == Convert.ToInt32(tbEquipmentID_HIDDEN.Text)) - 1;
            IL.deleteItem(new Item()
            {
                Name = this.tbName.Text,
                EquipmentId = Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text),
                Price = float.Parse(this.tbPrice.Text),
                AccountId = user.Id,
                EquipmentType = EquipmentTypes.Item,
                Repeat = Convert.ToInt32(this.tbRepeat.Text),
                Effect = this.tbEffect.Text,
                ItemId = Convert.ToInt32(this.tbItemID_HIDDEN.Text)
            });
            items = this.IL.GetAllItems(this.user.Id);
            updateInputUI(index);
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            IL.updateItem(new Item()
            {
                Name = this.tbName.Text,
                EquipmentId = Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text),
                Price = float.Parse(this.tbPrice.Text),
                AccountId = user.Id,
                EquipmentType = EquipmentTypes.Item,
                Repeat = Convert.ToInt32(this.tbRepeat.Text),
                Effect = this.tbEffect.Text,
                ItemId = Convert.ToInt32(this.tbItemID_HIDDEN.Text)
            });
            items = this.IL.GetAllItems(this.user.Id);
            UIStatus = UITypes.Default;
            updateInputUI(items.FindIndex(a => a.EquipmentId == Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text)));
        }

        private void iLeft_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(items.FindIndex(a => a.EquipmentId == Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text)) - 1);
        }

        private void iRight_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            updateInputUI(items.FindIndex(a => a.EquipmentId == Convert.ToInt32(this.tbEquipmentID_HIDDEN.Text)) + 1);
        }
        private void UI_Update(object sender, System.Windows.Controls.TextChangedEventArgs e)
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

        private void iIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* TODO: Add function to update icon picture */

            MessageBox.Show("Update icon.");
        }

        #endregion
    }
}