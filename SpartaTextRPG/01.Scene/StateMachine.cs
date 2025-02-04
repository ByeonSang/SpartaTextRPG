using SpartaTextRPG._01.Scene;
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
        public void ChangeScene(State nextState)
        {
            if (currentState != null)
                currentState.Exit();

            currentState = nextState;
            nextState.Enter();
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
    }
}
