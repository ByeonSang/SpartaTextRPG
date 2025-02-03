using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object.Game
{
    internal class OldSword : Item, IEquiptable, IWeapon
    {
        public OldSword() 
        {
            Name = "낡은 검";
            Type = ItemType.Equipment;
            Job = JobType.None;

            attack = 2;
            weaponType = WeaponType.SPEAR;

            SetInfoWrite($"공격력 +{attack} | 쉽게 볼 수 있는 낡은 검 입니다.");
            isEquipt = false;
        }

        public void TakeItem(Player player)
        {
            if (isEquipt)
                return;

            player.Attack += Attack;
            isEquipt = !isEquipt;

        }

        public void TakeOffItem(Player player)
        {
            if (!isEquipt)
                return;

            player.Attack -= Attack;
            isEquipt = !isEquipt;
        }

        public Item GetItem()
        {
            return this;
        }

        private WeaponType weaponType;
        public WeaponType wpType { get => weaponType; set => weaponType = value; }

        private int attack;
        public int Attack { get => attack; }

        private bool isEquipt;
        public bool IsEquipt { get => isEquipt; set => isEquipt = value; }
    }
}
