using SpartaTextRPG._02.Object;
using SpartaTextRPG._03.Dungeon;
using SpartaTextRPG.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._01.Scene.Game
{
    internal class SelectDungeonState : State
    {
        public SelectDungeonState(StateMachine _stateMachine,Player _player, List<Dungeon> _dungeons) : base(_stateMachine)
        {
            player = _player;
            dungeons = _dungeons;

            curPageMaxCount = 3; // 현재 페이지에서 최대로 볼 수 있는 메뉴
        }

        public override void Enter()
        {
            //TODO::
            currentPage = 0;
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override void ShowMenu(int idx = 0)
        {
            nextButtonActive = false;
            prevButtonActive = false;

            int totalDungeon = dungeons.Count;

            if (curPageMaxCount * (currentPage + 1) < totalDungeon) // 가로넓이 만큼 리스트가 출력하는데 그 이후에도 아이템을 가지고 있으면 다음 버튼 생성
            {
                Console.WriteLine("8. 다음");
                nextButtonActive = true;
            }

            if (idx > 0) // 현재 페이지가 0이 아니면 뒤로가기 버튼 생성
            {
                Console.WriteLine("9. 뒤로");
                prevButtonActive = true;
            }

            Console.WriteLine("0. 나가기");
        }

        public override void ShowTitle()
        {
            Render.ColorText("[던전입구]\n", ConsoleColor.Green);
            Console.WriteLine("던전을 선택할 수 있는 메뉴창입니다.\n");
        }

        public override void Update()
        {
            while (true) 
            {
                ShowTitle();
                ShowDungeons(); // 현재 내가 가지고 있는 아이템을 보여드립니다.
                ShowMenu(currentPage); // 유저가 선택할 수 있는 메뉴를 보여드립니다.

                // 유저가 올바르게 입력했는지 여부를 묻습니다.
                #region userInput
                if (!GetUserInput(out selectedMenu))
                {
                    Render.NoticeText("잘못된 입력입니다.\n", true);
                    continue;
                }
                #endregion

                if (selectedMenu == 8) currentPage++;
                else if (selectedMenu == 9) currentPage--;
                else if (selectedMenu == 0)
                {
                    stateMachine.ChangeScene(stateMachine.MainScene);
                    break;
                }
                else
                {
                    int index = (currentPage * curPageMaxCount + selectedMenu) - 1; // 현재 가리키는 아이템 인덱스
                    Dungeon dungeon = dungeons[index];
                    //stateMachine.ChangeScene(stateMachine.DungeonDifiicaly);
                    break;
                }

                Console.Clear();
            }
        }

        private void ShowDungeons()
        {
            Console.WriteLine("[던전 목록]\n");

            int startIndex = curPageMaxCount * currentPage;
            int endIndex = startIndex + curPageMaxCount;

            int curCount = 0;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (i >= dungeons.Count)
                    break;

                Console.Write($"- {i % curPageMaxCount + 1} ");

                Dungeon dungeon = dungeons[i];
                Console.WriteLine($"{dungeon.Name}  | {dungeon.Level}");
                curCount++;
            }

            totalMenuCount = curCount;
            Console.WriteLine(); // 한줄 띄우기
        }

        public override bool GetUserInput(out int value)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out value))
                return false;

            if (value < 0)
                return false;

            if (value > totalMenuCount)
            {
                if (nextButtonActive && value == 8) return true;
                else if (prevButtonActive && value == 9) return true;
                else return false;
            }

            return true;
        }

        private Player player;
        private List<Dungeon> dungeons;

        private int currentPage;
        private int curPageMaxCount;

        private bool nextButtonActive;
        private bool prevButtonActive;
    }
}
