namespace WestWorld1.MinerStates {
    using System;

    public class VisitBankAndDepositGold : State {
        private static readonly Lazy<VisitBankAndDepositGold> Lazy = new Lazy<VisitBankAndDepositGold>(()=>new VisitBankAndDepositGold());
        private VisitBankAndDepositGold() { }
        public static VisitBankAndDepositGold Instance { get { return Lazy.Value; }}



        public override void Enter(Miner miner) {
            if (miner.Location != Location.Bank) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Goin' to the bank. Yes siree", miner.Name);

                miner.Location = Location.Bank;
            }
        }

        public override void Execute(Miner miner) {
            miner.AddToWealth(miner.GoldCarried);
            miner.GoldCarried = 0;
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Depositing gold. Total saving now: {1}", miner.Name, miner.Wealth);

            if (miner.Wealth >= Miner.ComfortLevel) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Woohoo! Rich enough for now. Back home to my li'lle lady", miner.Name);

                miner.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else {
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner miner) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leavin' the bank", miner.Name);
        }
    }
}