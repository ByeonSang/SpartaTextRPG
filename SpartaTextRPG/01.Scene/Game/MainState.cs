using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG.Scene
{
    internal class MainState : State, IMenuList
    {
        public MainState(StateMachine _stateMachine) : base(_stateMachine)
        {
            totalMenuCount = 3;
        }

        public override void Enter()
        {
            WellcomeToWorld(); // 환영 인사말
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override void Update()
        {
            while (true)
            {
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

            switch (selectedMenu)
            {
                case 1:
                    stateMachine.ChangeScene(stateMachine.MyStatScene);
                    break;
                case 2:
                    stateMachine.ChangeScene(stateMachine.MyInventoryScene);
                    break;
            }

        }


        private void WellcomeToWorld()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
        }
        public void ShowMenu(int idx = 0)
        {
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤 토리");
            Console.WriteLine("3. 상점");
        }

        public bool GetUserInput(out int value)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out value))
                return false;

            if (value <= 0 || value > totalMenuCount)
                return false;

            return true;
        }

        private int selectedMenu;
        public int SelectedMenu { get => selectedMenu; private set => selectedMenu = value; } // 선택된 메뉴 번호

        private int totalMenuCount;
        public int TotalMenuCount { get => totalMenuCount; private set => totalMenuCount = value; } // 메뉴 총 갯수
    }
}
