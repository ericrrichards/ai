namespace WestWorld2 {
    using System;
    using System.Diagnostics;

    public abstract class BaseGameEntity {
        private static int nextValidId;
        private static readonly object SyncRoot = new object();

        private int _id;
        public int Id { 
            get { return _id; }
            private set {
                Debug.Assert(value >= nextValidId, "Invalid id");
                _id = value;
                lock (SyncRoot) {
                    nextValidId = value + 1;
                }
            } 
        }
        public string Name { get; private set; }
        public ConsoleColor Color { get; set; }

        protected BaseGameEntity(string name) {
            Id = nextValidId;
            Name = name;
            Color = ConsoleColor.White;
        }

        public abstract void Update();
        public abstract bool HandleMessage(Telegram telegram);


        public void LogAction( string message) {
            ConsoleUtilities.SetTextColor(Color);
            Console.WriteLine("{0}: {1}", Name, message);
        }
        public void LogMessage() {
            ConsoleUtilities.SetTextColor(ConsoleColor.Black, ConsoleColor.Yellow);
            Console.WriteLine("Message handled by {0} at time: {1}", Name, Clock.GlobalClock.GetCurrentTime());
        }
    }
}