using RPGManager.Domain.Models;

namespace RPGManager.ILogic
{
    public interface IUser
    {
        bool AddEquipment();
        Equipment GetEquipment(int equipmentid);
        bool AddCharacter(Character character);
        Character GetCharacter(int characterid);
        bool AddClass(Class charclass);
        Class GetClass(int classid);
        int[] GetCategoryIDs();
        int[] GetClassIDs();
        int[] GetCharacterIDs();
        int[] GetArmorIDs();
        int[] GetWeaponIDs();
        int[] GetItemIDs();
        int[] GetSkillIDs();
    }
}