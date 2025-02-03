using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG.Scene
{
    internal class StatInfoState : State, IMenuList, ITextRenderer
    {
        public StatInfoState(StateMachine _stateMachine, Player _player) : base(_stateMachine)
        {
            player = _player;
            TotalMenuCount = 1;
        }

        public override void Enter()
        {
            RenderText("상태 보기", ConsoleColor.Yellow);
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
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
                Console.WriteLine($"Lv. {player.Level.ToString("D2")}");
                Console.WriteLine($"Chad ( {stringJob} )");
                Console.WriteLine($"공격력 : {player.Attack}");
                Console.WriteLine($"방어력 : {player.Defence}");
                Console.WriteLine($"체 력 : {player.Health}");
                Console.WriteLine($"Gold : {player.Gold}\n");

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

        public void ShowMenu(int idx = 0)
        {
            Console.WriteLine("0. 나가기");
        }

        public bool GetUserInput(out int value)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out value))
                return false;

            if (value < 0 || value > totalMenuCount - 1)
                return false;

            return true;
        }

        public void RenderText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private int selectedMenu;
        public int SelectedMenu { get => selectedMenu; private set => selectedMenu = value; } // 선택된 메뉴 번호

        private int totalMenuCount;
        public int TotalMenuCount { get => totalMenuCount; private set => totalMenuCount = value; } // 메뉴 총 갯수

        private Player player;
    }
}
