using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object.Game
{
    internal class SpartaSpear : Item, IEquiptable, IWeapon
    {
        public SpartaSpear() 
        {
            Name = "스파르타의 창";
            Type = ItemType.Equipment;
            Job = JobType.WARRIOR;

            attack = 7;
            weaponType = WeaponType.SPEAR;
            SetInfoWrite($"공격력 +{attack} | 스파르타의 전사들이 사용했다는 전설의 창입니다.");
            isEquipt = false;

            Gold = 3000;
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
