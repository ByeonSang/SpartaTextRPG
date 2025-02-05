using SpartaTextRPG._01.Scene;
using SpartaTextRPG._01.Scene.Game;
using SpartaTextRPG.Scene;

namespace SpartaTextRPG
{
    internal class StateMachine
    {
        public StateMachine(Game game)
        {
            currentState = MainScene;
            mainState = new MainState(this);
            statInfoState = new StatInfoState(this, game.Player);
            inventoryState = new InventoryState(this, game.Player);
            invenManageState = new InvenManageState(this, game.Player);
            shopState = new ShopState(this, game.Player, game.ItemShop);
            shopBuyState = new ShopBuyState(this, game.Player, game.ItemShop);
            shopSaleState = new ShopSaleState(this, game.Player, game.ItemShop);
            restState = new RestState(this, game.Player);
            selectDungeonState = new SelectDungeonState(this, game.Player, game.Dungeons);
            selectDifficultyState = new SelectDifficultyState(this, game.Dungeons);
        }
        
        public void InitMachine(State initializeScene)
        {
            CurrentScene = initializeScene;
            initializeScene.Enter();
        }

        /// <summary>
        /// nextState는 StateMacine에 있는 OOOOScene 프로퍼티를 넣으시면 됩니다.
        /// </summary>
        /// <param name="nextState"></param>
        /// <param name="idx">바꿀 Enter에 index 수신</param>
        public void ChangeScene(State nextState, object? Object = null)
        {
            if (currentState != null)
                currentState.Exit();

            currentState = nextState;
            nextState.Enter(Object);
        }

        private State currentState;
        public State CurrentScene { get => currentState; private set => currentState = value; }

        private MainState mainState;
        public MainState MainScene { get => mainState; private set => mainState = value; }

        private StatInfoState statInfoState;
        public StatInfoState MyStatScene { get => statInfoState; private set => statInfoState = value; }

        private InventoryState inventoryState;
        public InventoryState MyInventoryScene { get => inventoryState; private set => inventoryState = value; }

        private InvenManageState invenManageState;
        public InvenManageState MyEquiptScene { get => invenManageState; private set => invenManageState = value; }

        private ShopState shopState;
        public ShopState ShopScene {  get => shopState;}

        private ShopBuyState shopBuyState;
        public ShopBuyState ShopBuyState { get => shopBuyState; }

        private ShopSaleState shopSaleState;
        public ShopSaleState ShopSaleState { get => shopSaleState; }

        private RestState restState;
        public RestState RestScene { get => restState; }

        private SelectDungeonState selectDungeonState;
        public SelectDungeonState SelctDungeonScene { get => selectDungeonState; }

        private SelectDifficultyState selectDifficultyState;
        public SelectDifficultyState DifficultyScene { get => selectDifficultyState; }
    }
}
