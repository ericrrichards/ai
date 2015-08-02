using System.Diagnostics;

namespace WestWorld1 {
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

        protected BaseGameEntity(string name) {
            Id = nextValidId;
            Name = name;
        }

        public abstract void Update();
    }
}