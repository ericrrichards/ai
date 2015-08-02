namespace WestWorld1.MinerStates {
    using System;

    public class QuenchThirst : IState<Miner> {
        private static readonly Lazy<QuenchThirst> Lazy = new Lazy<QuenchThirst>(()=>new QuenchThirst());
        private QuenchThirst() { }
        public static QuenchThirst Instance {get {return Lazy.Value;}}

        public void Enter(Miner entity) {
            if (entity.Location != Location.Saloon) {
                entity.Location = Location.Saloon;
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Boy, ah sure is thusty! Walking to the saloon", entity.Name);
            }
        }

        public void Execute(Miner entity) {
            if (entity.Thirsty) {
                entity.BuyAndDrinkAWhiskey();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: That's mighty fine sippin liquer", entity.Name);
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("ERROR!\nERROR!\nERROR!");
            }
        }

        public void Exit(Miner entity) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the saloon, feelin' good", entity.Name);
        }
    }
}