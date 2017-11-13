namespace RPGManager.Domain.Models
{
    public class Stat
    {
        private int _id;
        private string _name;
        private string _description;
        private int _startingValue;
        private int _growthChance;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public int StartingValue { get => _startingValue; set => _startingValue = value; }
        public int GrowthChance { get => _growthChance; set => _growthChance = value; }

        public Stat(int id, string name, string description, int startingValue, int growthChance)
        {
            _id = id;
            _name = name;
            _description = description;
            _startingValue = startingValue;
            _growthChance = growthChance;
        }
    }
}