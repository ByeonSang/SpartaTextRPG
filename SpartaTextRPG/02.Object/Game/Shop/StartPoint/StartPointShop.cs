using SpartaTextRPG.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._02.Object.Game.Shop
{
    internal class StartPointShop : ShopHandler
    {
        public StartPointShop(int x, int y) : base(x, y)
        {
            CreateItems();
        }

        public override void CreateItems()
        {
            // 상점 품목
            SaleList.AddItem(new IronArmor());
            SaleList.AddItem(new OldSword());
            SaleList.AddItem(new SpartaSpear());

            List<IEquiptable> items = SaleList.GetItems();
            for (int i = 0; i < items.Count; i++) // 초기화 작업
                isSales.Add(items[i], false);
            
        }
    }
}
