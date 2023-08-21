namespace Reflection.DataContracts
{
    public interface IPlugin
    {
        void Init();
        AboutInfo GetAbout();
        IMainWindow GetMainWindow();
        string GetPluginName();
    }
}
