using Reflection.DataContracts;

namespace FeatureEnrichmentPlugin.Implementations
{
    public class FeatureEnrichmentPlugin : IPlugin
    {
        private AboutInfo aboutInfo;
        private MainWindow mainWindow;

        public FeatureEnrichmentPlugin()
        {
            Console.WriteLine("Constructor of FeatureEnrichmentPlugin is called.");
            aboutInfo = new AboutInfo
            {
                Name = "Feature Enrichment Plugin",
                About = "This plugin is the second plugin from my plugins. It does magic things.",
                Credits = "Viktor Milanov",
                Version = "1.0",
                BuildNumber = "12345"
            };
        }

        public AboutInfo GetAbout()
        {
            return aboutInfo;
        }

        public IMainWindow GetMainWindow()
        {
            return mainWindow;
        }

        public string GetPluginName()
        {
            return aboutInfo.Name;
        }

        public void Init()
        {
            Console.WriteLine("Second plugin is initializing.");
            mainWindow = new MainWindow();
            mainWindow.Init();
        }
    }
}
