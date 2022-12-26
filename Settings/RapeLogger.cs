using System;
namespace Rape.Settings
{
    public static class Logger
    {
        public static void Init()
        {
            Console.Title = "Rape by Foxy";
            //Console.Clear();
        }

        public static void Log(object message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("] [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("RAPE");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("] ");
            Console.WriteLine(message);
        }

        public static void Log(ConsoleColor color, object message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("] [");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("RAPE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
