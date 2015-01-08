using System.Diagnostics;

namespace WestWorldWithWoman {
    public class StateMachine<T> {
        private readonly T _owner;
        public State<T> CurrentState { get; set; }
        public State<T> PreviousState { get; set; }
        public State<T> GlobalState { get; set; }

        public StateMachine(T entity) {
            _owner = entity;
        }

        public void Update() {
            if (GlobalState != null) {
                GlobalState.Execute(_owner);
            }
            if (CurrentState != null) {
                CurrentState.Execute(_owner);
            }
        }

        public void ChangeState(State<T> newState) {
            Debug.Assert(newState!=null,"Trying to change to null state");
            PreviousState = CurrentState;
            CurrentState.Exit(_owner);
            CurrentState = newState;
            CurrentState.Enter(_owner);
        }

        public void RevertToPreviousState() {
            ChangeState(PreviousState);
        }

        public bool IsInState(State<T> state) {
            return state is T;
        }
    }
}