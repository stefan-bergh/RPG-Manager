namespace RPGManager.Domain.Models
{
    using RPGManager.Domain.Enums;

    public class Armor : Equipment
    {
        private int _armorId;
        private int _defense;
        private ArmorTypes _armorType;

        public int ArmorId { get => _armorId; set => _armorId = value; }
        public int Defense { get => _defense; set => _defense = value; }
        public ArmorTypes ArmorType { get => _armorType; set => _armorType = value; }

        public Armor()
        {
            
        }
        public Armor(int equipmentId, int accountId, int armorId, string name, float price, EquipmentTypes equipmentType, int defense, ArmorTypes armorType)
        {
            this.EquipmentId = equipmentId;
            this.AccountId = accountId;
            this.Name = name;
            this.Price = price;
            this.EquipmentType = equipmentType;
            this._armorId = armorId;
            this._defense = defense;
            this._armorType = armorType;
        }

        public override string ToString()
        {
            return Name;
        }
    }}