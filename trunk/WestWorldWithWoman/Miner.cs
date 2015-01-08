using System;
using System.Diagnostics;

namespace WestWorldWithWoman {
    public class Miner : BaseGameEntity {
        public const int ComfortLevel = 5;
        private const int MaxNuggets = 3;
        private const int ThirstLevel = 5;
        private const int TirednessThreshold = 5;

        private readonly StateMachine<Miner> _stateMachine;
        public StateMachine<Miner> StateMachine { get { return _stateMachine; } } 

        private int _goldCarried;
        private int _moneyInBank;
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

        public int Wealth { get { return _moneyInBank; } set { _moneyInBank = value; } }

        public void AddToWealth(int val) {
            _moneyInBank += val;
            if (_moneyInBank < 0) _moneyInBank = 0;
        }

        public bool Thirsty { get { return _thirst >= ThirstLevel; } }

        public void BuyAndDrinkAWhiskey() {
            _thirst = 0;
            _moneyInBank -= 2;
        }

        public Miner(string name) : base(name) {
            Location = Location.Shack;
            GoldCarried = 0;
            _moneyInBank = 0;
            _thirst = 0;
            _fatigue = 0;

            _stateMachine = new StateMachine<Miner>(this);
            _stateMachine.CurrentState = GoHomeAndSleepTilRested.Instance;
        }

        

        public override void Update() {
            _thirst++;
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            _stateMachine.Update();
        }
    }
}