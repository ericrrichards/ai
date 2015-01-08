using System;

namespace WestWorldWithWoman {
    public static class ConsoleUtilities {
        public static void SetTextColor(ConsoleColor foreColor, ConsoleColor backColor = ConsoleColor.Black) {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
        }

        public static void PressAnyKeyToContinue() {
            SetTextColor(ConsoleColor.White);
            Console.WriteLine("\n\nPress any key to continue...");

            Console.ReadKey(true);
        }
    }
}