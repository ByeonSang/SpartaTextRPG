using SpartaTextRPG.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._01.Scene.Game
{
    internal class RestState : State
    {

        public RestState(StateMachine _stateMachine, Player _player) : base(_stateMachine)
        {
            player = _player;
            totalMenuCount = 1;
        }

        public override void Enter()
        {
            // TODO::
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

                if(!GetUserInput(out selectedMenu))
                {
                    Render.NoticeText("잘못된 입력입니다.\n", true);
                    continue;
                }

                break;
            }

            // 휴식을 선택시
            if (selectedMenu == 1)
            {
                if(player.Health >= player.MaxHealth)
                {
                    Render.NoticeText("이미 체력이 만땅입니다.\n", true, ConsoleColor.Red);
                    return;
                }    

                if (player.Gold < restGold)
                {
                    Render.NoticeText("Gold가 부족합니다.\n", true, ConsoleColor.Red);
                    return;
                }
                player.Gold -= restGold;
                player.Health += healthUp;
                Render.NoticeText("휴식을 완료했습니다.\n", true, ConsoleColor.Blue);
            }
            else
                stateMachine.ChangeScene(stateMachine.MainScene);
        }

        public override void ShowMenu()
        {
            totalMenuCount = 2;
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
        }

        public override void ShowTitle()
        {
            Render.ColorText("휴식하기\n", ConsoleColor.Yellow);
            Render.ColorText($"{restGold} G", ConsoleColor.Yellow);
            Console.Write($" 를 내면 체력 +{healthUp} 만큼 회복할 수 있습니다. (보유 골드 : ");
            Render.ColorText($"{player.Gold} G", ConsoleColor.Yellow);
            Console.WriteLine(")\n");
        }

        private Player player;
        const int restGold = 500;
        const int healthUp = 100;
    }
}
