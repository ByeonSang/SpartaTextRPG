using SpartaTextRPG._02.Object;
using SpartaTextRPG._02.Object.Game.Shop;
using SpartaTextRPG.Interface;

namespace SpartaTextRPG._01.Scene
{
    internal class ShopSaleState : State
    {
        public ShopSaleState(StateMachine _stateMachine, Player _player, ShopHandler _shop) : base(_stateMachine)
        {
            player = _player;
            shop = _shop;

            currentPageMaxCount = 3;
        }

        public override void Enter()
        {
            //TODO::
            currentPage = 0;
        }


        public override void Update()
        {
            while (true)
            {
                ShowTitle();
                ShowSelectList<IEquiptable>(shop.SoldList.GetItems(), "판매 목록");
                ShowMenu<IEquiptable>(shop.SoldList.GetItems()); // 유저가 선택할 수 있는 메뉴를 보여드립니다.

                // 유저가 올바르게 입력했는지 여부를 묻습니다.
                #region userInput
                if (!GetUserInput(out selectedMenu)) 
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }
                #endregion

                if (selectedMenu == 8) currentPage++;
                else if (selectedMenu == 9) currentPage--;
                else if (selectedMenu == 0) break;
                else
                {
                    int index = (currentPage * shop.SoldList.Width + selectedMenu) - 1; // 현재 가리키는 아이템 인덱스
                    shop.RemoveInventory(player, shop.SoldList.GetItems()[index]);
                }

                Console.Clear();
            }

            switch (selectedMenu) 
            {
                case 0:
                    stateMachine.ChangeScene(stateMachine.ShopScene);
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
            Render.ColorText("상점 - 아이템 판매\n", ConsoleColor.Yellow);
            Console.WriteLine("필요없는 아이템을 팔수 있는 상점입니다.\n");
        }

        public override void SetMenuString(object gameObject)
        {
            try
            {
                Item item = (Item)gameObject;
                Console.Write($"{item.Name}  | {item.Information} | ");

                Render.ColorText($"{(int)(item.Gold * 0.85f)}G\n", ConsoleColor.Yellow);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private Player player;
        private ShopHandler shop;
    }
}
