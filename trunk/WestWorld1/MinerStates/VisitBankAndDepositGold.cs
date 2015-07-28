namespace WestWorld1.MinerStates {
    using System;

    public class VisitBankAndDepositGold : State {
        private static readonly Lazy<VisitBankAndDepositGold> Lazy = new Lazy<VisitBankAndDepositGold>(()=>new VisitBankAndDepositGold());
        private VisitBankAndDepositGold() { }
        public static VisitBankAndDepositGold Instance { get { return Lazy.Value; }}



        public override void Enter(Miner m) {
            if (m.Location != Location.Bank) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Goin' to the bank. Yes siree", m.Name);

                m.Location = Location.Bank;
            }
        }

        public override void Execute(Miner m) {
            m.AddToWealth(m.GoldCarried);
            m.GoldCarried = 0;
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Depositing gold. Total saving now: {1}", m.Name, m.Wealth);

            if (m.Wealth >= Miner.ComfortLevel) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Woohoo! Rich enough for now. Back home to my li'lle lady", m.Name);

                m.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else {
                m.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leavin' the bank", m.Name);
        }
    }
}