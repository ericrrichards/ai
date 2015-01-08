using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WestWorldWithWoman {
    class Program {
        static void Main(string[] args) {
            var miner = new Miner("Miner Bob");
            var wife = new MinersWife("Elsa");

            for (int i = 0; i < 20; i++) {
                miner.Update();
                wife.Update();

                Thread.Sleep(800);
            }
            ConsoleUtilities.PressAnyKeyToContinue();
        }
    }
}
