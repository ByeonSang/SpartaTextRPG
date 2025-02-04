using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object
{
    internal class Weapon : Item, IEquiptable, IWeapon
    {
        public Weapon() 
        {
            itemType = ItemType.Weapon;
            isEquipt = false;
        }

        public void TakeItem(Player player)
        {
            if (isEquipt)
                return;

            IEquiptable equipt;
            if(player.Equipting.TryGetValue(ItemType.Weapon, out equipt))
            {
                if (equipt != null)
                    equipt.TakeOffItem(player);

                player.Equipting[ItemType.Weapon] = this;
                player.Attack += Attack;
                isEquipt = !isEquipt;
            }
        }

        public void TakeOffItem(Player player)
        {
            if (!isEquipt)
                return;

            IEquiptable equipt;
            if (player.Equipting.TryGetValue(ItemType.Weapon, out equipt))
            {
                player.Equipting[ItemType.Weapon] = null;
                player.Attack -= Attack;
                isEquipt = !isEquipt;
            }
        }

        public Item GetItem()
        {
            return this;
        }

        protected WeaponType weaponType;
        public WeaponType wpType { get => weaponType; }

        protected int attack;
        public int Attack { get => attack; }

        private bool isEquipt;
        public bool IsEquipt { get => isEquipt;}
    }
}
