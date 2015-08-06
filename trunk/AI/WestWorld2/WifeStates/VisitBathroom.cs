namespace WestWorld2.WifeStates {
    using System;

    public class VisitBathroom : IState<MinersWife> {
        private static readonly Lazy<VisitBathroom> Lazy = new Lazy<VisitBathroom>(()=>new VisitBathroom());
        private VisitBathroom() { }
        public static VisitBathroom Instance { get { return Lazy.Value; } }


        public void Enter(MinersWife entity) {
            entity.LogAction("Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public void Execute(MinersWife entity) {
            entity.LogAction("Ahhhhh! Sweet relief!");
            entity.StateMachine.RevertToPreviousState();
        }

        public void Exit(MinersWife entity) {
            entity.LogAction("Leavin' the jon");
        }

        public bool OnMessage(MinersWife owner, Telegram telegram) { return false; }
    }
}