namespace WestWorld2.WifeStates {
    using System;

    public class CookStew : IState<MinersWife> {
        private static readonly Lazy<CookStew> Lazy = new Lazy<CookStew>(()=>new CookStew());
        private CookStew() { }
        public static CookStew Instance { get { return Lazy.Value; } }

        public void Enter(MinersWife entity) {
            if (!entity.IsCooking) {
                entity.LogAction("Putting the stew in the oven");

                MessageDispatcher.Instance.DispatchMessage(1.5, entity, entity, MessageType.StewReady, null);
                entity.IsCooking = true;
            }
        }

        public void Execute(MinersWife entity) { entity.LogAction("Fussin' over food"); }

        public void Exit(MinersWife entity) { entity.LogAction("Puttin' the stew on the table"); }

        public bool OnMessage(MinersWife owner, Telegram telegram) {
            switch (telegram.MessageType) {
                case MessageType.StewReady:
                    owner.LogMessage();
                    owner.LogAction("Stew's ready! Let's eat!");
                    MessageDispatcher.Instance.DispatchMessage(0, owner, EntityManager.Instance["Miner Bob"], MessageType.StewReady, null);
                    owner.IsCooking = false;
                    owner.StateMachine.RevertToPreviousState();
                    return true;
            }
            return false;
        }
    }
}