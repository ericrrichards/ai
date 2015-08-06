namespace WestWorld2.MinerStates {
    using System;

    using WestWorld2;

    public class GoHomeAndSleepTilRested : IState<Miner> {
        private static readonly Lazy<GoHomeAndSleepTilRested> Lazy = new Lazy<GoHomeAndSleepTilRested>(() => new GoHomeAndSleepTilRested());
        private GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance { get { return Lazy.Value; } }



        public void Enter(Miner entity) {
            if (entity.Location != Location.Shack) {
                entity.LogAction("Walkin' home");
                entity.Location = Location.Shack;
                MessageDispatcher.Instance.DispatchMessage(0, entity, EntityManager.Instance["Elsa"], MessageType.HiHoneyImHome, null);
            }
        }

        public void Execute(Miner entity) {
            if (!entity.Fatigued) {
                entity.LogAction("What a God-darn fantastic nap! Time to find more gold");
                entity.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            } else {
                entity.DecreaseFatigue();
                entity.LogAction("ZZZZZ...");
            }
        }

        public void Exit(Miner entity) {
        }

        public bool OnMessage(Miner owner, Telegram telegram) {
            switch (telegram.MessageType) {
                case MessageType.StewReady:
                    owner.LogMessage();
                    owner.LogAction("Okay Hun, ahm a comin'!");
                    owner.StateMachine.ChangeState(EatStew.Instance);
                    return true;
            }
            return false;
        }
    }
}