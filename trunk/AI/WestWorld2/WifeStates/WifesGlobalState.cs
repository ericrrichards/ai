namespace WestWorld2.WifeStates {
    using System;

    public class WifesGlobalState :IState<MinersWife> {
        private readonly Random _rand = new Random();
        private static readonly Lazy<WifesGlobalState> Lazy = new Lazy<WifesGlobalState>(()=>new WifesGlobalState());
        private WifesGlobalState() { }
        public static WifesGlobalState Instance {get { return Lazy.Value; }}

        public void Enter(MinersWife entity) { }

        public void Execute(MinersWife entity) {
            if (_rand.NextDouble() < 0.1) {
                entity.StateMachine.ChangeState(VisitBathroom.Instance);
            }
        }

        public void Exit(MinersWife entity) {  }
    }
}
