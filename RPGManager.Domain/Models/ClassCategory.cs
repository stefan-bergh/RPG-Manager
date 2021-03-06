﻿using System.ComponentModel.DataAnnotations;

namespace RPGManager.Domain.Models
{
    public class ClassCategory
    {
        private int _id;
        private int _accountId;
        private string _name;
        private string _description;

        public int Id { get => _id; set => _id = value; }
        public int AccountId { get => _accountId; set => _accountId = value; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get => _name; set => _name = value; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(60, MinimumLength = 3)]
        public string Description { get => _description; set => _description = value; }

        public ClassCategory(int id, int accountId, string name, string description)
        {
            _id = id;
            _accountId = accountId;
            _name = name;
            _description = description;
        }
        public ClassCategory(int accountId, string name, string description)
        {
            _accountId = accountId;
            _name = name;
            _description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}