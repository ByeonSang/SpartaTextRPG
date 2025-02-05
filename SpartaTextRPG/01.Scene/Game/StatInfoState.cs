using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaTextRPG._04.Data;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG.Scene
{
    internal class StatInfoState : State
    {
        public StatInfoState(StateMachine _stateMachine, Player _player) : base(_stateMachine)
        {
            player = _player;
        }

        public override void Enter(object? Object)
        {
            //TODO:
        }

        public override void Exit()
        {
            Console.Clear();
        }


        public override void Update()
        {
            #region JobSwitch
            JobType job = player.Job;
            string stringJob = "";

            switch (job)
            {
                case JobType.WARRIOR:
                    stringJob = "전사";
                    break;
                case JobType.WIZARD:
                    stringJob = "마법사";
                    break;
                case JobType.None:
                    stringJob = "초보자";
                    break;
            }
            #endregion

            while (true)
            {
                ShowTitle();
                Console.WriteLine($"Lv. {player.Level.ToString("D2")}");
                Console.WriteLine($"Chad ( {stringJob} )");
                Console.WriteLine($"공격력 : {player.Attack}");
                Console.WriteLine($"방어력 : {player.Defence}");
                Console.WriteLine($"체 력 : {player.Health}");
                Console.WriteLine($"Gold : {player.Gold}");
                Console.WriteLine($"경험치 : {player.Exp} (다음 레벨까지 남은 경험치 : {AmountExp.amount[player.Level - 1] - player.Exp})\n");

                ShowMenu();

                if (!GetUserInput(out selectedMenu))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }

                break;
            }

            stateMachine.ChangeScene(stateMachine.MainScene);
        }

        public override bool GetUserInput(out int value)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out value))
                return false;

            if (value < 0 || value > totalMenuCount - 1)
                return false;

            return true;
        }

        public override void ShowTitle()
        {
            Render.ColorText("상태 보기\n", ConsoleColor.Yellow);
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
        }

        private Player player;
    }
}
