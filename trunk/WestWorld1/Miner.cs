using System.Diagnostics;

namespace WestWorld1 {
    using System;

    using WestWorld1.MinerStates;

    public class Miner : BaseGameEntity {
        public const int ComfortLevel = 5;
        private const int MaxNuggets = 3;
        private const int ThirstLevel = 5;
        private const int TirednessThreshold = 5;

        private IState<Miner> _currentState;

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
            _currentState = GoHomeAndSleepTilRested.Instance;
        }

        

        public override void Update() {
            _thirst++;
            if (_currentState != null) {
                _currentState.Execute(this);
            }
        }

        public void ChangeState(IState<Miner> newState) {
            Debug.Assert(_currentState != null);
            Debug.Assert(newState != null);
            _currentState.Exit(this);

            _currentState = newState;
            _currentState.Enter(this);
        }
    }
}