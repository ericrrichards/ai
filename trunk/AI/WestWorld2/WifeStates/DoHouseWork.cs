namespace WestWorld2.WifeStates {
    using System;

    public class DoHouseWork : IState<MinersWife> {
        private readonly Random _rand = new Random();
        private static readonly Lazy<DoHouseWork> Lazy = new Lazy<DoHouseWork>(()=>new DoHouseWork());
        private DoHouseWork() { }
        public static DoHouseWork Instance { get { return Lazy.Value; } }


        public void Enter(MinersWife entity) {  }

        public void Execute(MinersWife entity) {
            switch (_rand.Next(3)) {
                case 0:
                    entity.LogAction("Moppin' the floor");
                    break;
                case 1:
                    entity.LogAction("Washin' the dishes");
                    break;
                case 2:
                    entity.LogAction("Makin' the bed");
                    break;
            }
        }

        public void Exit(MinersWife entity) {  }
    }
}