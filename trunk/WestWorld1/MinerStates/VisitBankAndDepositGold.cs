namespace WestWorld1.MinerStates {
    using System;

    public class VisitBankAndDepositGold : IState<Miner> {
        private static readonly Lazy<VisitBankAndDepositGold> Lazy = new Lazy<VisitBankAndDepositGold>(() => new VisitBankAndDepositGold());
        private VisitBankAndDepositGold() { }
        public static VisitBankAndDepositGold Instance { get { return Lazy.Value; } }



        public void Enter(Miner entity) {
            if (entity.Location != Location.Bank) {
                entity.LogAction("Goin' to the bank. Yes siree");

                entity.Location = Location.Bank;
            }
        }

        public void Execute(Miner entity) {
            entity.AddToWealth(entity.GoldCarried);
            entity.GoldCarried = 0;
            entity.LogAction(string.Format("Depositing gold. Total saving now: {0}", entity.Wealth));


            if (entity.Wealth >= Miner.ComfortLevel) {
                entity.LogAction("Woohoo! Rich enough for now. Back home to my li'lle lady");

                entity.ChangeState(GoHomeAndSleepTilRested.Instance);
            } else {
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public void Exit(Miner entity) {
            entity.LogAction("Leavin' the bank");
        }
    }
}