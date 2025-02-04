using SpartaTextRPG._02.Object;
using SpartaTextRPG._02.Object.Game;
using SpartaTextRPG._02.Object.Game.Shop;
using SpartaTextRPG.Interface;


namespace SpartaTextRPG._01.Scene
{
    internal class ShopState : State
    {
        public ShopState(StateMachine _stateMachine, Player _player, ShopHandler _shop) : base(_stateMachine)
        {
            player = _player;
            shop = _shop;
        }

        public override void Enter()
        {
            // TODO::
        }


        public override void Update()
        {
            while (true)
            {
                ShowTitle();
                ShowInventory();
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
                case 0:
                    stateMachine.ChangeScene(stateMachine.MainScene);
                    break;
                case 1:
                    stateMachine.ChangeScene(stateMachine.ShopBuyState);
                    break;
                case 2:
                    stateMachine.ChangeScene(stateMachine.ShopSaleState);
                    break;
            }
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override void ShowMenu(int idx = 0)
        {
            totalMenuCount = 3;
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
        }

        private void ShowInventory()
        {
            Console.WriteLine("[보유 골드]");
            Render.ColorText($"{player.Gold} G\n\n", ConsoleColor.Yellow);

            List<IEquiptable> items = shop.SaleList.GetItems();
            Console.WriteLine("[아이템 목록]\n");

            for(int i = 0; i < items.Count; i++) 
            {
                Item item = items[i].GetItem();
                
                Console.Write($"{item.Name}  | {item.Information} | ");

                string str = (shop.IsSale(items[i]) == false) ? $"{item.Gold} G\n" : "구매완료\n";
                Render.ColorText(str, ConsoleColor.Yellow);
            }

            Console.WriteLine(); // 한줄 띄우기
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
            Render.ColorText("상점\n", ConsoleColor.Yellow);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
        }

        private Player player;
        private ShopHandler shop;
    }
}
