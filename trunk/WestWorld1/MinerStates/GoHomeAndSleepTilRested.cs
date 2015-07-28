namespace WestWorld1.MinerStates {
    using System;

    public class GoHomeAndSleepTilRested : State {
        private static readonly Lazy<GoHomeAndSleepTilRested> Lazy = new Lazy<GoHomeAndSleepTilRested>(()=>new GoHomeAndSleepTilRested());
        private GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance {get {return Lazy.Value;}}
        


        public override void Enter(Miner m) {
            if (m.Location != Location.Shack) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' home", m.Name);
                m.Location = Location.Shack;
            }
        }

        public override void Execute(Miner m) {
            if (!m.Fatigued) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: What a God-darn fantastic nap! Time to find more gold", m.Name);
                m.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                m.DecreaseFatigue();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: ZZZZZ...", m.Name);
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the house", m.Name);
        }
    }
}