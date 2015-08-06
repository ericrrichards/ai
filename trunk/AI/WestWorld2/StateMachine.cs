namespace WestWorld2 {
    using System;

    public class StateMachine<TEntity> where TEntity:BaseGameEntity {
        public TEntity Owner { get; set; }
        public IState<TEntity> CurrentState { get; set; }
        public IState<TEntity> PreviousState { get; set; }
        public IState<TEntity> GlobalState { get; set; }

        public StateMachine(TEntity owner, IState<TEntity> initialState, IState<TEntity> globalState = null) {
            Owner = owner;
            CurrentState = initialState;
            GlobalState = globalState;
        }

        public void Update() {
            if (null != GlobalState) {
                GlobalState.Execute(Owner);
            }
            if (null != CurrentState) {
                CurrentState.Execute(Owner);
            }
        }

        public void ChangeState(IState<TEntity> newState) {
            if (newState == null) {
                throw new ArgumentNullException("newState");
            }
            PreviousState = CurrentState;
            CurrentState.Exit(Owner);
            CurrentState = newState;
            CurrentState.Enter(Owner);
        }

        public void RevertToPreviousState() {
            ChangeState(PreviousState);
        }

        public bool IsInState(IState<TEntity> state) { return CurrentState.GetType() == state.GetType(); }

        public bool HandleMessage(Telegram telegram) {
            if (CurrentState != null && CurrentState.OnMessage(Owner, telegram)) {
                return true;
            }
            if (GlobalState != null && GlobalState.OnMessage(Owner, telegram)) {
                return true;
            }
            return false;
        }
    }
}
