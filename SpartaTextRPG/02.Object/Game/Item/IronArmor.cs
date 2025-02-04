using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object.Game
{
    internal class IronArmor : Armor
    {
        public IronArmor() 
        {
            Name = "무쇠 갑옷";
            Job = JobType.WARRIOR;

            defence = 9;
            SetInfoWrite($"방어력 +{defence} | 무쇠로 만들어져 튼튼한 갑옷입니다.");

            Gold = 2100;
        }
    }
}
