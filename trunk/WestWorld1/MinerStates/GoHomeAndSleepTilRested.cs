namespace WestWorld1.MinerStates {
    using System;

    public class GoHomeAndSleepTilRested : IState<Miner>{
        private static readonly Lazy<GoHomeAndSleepTilRested> Lazy = new Lazy<GoHomeAndSleepTilRested>(()=>new GoHomeAndSleepTilRested());
        private GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance {get {return Lazy.Value;}}
        


        public void Enter(Miner entity) {
            if (entity.Location != Location.Shack) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' home", entity.Name);
                entity.Location = Location.Shack;
            }
        }

        public void Execute(Miner entity) {
            if (!entity.Fatigued) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: What a God-darn fantastic nap! Time to find more gold", entity.Name);
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                entity.DecreaseFatigue();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: ZZZZZ...", entity.Name);
            }
        }

        public void Exit(Miner entity) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the house", entity.Name);
        }
    }
}