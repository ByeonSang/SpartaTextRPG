using SpartaTextRPG._02.Object;
using SpartaTextRPG._02.Object.Game;
using SpartaTextRPG._02.Object.Game.Shop;
using SpartaTextRPG._03.Dungeon;
using SpartaTextRPG._03.Dungeon.Game;
using SpartaTextRPG._04.Data;


namespace SpartaTextRPG
{
    internal class Game
    {
        public const int MaxGold = 2000000000;

        public Game()
        {
            player = new Player("user", 1, 100, 10, 12, 100, JobType.WARRIOR);
            data = new InitializeData(player);
            itemShop = new StartPointShop(3,3);
            dungeons = new List<Dungeon>();
            dungeons.Add(new TrainningRoom(player));
            stateMachine = new StateMachine(this); // 위에 먼저 초기화 해주고 stateMachine 초기화
        }

        public void GameStart()
        {
            // 초기 세팅
            stateMachine.InitMachine(stateMachine.MainScene);

            // 게임 로직
            while (true) 
            {
                stateMachine.CurrentScene.Update();
            }
        }

        public void GameExit(string str)
        {
            Console.WriteLine(str);
            Data.WriteJson();
            Environment.Exit(0);
        }

        private InitializeData data;
        public InitializeData Data { get => data; }

        private StateMachine stateMachine;
        
        private Player player;
        public Player Player { get => player; }

        private ShopHandler itemShop;
        public ShopHandler ItemShop { get => itemShop;}

        private List<Dungeon> dungeons;
        public List<Dungeon> Dungeons { get => dungeons;}
    }
}
