using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._02.Object.Game.Item
{
    internal class TraineeArmor : Armor
    {
        public TraineeArmor()
        {
            Name = "수련자 갑옷";
            Job = JobType.WARRIOR;

            defence = 5;
            SetInfoWrite($"방어력 +{defence} | 수련에 도움을 주는 갑옷입니다.");

            Gold = 1000;
        }
    }
}
