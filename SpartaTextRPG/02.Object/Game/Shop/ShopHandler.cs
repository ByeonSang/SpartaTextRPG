using SpartaTextRPG.Interface;

namespace SpartaTextRPG._02.Object
{
    internal abstract class ShopHandler : ITextRenderer
    {
        public ShopHandler(int x, int y)
        {
            saleList = new Inventory<IEquiptable>(x, y);
            soldList = new Inventory<IEquiptable>(x, y);

            isSales  = new Dictionary<IEquiptable, bool>();
        }

        public abstract void CreateItems();

        public void AddInventory(Player target, IEquiptable equip)
        {
            int itemGold = equip.GetItem().Gold;
            bool isSale = false;

            if (target.Gold < itemGold)
            {
                RenderText("Gold 가 부족합니다.", ConsoleColor.Red);
                Console.ReadKey(true);
                return;
            }

            if (isSales.TryGetValue(equip, out isSale) && isSale)
            {
                RenderText("이미 구매한 아이템입니다.", ConsoleColor.Blue);
                Console.ReadKey(true);
                return;
            }


            RenderText("구매를 완료했습니다.", ConsoleColor.Blue);

            if (isSales.ContainsKey(equip))
                isSales[equip] = true;

            target.equipInventory.AddItem(equip);
            soldList.AddItem(equip);

            target.Gold -= itemGold;

            Console.ReadKey(true); // 대기 상태
        }

        // 현재 RemoveInventory에서 받아오는 값이 판매 메뉴 index = 0값임
        // isSales는 판매되고 있는 아이템 전체 갯수에 따라서 들어갔기때문에
        // 이상한 인덱스에 접근해서 false해주는 상황 이걸좀 해결해야됨

        public void RemoveInventory(Player target, IEquiptable equip)
        {
            int itemGold = (int)(equip.GetItem().Gold * 0.85f);

            if (equip.IsEquipt)
                equip.TakeOffItem(target);

            RenderText("판매를 완료했습니다.", ConsoleColor.Blue);

            if(isSales.ContainsKey(equip))
                isSales[equip] = false;

            target.equipInventory.RemoveItem(equip);
            soldList.RemoveItem(equip);

            target.Gold += itemGold;
        }

        public bool IsSale(IEquiptable equipt)
        {
            bool value;

            if (!isSales.TryGetValue(equipt, out value))
                return false;

            return value;
        }


        public void RenderText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private Inventory<IEquiptable> saleList;
        public Inventory<IEquiptable> SaleList { get => saleList; protected set => saleList = value; }

        private Inventory<IEquiptable> soldList;
        public Inventory<IEquiptable> SoldList { get => soldList; protected set => soldList = value; }

        protected Dictionary<IEquiptable, bool> isSales;
        /*private bool[] isSales;
        public bool[] IsSales { get => isSales; protected set => isSales = value; }*/
    }
}
