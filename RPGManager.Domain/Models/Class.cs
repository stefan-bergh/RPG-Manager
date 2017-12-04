namespace RPGManager.Domain.Models
{
    public class Class
    {
        private int _id;
        private int _accountId;
        private int _classCategoryId;
        private string _name;
        private int startingLevel;

        public int Id { get => _id; set => _id = value; }
        public int AccountId { get => _accountId; set => _accountId = value; }
        public int ClassCategoryId { get => _classCategoryId; set => _classCategoryId = value; }
        public string Name { get => _name; set => _name = value; }
        public int StartingLevel { get => startingLevel; set => startingLevel = value; }

        public Class(int id, int accountId, int classCategoryId, string name, int startingLevel)
        {
            _id = id;
            _accountId = accountId;
            _classCategoryId = classCategoryId;
            _name = name;
            this.startingLevel = startingLevel;
        }

        public Class(int accountId, int classCategoryId, string name, int startingLevel)
        {
            _accountId = accountId;
            _classCategoryId = classCategoryId;
            _name = name;
            this.startingLevel = startingLevel;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}