using RPGManager.Domain.Models;

namespace RPGManager.ILogic
{
    public interface IClass
    {
        bool Editname(string name);
        bool EditStartingLevel(int level);
        bool AddEquipment(Equipment equipment);
        bool AddClassEquipment(Equipment equipment);
        bool EditClassEquipment(Equipment equipment);
        bool RemoveClassEquipment(Equipment equipment);
        bool AddStat(Stat stat);
        bool SetClassStat(Stat stat);
        bool EditClassStat(Stat stat);
        bool RemoveClassStat(Stat stat);
        bool AddSkill(Skill skill);
        bool SetClassSkill(Skill skill);
        bool EditClassSkill(Skill skill);
        bool RemoveClassSkill(Skill skill);
        bool AddClassCategory(ClassCategory cc);
        bool SetClassCategory(ClassCategory cc);
        bool EditClassCategory(ClassCategory cc);
        bool RemoveClassCategory(ClassCategory cc);
    }
}