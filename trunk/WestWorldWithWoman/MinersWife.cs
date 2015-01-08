using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorldWithWoman {
    public class MinersWife : BaseGameEntity {
        private StateMachine<MinersWife> _stateMachine;
        public StateMachine<MinersWife> StateMachine { get { return _stateMachine; } }
        public Location Location { get; set; }


        public MinersWife(string name) : base(name) {
            Location = Location.Shack;
            _stateMachine = new StateMachine<MinersWife>(this);
            _stateMachine.CurrentState = DoHouseWork.Instance;
            _stateMachine.GlobalState = WifesGlobalState.Instance;
        }
        public override void Update() {
            ConsoleUtilities.SetTextColor(ConsoleColor.Green);
            _stateMachine.Update();
        }
    }
}
