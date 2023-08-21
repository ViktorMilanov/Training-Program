namespace Reflection.DataContracts
{
    public interface IMainWindow
    {
        List<INavigation> GetTopNavigation();
        List<Tool> GetLeftBar();
        IUI GetUI();
        void Open();
        void Init();
    }
}
