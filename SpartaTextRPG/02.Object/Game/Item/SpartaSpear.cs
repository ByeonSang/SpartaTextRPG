using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object.Game
{
    internal class SpartaSpear : Weapon
    {
        public SpartaSpear()
        {
            Name = "스파르타의 창";
            Job = JobType.WARRIOR;
            attack = 7;

            weaponType = WeaponType.SPEAR;
            SetInfoWrite($"공격력 +{attack} | 스파르타의 전사들이 사용했다는 전설의 창입니다.");

            Gold = 3000;
        }
    }
}
