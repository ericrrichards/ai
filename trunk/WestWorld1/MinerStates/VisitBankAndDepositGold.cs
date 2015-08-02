namespace WestWorld1.MinerStates {
    using System;

    public class VisitBankAndDepositGold : IState<Miner> {
        private static readonly Lazy<VisitBankAndDepositGold> Lazy = new Lazy<VisitBankAndDepositGold>(()=>new VisitBankAndDepositGold());
        private VisitBankAndDepositGold() { }
        public static VisitBankAndDepositGold Instance { get { return Lazy.Value; }}



        public void Enter(Miner entity) {
            if (entity.Location != Location.Bank) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Goin' to the bank. Yes siree", entity.Name);

                entity.Location = Location.Bank;
            }
        }

        public void Execute(Miner entity) {
            entity.AddToWealth(entity.GoldCarried);
            entity.GoldCarried = 0;
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Depositing gold. Total saving now: {1}", entity.Name, entity.Wealth);

            if (entity.Wealth >= Miner.ComfortLevel) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Woohoo! Rich enough for now. Back home to my li'lle lady", entity.Name);

                entity.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else {
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public void Exit(Miner entity) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leavin' the bank", entity.Name);
        }
    }
}