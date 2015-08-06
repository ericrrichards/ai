namespace WestWorld2.WifeStates {
    using System;

    public class WifesGlobalState :IState<MinersWife> {
        private readonly Random _rand = new Random();
        private static readonly Lazy<WifesGlobalState> Lazy = new Lazy<WifesGlobalState>(()=>new WifesGlobalState());
        private WifesGlobalState() { }
        public static WifesGlobalState Instance {get { return Lazy.Value; }}

        public void Enter(MinersWife entity) { }

        public void Execute(MinersWife entity) {
            if (_rand.NextDouble() < 0.1 && !entity.StateMachine.IsInState(VisitBathroom.Instance)) {
                entity.StateMachine.ChangeState(VisitBathroom.Instance);
            }
        }

        public void Exit(MinersWife entity) {  }

        public bool OnMessage(MinersWife owner, Telegram telegram) {
            switch (telegram.MessageType) {
                case MessageType.HiHoneyImHome:
                    owner.LogMessage();
                    owner.LogAction("Hi honey. Let me make you some of mah fine country stew");
                    owner.StateMachine.ChangeState(CookStew.Instance);
                    return true;
            }
            return false;
        }
    }
}
