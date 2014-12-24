using System;
using System.Threading;

namespace WestWorld1 {
    class Program {
        static void Main(string[] args) {
            var miner = new Miner("Miner Bob");
            for (int i = 0; i < 20; i++) {
                miner.Update();
                Thread.Sleep(800);
            }
            ConsoleUtilities.PressAnyKeyToContinue();
        }
    }

    public class EnterMineAndDigForNugget : State {

        private static readonly EnterMineAndDigForNugget _instance = new EnterMineAndDigForNugget();
        static EnterMineAndDigForNugget() { }
        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance {get {return _instance;}}


        public override void Enter(Miner m) {
            if (m.Location != Location.Goldmine) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' to the goldmine", m.Name);
            
                m.Location = Location.Goldmine;
            }
        }

        public override void Execute(Miner m) {
            m.GoldCarried++;
            m.IncreaseFatigue();

            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Pickin' up a nugget", m.Name);
            if (m.PocketsFull) {
                m.ChangeState(VisitBankAndDepositGold.Instance);
            }
            if (m.Thirsty) {
                m.ChangeState(QuenchThirst.Instance);
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold", m.Name);
        }
    }

    public class VisitBankAndDepositGold : State {
        private static readonly VisitBankAndDepositGold _instance = new VisitBankAndDepositGold();
        static VisitBankAndDepositGold() { }
        private VisitBankAndDepositGold() { }
        public static VisitBankAndDepositGold Instance { get { return _instance; }}



        public override void Enter(Miner m) {
            if (m.Location != Location.Bank) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Goin' to the bank. Yes siree", m.Name);

                m.Location = Location.Bank;
            }
        }

        public override void Execute(Miner m) {
            m.AddToWealth(m.GoldCarried);
            m.GoldCarried = 0;
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Depositing gold. Total saving now: {1}", m.Name, m.Wealth);

            if (m.Wealth >= Miner.ComfortLevel) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Woohoo! Rich enough for now. Back home to my li'lle lady", m.Name);

                m.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else {
                m.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leavin' the bank", m.Name);
        }
    }

    public class GoHomeAndSleepTilRested : State {

        private static readonly GoHomeAndSleepTilRested _instance = new GoHomeAndSleepTilRested();
        static GoHomeAndSleepTilRested() { }
        private GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance {get {return _instance;}}
        


        public override void Enter(Miner m) {
            if (m.Location != Location.Shack) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Walkin' home", m.Name);
                m.Location = Location.Shack;
            }
        }

        public override void Execute(Miner m) {
            if (!m.Fatigued) {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: What a God-darn fantastic nap! Time to find more gold", m.Name);
                m.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                m.DecreaseFatigue();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: ZZZZZ...", m.Name);
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the house", m.Name);
        }
    }

    public class QuenchThirst : State {
        private static readonly QuenchThirst _instance = new QuenchThirst();
        static QuenchThirst() { }
        private QuenchThirst() { }
        public static QuenchThirst Instance {get {return _instance;}}

        public override void Enter(Miner m) {
            if (m.Location != Location.Saloon) {
                m.Location = Location.Saloon;
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: Boy, ah sure is thusty! Walking to the saloon", m.Name);
            }
        }

        public override void Execute(Miner m) {
            if (m.Thirsty) {
                m.BuyAndDrinkAWhiskey();
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("{0}: That's mighty fine sippin liquer", m.Name);
                m.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else {
                ConsoleUtilities.SetTextColor(ConsoleColor.Red);
                Console.WriteLine("ERROR!\nERROR!\nERROR!");
            }
        }

        public override void Exit(Miner m) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Red);
            Console.WriteLine("{0}: Leaving the saloon, feelin' good", m.Name);
        }
    }
}
