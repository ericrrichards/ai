using System.Diagnostics;

namespace WestWorld1 {
    public abstract class BaseGameEntity {
        private static int nextValidId;

        private int _id;
        public int Id { 
            get { return _id; }
            private set {
                Debug.Assert(value >= nextValidId, "Invalid id");
                _id = value;
                nextValidId = value + 1;
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