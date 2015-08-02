namespace WestWorld1.MinerStates {
    using System;

    public class EnterMineAndDigForNugget : IState<Miner> {
        private static readonly Lazy<EnterMineAndDigForNugget> Lazy = new Lazy<EnterMineAndDigForNugget>(()=>new EnterMineAndDigForNugget()); 
        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance {get {return Lazy.Value;}}


        public void Enter(Miner entity) {
            if (entity.Location != Location.Goldmine) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' to the goldmine", entity.Name);
            
                entity.Location = Location.Goldmine;
            }
        }

        public void Execute(Miner entity) {
            entity.GoldCarried++;
            entity.IncreaseFatigue();

            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Pickin' up a nugget", entity.Name);
            if (entity.PocketsFull) {
                entity.ChangeState(VisitBankAndDepositGold.Instance);
            }
            if (entity.Thirsty) {
                entity.ChangeState(QuenchThirst.Instance);
            }
        }

        public void Exit(Miner entity) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold", entity.Name);
        }
    }
}