using System.Collections.Generic;

namespace RPGManager.Domain.Models
{
    public class Character
    {
        private int _id;
        private string _name;
        private int _startingLevel;
        private Class _characterClass;
        private List<Stat> _stats;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int StartingLevel { get => _startingLevel; set => _startingLevel = value; }
        public Class CharacterClass { get => _characterClass; set => _characterClass = value; }
        public List<Stat> Stats { get => _stats; set => _stats = value; }

        public Character(int id, string name, int startingLevel, Class characterClass, List<Stat> stats)
        {
            _id = id;
            _name = name;
            _startingLevel = startingLevel;
            _characterClass = characterClass;
            _stats = stats;
        }
    }
}