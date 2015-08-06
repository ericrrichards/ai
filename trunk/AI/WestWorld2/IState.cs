namespace WestWorld2 {
    public interface IState<in TEntity> where TEntity: BaseGameEntity {
        void Enter(TEntity entity);
        void Execute(TEntity entity);
        void Exit(TEntity entity);
        bool OnMessage(TEntity owner, Telegram telegram);
    }
}