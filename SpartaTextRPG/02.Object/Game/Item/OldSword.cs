using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object.Game
{
    internal class OldSword : Weapon
    {
        public OldSword() 
        {
            Name = "낡은 검";
            Job = JobType.None;

            attack = 2;
            weaponType = WeaponType.SWORD;

            SetInfoWrite($"공격력 +{attack} | 쉽게 볼 수 있는 낡은 검 입니다.");

            Gold = 1200;
        }
    }
}
