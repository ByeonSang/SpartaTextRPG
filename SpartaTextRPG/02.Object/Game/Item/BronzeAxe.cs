using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object.Game
{
    internal class BronzeAxe : Weapon
    {
        public BronzeAxe() 
        {
            Name = "청동 도끼";
            Job = JobType.WARRIOR;

            attack = 5;
            weaponType = WeaponType.SWORD;

            SetInfoWrite($"공격력 +{attack} | 어디선가 사용됐던거 같은 도끼입니다.");

            Gold = 1500;
        }
    }
}
