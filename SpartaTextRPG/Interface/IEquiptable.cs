using SpartaTextRPG._02.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Interface
{
    internal interface IEquiptable
    {
        public Item GetItem();
        public void TakeItem(Player player);
        public void TakeOffItem(Player player);

        public bool IsEquipt { get; set; }
    }
}
