using System.Diagnostics;

namespace WestWorld1 {
    public abstract class BaseGameEntity {
        private static int _nextValidId;

        private int _id;
        public int Id { 
            get { return _id; }
            private set {
                Debug.Assert(value >= _nextValidId, "Invalid id");
                _id = value;
                _nextValidId = value + 1;
            } 
        }
        public string Name { get; set; }

        protected BaseGameEntity(string name) {
            Id = _nextValidId;
            Name = name;
        }

        public abstract void Update();
    }
}