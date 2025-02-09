﻿using SpartaTextRPG._02.Object;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG._01.Scene
{
    internal class InvenManageState : State
    {
        public InvenManageState(StateMachine _stateMachine, Player _player) : base(_stateMachine)
        {
            player = _player;
            currentPageMaxCount = 3;
        }

        public override void Enter(object? Object)
        {
            currentPage = 0;
        }


        public override void Update()
        {
            while (true)
            {
                ShowTitle();
                ShowSelectList<IEquiptable>(player.equipInventory.GetItems(), "아이템 목록");
                ShowMenu<IEquiptable>(player.equipInventory.GetItems()); // 유저가 선택할 수 있는 메뉴를 보여드립니다.

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
                else if (selectedMenu == 0) break;
                else
                {
                    int index = (currentPage * currentPageMaxCount + selectedMenu) - 1; // 현재 가리키는 아이템 인덱스
                    IEquiptable item = player.equipInventory.GetItems()[index];

                    // 현재 장비 장착여부에 따라서 실행
                    if (!item.IsEquipt) 
                        item.TakeItem(player);
                    else 
                        item.TakeOffItem(player);
                }

                Console.Clear();
            }

            switch (selectedMenu) 
            {
                case 0:
                    stateMachine.ChangeScene(stateMachine.MyInventoryScene);
                    break;
            }
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override bool GetUserInput(out int value)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out value))
                return false;

            if (value < 0)
                return false;

            if(value > totalMenuCount)
            {
                if (nextButtonActive && value == 8) return true;
                else if (prevButtonActive && value == 9) return true;
                else return false;
            }

            return true;
        }

        public override void ShowTitle()
        {
            Render.ColorText("인벤토리 - 장착 관리\n", ConsoleColor.Yellow);
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        }

        public override void SetMenuString(object gameObject)
        {
            try
            {
                IEquiptable equipt = (IEquiptable)gameObject;
                string icon = (equipt.IsEquipt == true) ? "[E]" : "";
                Render.ColorText(icon, ConsoleColor.Yellow);

                Item item = equipt.GetItem();
                Console.WriteLine($"{item.Name}  | {item.Information}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private Player player;
    }
}
