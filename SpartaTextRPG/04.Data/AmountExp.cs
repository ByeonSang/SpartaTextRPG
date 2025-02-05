using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG._04.Data
{
    public static class AmountExp
    {
        public static int[] amount = new int[10];

        public static void Initialize()
        {
            for (int i = 0; i < amount.Length; i++)
                amount[i] = 2000 * (i + 1);
        }
    }
}
