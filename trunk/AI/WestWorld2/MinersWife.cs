namespace WestWorld2 {
    using WestWorld2.WifeStates;

    public class MinersWife :BaseGameEntity {

        public Location Location { get; set; }
        public bool IsCooking { get; set; }
        public StateMachine<MinersWife> StateMachine { get; private set; } 

        public MinersWife(string name) : base(name) {
            StateMachine = new StateMachine<MinersWife>(this, DoHouseWork.Instance, WifesGlobalState.Instance);
            Location = Location.Shack;
        }

        public override void Update() {
            StateMachine.Update();
            
        }

        public override bool HandleMessage(Telegram telegram) { return StateMachine.HandleMessage(telegram); }
    }
}
