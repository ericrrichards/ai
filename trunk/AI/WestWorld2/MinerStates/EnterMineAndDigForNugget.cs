namespace WestWorld2.MinerStates {
    using System;

    using WestWorld2;

    public class EnterMineAndDigForNugget : IState<Miner> {
        private static readonly Lazy<EnterMineAndDigForNugget> Lazy = new Lazy<EnterMineAndDigForNugget>(() => new EnterMineAndDigForNugget());
        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance { get { return Lazy.Value; } }


        public void Enter(Miner entity) {
            if (entity.Location != Location.Goldmine) {
                entity.LogAction("Walkin' to the goldmine");

                entity.Location = Location.Goldmine;
            }
        }

        public void Execute(Miner entity) {
            entity.GoldCarried++;
            entity.IncreaseFatigue();

            entity.LogAction("Pickin' up a nugget");
            if (entity.PocketsFull) {
                entity.StateMachine.ChangeState(VisitBankAndDepositGold.Instance);
            }
            if (entity.Thirsty) {
                entity.StateMachine.ChangeState(QuenchThirst.Instance);
            }
        }

        public void Exit(Miner entity) {
            entity.LogAction("Ah'm leavin' the goldmine with mah pockets full o' sweet gold");
        }

        public bool OnMessage(Miner owner, Telegram telegram) { return false; }
    }
}