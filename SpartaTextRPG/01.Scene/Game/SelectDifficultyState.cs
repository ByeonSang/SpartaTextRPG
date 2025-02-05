using SpartaTextRPG._03.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._01.Scene.Game
{
    internal class SelectDifficultyState : State
    {
        public SelectDifficultyState(StateMachine _stateMachine, List<Dungeon> _dungeons) : base(_stateMachine)
        {
            dungeons = _dungeons;
            dungeon = null;
        }

        public override void Enter(object? Object)
        {
            try
            {
                int idx = (int)Object;
                if (idx >= 0 && idx < dungeons.Count)
                    dungeon = dungeons[idx];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override void ShowTitle()
        {
            Render.ColorText("[던전 입장]\n", ConsoleColor.Green);
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
        }

        public override void Update()
        {
            while (true)
            {
                ShowTitle();
                ShowMenu();

                if (!GetUserInput(out selectedMenu))
                {
                    Render.NoticeText("잘못 입력하셨습니다.\n", true);
                    continue;
                }
                break;
            }

            switch (selectedMenu) 
            {
                case 0:
                    stateMachine.ChangeScene(stateMachine.SelctDungeonScene);
                    break;
            }
        }

        public override void ShowMenu()
        {
            totalMenuCount = 4;
            Console.WriteLine($"1. 쉬운 던전 | 방어력 {dungeon.RecommendDefence[0]} 이상 권장");
            Console.WriteLine($"2. 일반 던전 | 방어력 {dungeon.RecommendDefence[1]} 이상 권장");
            Console.WriteLine($"3. 어려운 던전 | 방어력 {dungeon.RecommendDefence[2]} 이상 권장\n");
            Console.WriteLine("0. 나가기");
        }

        private List<Dungeon> dungeons;
        private Dungeon? dungeon;
    }
}
