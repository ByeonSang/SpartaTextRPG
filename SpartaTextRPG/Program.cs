using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace SpartaTextRPG
{
    public static class Render
    {
        public static void NoticeText(string text,bool isClear = false, ConsoleColor color = ConsoleColor.Gray)
        {
            ColorText(text, color);
            Console.ReadKey(true);
            if (isClear)
                Console.Clear();
        }

        public static void ColorText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.GameStart();
        }
    }
}
