using SpartaTextRPG._02.Object;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG
{
    public enum JobType
    {
        None,
        WARRIOR,
        WIZARD,
    }

    internal class Player : Entity
    {
        public Player(string _name, int _level, int _maxHealth, int _defence, int _attack, int _gold,JobType _jobType) : base(_name, _level, _maxHealth, _defence, _attack)
        {
            equipInventory = new Inventory<IEquiptable>(5, 5);// 5 x 5 인벤토리 생성

            Type = EntityType.Player;
            gold = _gold;
            jobType = _jobType;

            // 착용중인 장비템 클래스를 따로 파도 좋을꺼 같음
            // 직업에 따라서 착용하는 무기도 달라질테니
            equipting = new Dictionary<ItemType, IEquiptable>(); // 현재 장착중인 아이템
            equipting.Add(ItemType.Equipment, null);
            equipting.Add(ItemType.Weapon, null);
        }

        public void AddLevel()
        {
            Level++;
            Attack += 0.5f;
            Defence += 1;
        }

        public override void TakeDamage(int _damage)
        {
            Health -= _damage;
        }

        // 장비 인벤토리
        public Inventory<IEquiptable> equipInventory;

        private JobType jobType;
        public JobType Job { get => jobType; private set => jobType = value; }

        private int gold;
        public int Gold
        {
            get => gold;
            set
            {
                gold = value;

                if (gold < 0) gold = 0;
                else if (gold > Game.MaxGold) gold = Game.MaxGold;
            }
        }

        private int exp;
        public int Exp { get => exp; set => exp = value; }

        // 장비창
        private Dictionary<ItemType, IEquiptable> equipting;
        public Dictionary<ItemType, IEquiptable> Equipting { get => equipting;}
    }
}
