using System.Threading;

namespace WestWorld1 {
    using System;
    using System.Linq;

    class Program {
        static void Main(string[] args) {
            int numCycles;
            if (args.Length == 0 || !int.TryParse(args.First(), out numCycles)) {
                numCycles = 20;
            }
            var miner = new Miner("Miner Bob") { Color = ConsoleColor.Red };
            for (var i = 0; i < numCycles; i++) {
                miner.Update();
                Thread.Sleep(800);
            }
            ConsoleUtilities.PressAnyKeyToContinue();
        }
    }
}
