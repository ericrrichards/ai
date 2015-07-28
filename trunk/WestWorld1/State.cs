namespace WestWorld1 {
    public abstract class State {
        public abstract void Enter(Miner miner);
        public abstract void Execute(Miner miner);
        public abstract void Exit(Miner miner);
    }
}