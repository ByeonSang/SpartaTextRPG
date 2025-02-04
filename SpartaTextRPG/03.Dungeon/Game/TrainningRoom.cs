using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._03.Dungeon.Game
{
    internal class TrainningRoom : Dungeon
    {
        public TrainningRoom(Player _player) : base(_player)
        {
            // 초기화 ( 권장 방어력, 클리어시 보상, 피해량 )
            name = "훈련실";
            level = 1;
            Initialize();
        }

        public override void Initialize()
        {
            InitDefence(5, 11, 17);
            InitClearGold(1000, 1700, 2500);
            InitClearExp(100, 150, 250);

            KeyValuePair<int, int> easy = new KeyValuePair<int, int>(20, 35);
            KeyValuePair<int, int> normal = new KeyValuePair<int, int>(24, 39);
            KeyValuePair<int, int> hard = new KeyValuePair<int, int>(30, 45);
            InitDamage(easy, normal, hard);
        }
    }
}
