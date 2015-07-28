namespace WestWorld1.MinerStates {
    using System;

    public class QuenchThirst : State {
        private static readonly Lazy<QuenchThirst> Lazy = new Lazy<QuenchThirst>(()=>new QuenchThirst());
        private QuenchThirst() { }
        public static QuenchThirst Instance {get {return Lazy.Value;}}

        public override void Enter(Miner miner) {
            if (miner.Location != Location.Saloon) {
                miner.Location = Location.Saloon;
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Boy, ah sure is thusty! Walking to the saloon", miner.Name);
            }
        }

        public override void Execute(Miner miner) {
            if (miner.Thirsty) {
                miner.BuyAndDrinkAWhiskey();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: That's mighty fine sippin liquer", miner.Name);
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("ERROR!\nERROR!\nERROR!");
            }
        }

        public override void Exit(Miner miner) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the saloon, feelin' good", miner.Name);
        }
    }
}