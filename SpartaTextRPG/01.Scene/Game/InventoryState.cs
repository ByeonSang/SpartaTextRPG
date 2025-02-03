using SpartaTextRPG._02.Object;
using SpartaTextRPG.Interface;


namespace SpartaTextRPG._01.Scene
{
    internal class InventoryState : State, IMenuList, ITextRenderer
    {
        public InventoryState(StateMachine _stateMachine, Player _player) : base(_stateMachine)
        {
            player = _player;
            totalMenuCount = 2;
        }

        public override void Enter()
        {
            RenderText("인벤토리\n", ConsoleColor.Yellow);
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        }


        public override void Update()
        {
            while (true)
            {
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

        public void ShowMenu(int idx = 0)
        {
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
                RenderText(icon, ConsoleColor.Yellow);

                Item item = items[i].GetItem();
                Console.WriteLine($"{item.Name}  | {item.Information}");
            }

            Console.WriteLine(); // 한줄 띄우기
        }

        public bool GetUserInput(out int value)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out value))
                return false;

            if (value < 0 || value > totalMenuCount - 1)
                return false;

            return true;
        }

        public void RenderText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private Player player;

        private int selectedMenu;
        public int SelectedMenu { get => selectedMenu; private set => selectedMenu = value; } // 선택된 메뉴 번호

        private int totalMenuCount;
        public int TotalMenuCount { get => totalMenuCount; private set => totalMenuCount = value; } // 메뉴 총 갯수
    }
}
