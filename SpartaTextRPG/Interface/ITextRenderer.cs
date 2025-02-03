using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG.Interface
{
    internal interface ITextRenderer
    {
        public void RenderText(string text, ConsoleColor color = ConsoleColor.White);
    }
}
