using Reflection.DataContracts;

namespace Plugin1
{
    public class PluginOne : IPlugin
    {
        public string Name { get; private set; }
        public MainWindowOne MainWindowOne { get; private set; }
        public AboutInfo AboutInfo { get; private set; }
        public PluginOne()
        {
            Name = "Plugin One";
            MainWindowOne = new MainWindowOne();
        AboutInfo = new AboutInfo()
        {
            Name = "Plugin One",
                About = "This is Plugin One",
                Credits = "Author One",
                Version = "1.0",
                BuildNumber = "123"
            };
        }
        public PluginOne(string name, IMainWindow mainWindow, AboutInfo aboutInfo)
        {
            Name = name;
            MainWindowOne = (MainWindowOne?)mainWindow;
            AboutInfo = aboutInfo;
        }
        
        public void Init()
        {
            Console.WriteLine($"{Name} initialized.");

        }

        public AboutInfo GetAbout()
        {
            return AboutInfo;
        }

        public IMainWindow GetMainWindow()
        {
            return MainWindowOne;
        }

        public string GetPluginName()
        {
            return Name;
        }
    }
}