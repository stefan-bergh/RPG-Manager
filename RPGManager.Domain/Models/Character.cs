using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPGManager.Domain.Models
{
    public class Character
    {
        private int _id;
        private int _accountId;
        private string _name;
        private int _startingLevel;
        private int _classId;

        
        public int Id { get => _id; set => _id = value; }
        public int AccountId { get => _accountId; set => _accountId = value; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get => _name; set => _name = value; }
        [Required]
        [Display(Name = "Starting level")]
        [Range(1, 100)]
        public int StartingLevel { get => _startingLevel; set => _startingLevel = value; }
        [Required]
        public int ClassId { get => _classId; set => _classId = value; }

        public Character()
        {
            
        }

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