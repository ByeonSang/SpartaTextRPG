using SpartaTextRPG._02.Object;
using SpartaTextRPG.Interface;


namespace SpartaTextRPG._01.Scene
{
    internal class InventoryState : State
    {
        public InventoryState(StateMachine _stateMachine, Player _player) : base(_stateMachine)
        {
            player = _player;
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
                    stateMachine.ChangeScene(stateMachine.MyEquiptScene);
                    break;
            }
        }

        public override void Exit()
        {
            Console.Clear();
        }

        public override void ShowMenu()
        {
            totalMenuCount = 2;
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
        }

        private void ShowInventory()
        {
            

            List<IEquiptable> items = player.equipInventory.GetItems();
            Console.WriteLine("[아이템 목록]\n");

            for(int i = 0; i < items.Count; i++) 
            {
                Console.Write("- ");
                string icon = items[i].IsEquipt? "[E]" : "";
                Render.ColorText(icon, ConsoleColor.Yellow);

                Item item = items[i].GetItem();
                Console.WriteLine($"{item.Name}  | {item.Information}");
            }

            Console.WriteLine(); // 한줄 띄우기
        }

        public override void ShowTitle()
        {
            Render.ColorText("인벤토리\n", ConsoleColor.Yellow);
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        }

        private Player player;
    }
}
