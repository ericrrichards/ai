namespace WestWorld1.MinerStates {
    using System;

    public class EnterMineAndDigForNugget : State {
        private static readonly Lazy<EnterMineAndDigForNugget> Lazy = new Lazy<EnterMineAndDigForNugget>(()=>new EnterMineAndDigForNugget()); 
        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance {get {return Lazy.Value;}}


        public override void Enter(Miner m) {
            if (m.Location != Location.Goldmine) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' to the goldmine", m.Name);
            
                m.Location = Location.Goldmine;
            }
        }

        public override void Execute(Miner m) {
            m.GoldCarried++;
            m.IncreaseFatigue();

            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Pickin' up a nugget", m.Name);
            if (m.PocketsFull) {
                m.ChangeState(VisitBankAndDepositGold.Instance);
            }
            if (m.Thirsty) {
                m.ChangeState(QuenchThirst.Instance);
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold", m.Name);
        }
    }
}