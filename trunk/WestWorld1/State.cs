namespace WestWorld1 {
    public abstract class State {
        public abstract void Enter(Miner m);
        public abstract void Execute(Miner m);
        public abstract void Exit(Miner m);
    }
}