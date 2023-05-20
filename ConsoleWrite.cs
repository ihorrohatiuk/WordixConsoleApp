using System;

namespace WordixConsoleApp
{
    internal class ConsoleWrite
    {
        //RED
        public static void LineRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void Red(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str);
            Console.ResetColor();
        }
        
        //GREEN
        public static void LineGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void Green(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(str);
            Console.ResetColor();
        }

        //WHITE
        public static void LineWhite(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void White(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(str);
            Console.ResetColor();
        }

        //CYAN
        public static void LineCyan(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void Cyan(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
