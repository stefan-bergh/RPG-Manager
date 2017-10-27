using RPGManager.Domain.Enums;
using RPGManager.Domain.Models;

namespace RPGManager.ILogic
{
    public interface ICharacter
    {
        bool Editname(string name);
        bool EditStartingLevel(int level);
        bool SetCharacterClass(Class charClass);
        bool EditCharacterClass(Class charClass);
        bool RemoveCharacterClass();
        bool AddEquipment(Equipment equipment);
        bool SetCharacterEquipment(EquipmentTypes type, Equipment equipment);
        bool EditCharacterEquipment(EquipmentTypes type, Equipment equipment);
        bool RemoveCharacterEquipment(EquipmentTypes type);
        bool AddStat(Stat stat);
        bool SetCharacterStat(Stat stat, int statvalue);
        bool EditCharacterStat(Stat stat, int statvalue);
        bool RemoveCharacterStat(Stat stat);
        bool AddSkill(Skill skill);
        bool SetCharacterSkill(Skill skill);
        bool EditCharacterSkill(Skill skill);
        bool RemoveCharacterSkill(Skill skill);
    }
}