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
            SaleList.AddItem(new IronArmor());
            SaleList.AddItem(new OldSword());
            SaleList.AddItem(new SpartaSpear());
        }
    }
}
