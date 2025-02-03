using SpartaTextRPG._02.Object;
using SpartaTextRPG._02.Object.Game;


namespace SpartaTextRPG
{
    internal class Game
    {
        public Game()
        {
            player = new Player("user", 1, 100, 10, 12, 1000, JobType.WARRIOR);
            stateMachine = new StateMachine(this);
        }

        public void GameStart()
        {
            stateMachine.InitMachine(stateMachine.MainScene);


            while (true) 
            {
                stateMachine.CurrentScene.Update();
            }
        }

        private StateMachine stateMachine;
        
        private Player player;
        public Player Player { get => player; }
    }
}
