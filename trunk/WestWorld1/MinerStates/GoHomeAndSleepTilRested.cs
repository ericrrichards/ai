namespace WestWorld1.MinerStates {
    using System;

    public class GoHomeAndSleepTilRested : IState<Miner> {
        private static readonly Lazy<GoHomeAndSleepTilRested> Lazy = new Lazy<GoHomeAndSleepTilRested>(() => new GoHomeAndSleepTilRested());
        private GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance { get { return Lazy.Value; } }



        public void Enter(Miner entity) {
            if (entity.Location != Location.Shack) {
                entity.LogAction("Walkin' home");
                entity.Location = Location.Shack;
            }
        }

        public void Execute(Miner entity) {
            if (!entity.Fatigued) {
                entity.LogAction("What a God-darn fantastic nap! Time to find more gold");
                entity.ChangeState(EnterMineAndDigForNugget.Instance);
            } else {
                entity.DecreaseFatigue();
                entity.LogAction("ZZZZZ...");
            }
        }

        public void Exit(Miner entity) {
            entity.LogAction("Leaving the house");
        }
    }
}