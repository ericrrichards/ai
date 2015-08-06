namespace WestWorld2 {
    using System.Diagnostics;

    using WestWorld2.MinerStates;

    public class Miner : BaseGameEntity {
        public const int ComfortLevel = 5;
        private const int MaxNuggets = 3;
        private const int ThirstLevel = 5;
        private const int TirednessThreshold = 5;

        public StateMachine<Miner> StateMachine { get; private set; }

        private int _goldCarried;
        private int _thirst;
        private int _fatigue;

        public Location Location { get; set; }

        public int GoldCarried {
            get { return _goldCarried; }
            set {
                _goldCarried = value;
                if (_goldCarried < 0) _goldCarried = 0;
            }
        }
        public bool PocketsFull { get { return _goldCarried >= MaxNuggets; } }

        public bool Fatigued{ get { return _fatigue > TirednessThreshold; }}
        public void DecreaseFatigue() {
            _fatigue--;
        }

        public void IncreaseFatigue() {
            _fatigue++;
        }

        public int Wealth { get; set; }

        public void AddToWealth(int val) {
            Wealth += val;
        }

        public bool Thirsty { get { return _thirst >= ThirstLevel; } }

        public void BuyAndDrinkAWhiskey() {
            _thirst = 0;
            Wealth -= 2;
        }

        public Miner(string name)
            : base(name) {
            Location = Location.Shack;
            GoldCarried = 0;
            Wealth = 0;
            _thirst = 0;
            _fatigue = 0;
            StateMachine = new StateMachine<Miner>(this, GoHomeAndSleepTilRested.Instance);
        }

        

        public override void Update() {
            _thirst++;
            StateMachine.Update();
        }
    }
}