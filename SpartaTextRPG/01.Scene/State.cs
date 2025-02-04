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

        public abstract void ShowTitle(); 
        public abstract void ShowMenu(int idx = 0);
        public virtual bool GetUserInput(out int value)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out value))
                return false;

            if (value < 0 || value > totalMenuCount)
                return false;

            return true;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();

        protected int totalMenuCount;
        public int TotalMenuCount { get => totalMenuCount; }

        protected int selectedMenu;
        public int SelectedMenu { get => selectedMenu; }

        protected StateMachine stateMachine;
    }
}
