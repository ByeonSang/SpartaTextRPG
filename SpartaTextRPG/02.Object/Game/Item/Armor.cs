using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object
{
    internal class Armor : Item, IEquiptable
    {
        public Armor() 
        {
            itemType = ItemType.Equipment;
            isEquipt = false;
        }

        public void TakeItem(Player player)
        {
            if (isEquipt)
                return;

            IEquiptable equipt;
            if (player.Equipting.TryGetValue(ItemType.Equipment, out equipt))
            {
                if (equipt != null)
                    equipt.TakeOffItem(player);

                player.Equipting[ItemType.Equipment] = this;
                player.Defence += Defence;
                isEquipt = !isEquipt;
            }
        }

        public void TakeOffItem(Player player)
        {
            if (!isEquipt)
                return;

            IEquiptable equipt;
            if (player.Equipting.TryGetValue(ItemType.Equipment, out equipt))
            {
                player.Equipting[ItemType.Equipment] = null;
                player.Defence -= Defence;
                isEquipt = !isEquipt;
            }
        }

        public Item GetItem()
        {
            return this;
        }

        protected int defence;
        public int Defence { get => defence;}

        protected bool isEquipt;
        public bool IsEquipt { get => isEquipt; }
    }
}
