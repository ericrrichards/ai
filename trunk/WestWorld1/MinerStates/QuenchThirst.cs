namespace WestWorld1.MinerStates {
    using System;

    public class QuenchThirst : State {
        private static readonly Lazy<QuenchThirst> Lazy = new Lazy<QuenchThirst>(()=>new QuenchThirst());
        private QuenchThirst() { }
        public static QuenchThirst Instance {get {return Lazy.Value;}}

        public override void Enter(Miner m) {
            if (m.Location != Location.Saloon) {
                m.Location = Location.Saloon;
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Boy, ah sure is thusty! Walking to the saloon", m.Name);
            }
        }

        public override void Execute(Miner m) {
            if (m.Thirsty) {
                m.BuyAndDrinkAWhiskey();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: That's mighty fine sippin liquer", m.Name);
                m.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("ERROR!\nERROR!\nERROR!");
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the saloon, feelin' good", m.Name);
        }
    }
}