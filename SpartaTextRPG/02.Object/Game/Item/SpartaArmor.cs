using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._02.Object.Game.Item
{
    internal class SpartaArmor : Armor
    {
        public SpartaArmor()
        {
            Name = "스파르타 갑옷";
            Job = JobType.WARRIOR;

            defence = 15;
            SetInfoWrite($"방어력 +{defence} | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");

            Gold = 3500;
        }
    }
}
