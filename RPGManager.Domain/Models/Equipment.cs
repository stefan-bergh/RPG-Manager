namespace RPGManager.Domain.Models
{
    using RPGManager.Domain.Enums;

    public abstract class Equipment
    {
        private int _equipmentId;

        private int _accountId;

        private string _name;

        private float _price;

        private EquipmentTypes _equipmentType;

        public int EquipmentId
        {
            get => _equipmentId;
            set => _equipmentId = value;
        }

        public int AccountId
        {
            get => _accountId;
            set => _accountId = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public float Price
        {
            get => _price;
            set => _price = value;
        }

        public EquipmentTypes EquipmentType
        {
            get => _equipmentType;
            set => _equipmentType = value;
        }

    }
}