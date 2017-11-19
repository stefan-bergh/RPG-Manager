using System.Collections.Generic;

namespace RPGManager.Domain.Models
{
    public class Character
    {
        private int _id;
        private int _accountId;
        private string _name;
        private int _startingLevel;
        private int _classId;
        private List<Stat> _stats;

        public int Id { get => _id; set => _id = value; }
        public int AccountId { get => _accountId; set => _accountId = value; }
        public string Name { get => _name; set => _name = value; }
        public int StartingLevel { get => _startingLevel; set => _startingLevel = value; }
        public int ClassId { get => _classId; set => _classId = value; }
        public List<Stat> Stats { get => _stats; set => _stats = value; }

        public Character(int accountId, string name, int startingLevel, int classId)
        {
            _accountId = accountId;
            _name = name;
            _startingLevel = startingLevel;
            _classId = classId;
        }

        public Character(int id, int accountId, string name, int startingLevel, int classId)
        {
            _id = id;
            _accountId = accountId;
            _name = name;
            _startingLevel = startingLevel;
            _classId = classId;
        }
    }
}