using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRPG
{
    internal abstract class State
    {
        public State(StateMachine _stateMachine)
        {
            stateMachine = _stateMachine;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();

        protected StateMachine stateMachine;
    }
}
