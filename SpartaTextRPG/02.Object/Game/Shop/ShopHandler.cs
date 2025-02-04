using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object
{
    internal abstract class ShopHandler : ITextRenderer
    {
        public ShopHandler(int x, int y)
        {
            saleList = new Inventory<IEquiptable>(x, y);
            isSales = new bool[x * y];
        }

        public abstract void CreateItems();

        public void AddInventory(Player target, IEquiptable equip, int equipIndex)
        {
            int itemGold = equip.GetItem().Gold;

            if (target.Gold < itemGold)
            {
                RenderText("Gold 가 부족합니다.", ConsoleColor.Red);
                Console.ReadKey(true);
                return;
            }

            if (isSales[equipIndex])
            {
                RenderText("이미 구매한 아이템입니다.", ConsoleColor.Blue);
                Console.ReadKey(true);
                return;
            }


            RenderText("구매를 완료했습니다.", ConsoleColor.Blue);
            isSales[equipIndex] = true;
            target.equipInventory.AddItem(equip);
            target.Gold = target.Gold - itemGold;

            Console.ReadKey(true); // 대기 상태
        }

        public void RenderText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private Inventory<IEquiptable> saleList;
        public Inventory<IEquiptable> SaleList { get => saleList; protected set => saleList = value; }

        private bool[] isSales;
        public bool[] IsSales { get => isSales; protected set => isSales = value; }
    }
}
