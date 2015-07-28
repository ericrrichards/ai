namespace WestWorld1.MinerStates {
    using System;

    public class GoHomeAndSleepTilRested : State {
        private static readonly Lazy<GoHomeAndSleepTilRested> Lazy = new Lazy<GoHomeAndSleepTilRested>(()=>new GoHomeAndSleepTilRested());
        private GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance {get {return Lazy.Value;}}
        


        public override void Enter(Miner miner) {
            if (miner.Location != Location.Shack) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' home", miner.Name);
                miner.Location = Location.Shack;
            }
        }

        public override void Execute(Miner miner) {
            if (!miner.Fatigued) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: What a God-darn fantastic nap! Time to find more gold", miner.Name);
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                miner.DecreaseFatigue();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: ZZZZZ...", miner.Name);
            }
        }

        public override void Exit(Miner miner) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the house", miner.Name);
        }
    }
}