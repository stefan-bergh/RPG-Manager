namespace RPGManager.Domain.Models
{
    public class Item : Equipment
    {
        private int _itemId;
        private string _effect;
        private int _repeat;

        public int ItemId { get => _itemId; set => _itemId = value; }
        public string Effect { get => _effect; set => _effect = value; }
        public int Repeat { get => _repeat; set => _repeat = value; }
    }
}