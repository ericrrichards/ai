namespace WestWorld2 {
    using System;
    using System.Linq;
    using System.Threading;

    class Program {
        static void Main(string[] args) {
            int numCycles;
            if (args.Length == 0 || !int.TryParse(args.First(), out numCycles)) {
                numCycles = 20;
            }
            var miner = new Miner("Miner Bob") { Color = ConsoleColor.Red };
            var wife = new MinersWife("Elsa") { Color = ConsoleColor.Green };
            for (var i = 0; i < numCycles; i++) {
                miner.Update();
                wife.Update();
                Thread.Sleep(800);
            }
            ConsoleUtilities.PressAnyKeyToContinue();
        }
    }
}
