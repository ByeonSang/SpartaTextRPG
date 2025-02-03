using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object.Game
{
    internal class IronArmor : Item, IEquiptable
    {
        public IronArmor() 
        {
            Name = "무쇠 갑옷";
            Type = ItemType.Equipment;
            Job = JobType.WARRIOR;

            defence = 5;
            SetInfoWrite($"방어력 +{defence} | 무쇠로 만들어져 튼튼한 갑옷입니다.");
            isEquipt = false;
        }

        public void TakeItem(Player player)
        {
            if (isEquipt)
                return;

            player.Defence += Defence;
            isEquipt = !isEquipt;
        }

        public void TakeOffItem(Player player)
        {
            if (!isEquipt)
                return;

            player.Defence -= Defence;
            isEquipt = !isEquipt;
        }

        public Item GetItem()
        {
            return this;
        }

        private int defence;
        public int Defence { get => defence;}

        private bool isEquipt;
        public bool IsEquipt { get => isEquipt; set => isEquipt = value; }
    }
}
