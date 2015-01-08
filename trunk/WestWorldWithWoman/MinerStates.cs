using System;

namespace WestWorldWithWoman {
    public class QuenchThirst : State<Miner> {
        private static readonly QuenchThirst _instance = new QuenchThirst();
        static QuenchThirst() { }
        private QuenchThirst() { }
        public static QuenchThirst Instance { get { return _instance; } }

        public override void Enter(Miner m) {
            if (m.Location != Location.Saloon) {
                m.Location = Location.Saloon;
                Console.WriteLine("{0}: Boy, ah sure is thusty! Walking to the saloon", m.Name);
            }
        }

        public override void Execute(Miner m) {
            if (m.Thirsty) {
                m.BuyAndDrinkAWhiskey();
                Console.WriteLine("{0}: That's mighty fine sippin liquer", m.Name);
                m.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            } else {
                Console.WriteLine("ERROR!\nERROR!\nERROR!");
            }
        }

        public override void Exit(Miner m) {
            Console.WriteLine("{0}: Leaving the saloon, feelin' good", m.Name);
        }
    }

    public class GoHomeAndSleepTilRested : State<Miner> {

        private static readonly GoHomeAndSleepTilRested _instance = new GoHomeAndSleepTilRested();
        static GoHomeAndSleepTilRested() { }
        private GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance { get { return _instance; } }



        public override void Enter(Miner m) {
            if (m.Location != Location.Shack) {
                Console.WriteLine("{0}: Walkin' home", m.Name);
                m.Location = Location.Shack;
            }
        }

        public override void Execute(Miner m) {
            if (!m.Fatigued) {
                Console.WriteLine("{0}: What a God-darn fantastic nap! Time to find more gold", m.Name);
                m.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            } else {
                m.DecreaseFatigue();
                Console.WriteLine("{0}: ZZZZZ...", m.Name);
            }
        }

        public override void Exit(Miner m) {
            Console.WriteLine("{0}: Leaving the house", m.Name);
        }
    }

    public class VisitBankAndDepositGold : State<Miner> {
        private static readonly VisitBankAndDepositGold _instance = new VisitBankAndDepositGold();
        static VisitBankAndDepositGold() { }
        private VisitBankAndDepositGold() { }
        public static VisitBankAndDepositGold Instance { get { return _instance; } }



        public override void Enter(Miner m) {
            if (m.Location != Location.Bank) {
                Console.WriteLine("{0}: Goin' to the bank. Yes siree", m.Name);

                m.Location = Location.Bank;
            }
        }

        public override void Execute(Miner m) {
            m.AddToWealth(m.GoldCarried);
            m.GoldCarried = 0;
            Console.WriteLine("{0}: Depositing gold. Total saving now: {1}", m.Name, m.Wealth);

            if (m.Wealth >= Miner.ComfortLevel) {
                Console.WriteLine("{0}: Woohoo! Rich enough for now. Back home to my li'lle lady", m.Name);

                m.StateMachine.ChangeState(GoHomeAndSleepTilRested.Instance);
            } else {
                m.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner m) {
            Console.WriteLine("{0}: Leavin' the bank", m.Name);
        }
    }

    public class EnterMineAndDigForNugget : State<Miner> {

        private static readonly EnterMineAndDigForNugget _instance = new EnterMineAndDigForNugget();
        static EnterMineAndDigForNugget() { }
        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance { get { return _instance; } }


        public override void Enter(Miner m) {
            if (m.Location != Location.Goldmine) {
                
                Console.WriteLine("{0}: Walkin' to the goldmine", m.Name);

                m.Location = Location.Goldmine;
            }
        }

        public override void Execute(Miner m) {
            m.GoldCarried++;
            m.IncreaseFatigue();

            Console.WriteLine("{0}: Pickin' up a nugget", m.Name);
            if (m.PocketsFull) {
                m.StateMachine.ChangeState(VisitBankAndDepositGold.Instance);
            }
            if (m.Thirsty) {
                m.StateMachine.ChangeState(QuenchThirst.Instance);
            }
        }

        public override void Exit(Miner m) {
            Console.WriteLine("{0}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold", m.Name);
        }
    }
}