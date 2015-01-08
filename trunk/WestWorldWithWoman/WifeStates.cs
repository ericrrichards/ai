using System;

namespace WestWorldWithWoman {
    public class WifesGlobalState : State<MinersWife> {
        private static readonly WifesGlobalState _instance = new WifesGlobalState();
        public static WifesGlobalState Instance { get { return _instance; } }
        static WifesGlobalState() { }
        private WifesGlobalState() { }

        private Random _random = new Random();

        public override void Enter(MinersWife entity) {
        }

        public override void Execute(MinersWife entity) {
            if (_random.NextDouble() < 0.1) {
                entity.StateMachine.ChangeState(VisitBathroom.Instance);
            }
        }

        public override void Exit(MinersWife entity) {
        }
    }

    public class DoHouseWork : State<MinersWife> {
        private static readonly DoHouseWork _instance = new DoHouseWork();
        public static DoHouseWork Instance { get { return _instance; } }
        static DoHouseWork() { }
        private DoHouseWork() { }

        private Random _random = new Random();

        public override void Enter(MinersWife entity) {
        }

        public override void Execute(MinersWife entity) {
            switch (_random.Next(0,2)) {
                case 0:
                    Console.WriteLine("{0}: Moppin' the floor", entity.Name);
                    break;
                case 1:
                    Console.WriteLine("{0}: Washin' the dishes", entity.Name);
                    break;
                case 2:
                    Console.WriteLine("{0}: Makin' the bed", entity.Name);
                    break;
            }
        }

        public override void Exit(MinersWife entity) {
        }
    }

    public class VisitBathroom : State<MinersWife> {
        private static readonly VisitBathroom _instance = new VisitBathroom();
        public static VisitBathroom Instance { get { return _instance; } }
        static VisitBathroom() { }
        private VisitBathroom() { }

        public override void Enter(MinersWife entity) {
            Console.WriteLine("{0}: Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public override void Execute(MinersWife entity) {
            Console.WriteLine("{0}: Ahhhhh! Sweet relief!");
            entity.StateMachine.RevertToPreviousState();
        }

        public override void Exit(MinersWife entity) {
            Console.WriteLine("{0}: Leavin' the Jon", entity.Name);
        }
    }
}