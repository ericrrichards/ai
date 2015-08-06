namespace WestWorld2.MinerStates {
    using System;

    public class EatStew : IState<Miner> {
        private static readonly Lazy<EatStew> Lazy = new Lazy<EatStew>(()=>new EatStew());
        private EatStew() { }
        public static EatStew Instance { get { return Lazy.Value; } }

        public void Enter(Miner entity) {
            entity.LogAction("Smells reaaal goood Elsa!");
        }

        public void Execute(Miner entity) {
            entity.LogAction("Tastes real good too!");
            entity.StateMachine.RevertToPreviousState();
        }

        public void Exit(Miner entity) {
            entity.LogAction("Thankya li'lle lady. Ah better get back to whatever ah quz doin'");
        }

        public bool OnMessage(Miner owner, Telegram telegram) { return false; }
    }
}