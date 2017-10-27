using RPGManager.Domain.Models;

namespace RPGManager.ILogic
{
    public interface I
    {
        bool EditName(string name);
        bool EditRequiredLevel(int level);
        bool AddSkillType(SkillType type);
        bool SetSkillType(SkillType type);
        bool EditSkillType(SkillType type);
        bool RemoveSkillType();
    }
}