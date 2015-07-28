namespace WestWorld1.MinerStates {
    using System;

    public class EnterMineAndDigForNugget : State {
        private static readonly Lazy<EnterMineAndDigForNugget> Lazy = new Lazy<EnterMineAndDigForNugget>(()=>new EnterMineAndDigForNugget()); 
        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance {get {return Lazy.Value;}}


        public override void Enter(Miner miner) {
            if (miner.Location != Location.Goldmine) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' to the goldmine", miner.Name);
            
                miner.Location = Location.Goldmine;
            }
        }

        public override void Execute(Miner miner) {
            miner.GoldCarried++;
            miner.IncreaseFatigue();

            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Pickin' up a nugget", miner.Name);
            if (miner.PocketsFull) {
                miner.ChangeState(VisitBankAndDepositGold.Instance);
            }
            if (miner.Thirsty) {
                miner.ChangeState(QuenchThirst.Instance);
            }
        }

        public override void Exit(Miner miner) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold", miner.Name);
        }
    }
}