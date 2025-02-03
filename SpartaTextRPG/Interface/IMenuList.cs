namespace SpartaTextRPG.Interface
{
    internal interface IMenuList
    {
        public int TotalMenuCount { get; }
        public int SelectedMenu { get; }

        public void ShowMenu(int idx = 0);
        public bool GetUserInput(out int value);
    }
}
