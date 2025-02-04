using SpartaTextRPG._03.Dungeon;
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

        public void ShowSelectList<T>(List<T> list, string strName)
        {
            if(strName != "")
                Console.WriteLine($"[{strName}]\n");

            int startIndex = currentPageMaxCount * currentPage;
            int endIndex = startIndex + currentPageMaxCount;

            int curCount = 0;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (i >= list.Count)
                    break;

                Console.Write($"- {i % currentPageMaxCount + 1} ");
                SetMenuString((object)list[i]);
                curCount++;
            }

            totalMenuCount = curCount;
            Console.WriteLine(); // 한줄 띄우기
        }

        public virtual void SetMenuString(object gameObject)
        {
            Console.WriteLine("override 해주세요"); // 재정의가 안되어있으면 그대로 보여주는 텍스트
        }

        protected int totalMenuCount;
        public int TotalMenuCount { get => totalMenuCount; }

        protected int selectedMenu;
        public int SelectedMenu { get => selectedMenu; }

        protected int currentPage; // 현재 페이지
        protected int currentPageMaxCount; // 현재 페이지에 보여질 수 있는 최대개수


        protected StateMachine stateMachine;
    }
}
