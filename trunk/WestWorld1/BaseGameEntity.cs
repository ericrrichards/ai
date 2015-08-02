using System.Diagnostics;

namespace WestWorld1 {
    using System;

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
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }

        protected BaseGameEntity(string name) {
            Id = nextValidId;
            Name = name;
            Color = ConsoleColor.White;
        }

        public abstract void Update();

        public void LogAction( string message) {
            ConsoleUtilities.SetTextColor(Color);
            Console.WriteLine("{0}: {1}", Name, message);
        }
    }
}