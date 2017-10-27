using RPGManager.Domain.Enums;

namespace RPGManager.ILogic
{
    public interface IEquipment
    {
        bool editName(string name);

        bool editPrice(double price);

        bool editType(EquipmentTypes type);
    }
}