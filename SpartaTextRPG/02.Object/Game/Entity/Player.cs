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
        public Player(string _name, int _level, int _health, int _defence, int _attack, int _gold,JobType _jobType) : base(_name, _level, _health, _defence, _attack)
        {
            equipInventory = new Inventory<IEquiptable>(5, 5);// 5 x 5 인벤토리 생성

            Type = EntityType.Player;
            gold = _gold;
            jobType = _jobType;
        }

        public override void TakeDamage(int _damage)
        {
            Health -= _damage;
        }

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
    }
}
