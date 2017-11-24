namespace RPGManager.Domain.Models
{
    public class Weapon : Equipment
    {
        private int _weaponId;
        private int _damage;

        public int WeaponId { get => _weaponId; set => _weaponId = value; }
        public int Damage { get => _damage; set => _damage = value; }
    }
}