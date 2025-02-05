using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG.Scene
{
    internal class MainState : State
    {
        public MainState(StateMachine _stateMachine) : base(_stateMachine)
        {
            totalMenuCount = 5;
        }

        public override void Enter(object? Object)
        {
            //TODO::
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override void Update()
        {
            while (true)
            {
                ShowTitle();
                ShowMenu();
                if (!GetUserInput(out selectedMenu))
                {
                    Render.NoticeText("잘못된 입력입니다.\n");
                    continue;
                }

                break;
            }

            switch (selectedMenu)
            {
                case 0:
                    stateMachine.GameInfo.GameExit("게임 종료");
                    break;
                case 1:
                    stateMachine.ChangeScene(stateMachine.MyStatScene);
                    break;
                case 2:
                    stateMachine.ChangeScene(stateMachine.MyInventoryScene);
                    break;
                case 3:
                    stateMachine.ChangeScene(stateMachine.ShopScene);
                    break;
                case 4:
                    stateMachine.ChangeScene(stateMachine.SelctDungeonScene);
                    break;
                case 5:
                    stateMachine.ChangeScene(stateMachine.RestScene);
                    break;
            }

        }

        public override void ShowMenu()
        {
            totalMenuCount = 6; // 나가기 포함
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤 토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전");
            Console.WriteLine("5. 휴식하기\n");
            Console.WriteLine("0. 저장하고 종료");
        }

        public override void ShowTitle()
        {
            Render.ColorText("[스파르타의 마을]\n", ConsoleColor.Yellow);
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
        }
    }
}
