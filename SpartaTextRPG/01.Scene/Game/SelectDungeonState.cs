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
        }

        public override void Enter()
        {
            //TODO::
            currentPage = 0;
            currentPageMaxCount = 3;
        }

        public override void Exit()
        {
            Console.Clear();
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
                ShowSelectList<Dungeon>(dungeons, "던전 목록");
                ShowMenu<Dungeon>(dungeons); // 유저가 선택할 수 있는 메뉴를 보여드립니다.

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
                    int index = (currentPage * currentPageMaxCount + selectedMenu) - 1; // 현재 가리키는 아이템 인덱스
                    // index를 ChangeScene메서드 호출할때 넣어주기 << 해결해야됨
                    //stateMachine.ChangeScene(stateMachine.DungeonDifiicaly);
                    break;
                }

                Console.Clear();
            }
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

        public override void SetMenuString(object gameObject)
        {
            try
            {
                Dungeon dungeon = (Dungeon)gameObject;
                Console.WriteLine($"{dungeon.Name}  | Level : {dungeon.Level}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private Player player;
        private List<Dungeon> dungeons;
    }
}
