using Reflection.DataContracts;

namespace Plugin2
{
    public class PluginTwo : IPlugin
    {
        public string Name { get; private set; }
        public MainWindowTwo MainWindowTwo { get; private set; }
        public AboutInfo AboutInfo { get; set; }
        public PluginTwo(string name, MainWindowTwo mainWindow, AboutInfo aboutInfo)
        {
            Name = "Plugin Two";
            MainWindowTwo = new MainWindowTwo();
            AboutInfo = new AboutInfo()
            {
                Name = "Plugin Two",
                About = "This is Plugin Two",
                Credits = "Author Two",
                Version = "2.0",
                BuildNumber = "456"
            };
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
               return MainWindowTwo;
        }

        public string GetPluginName()
        {
            return Name;
        }
    }

    
}
