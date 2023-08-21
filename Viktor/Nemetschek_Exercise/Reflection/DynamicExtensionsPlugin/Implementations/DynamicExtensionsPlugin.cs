using DynamicExtensionsPlugin.Implementations;
using Reflection.DataContracts;
using System;

namespace DynamicExtensionsPlugin
{
    public class DynamicExtensionsPlugin : IPlugin
    {
        private AboutInfo aboutInfo;
        private MainWindow mainWindow;
        public DynamicExtensionsPlugin()
        {
            aboutInfo = new AboutInfo
            {
                Name = "Dynamic Extensions Plugin",
                About = "This plugin is the first plugin from my plugins. It does even more magic things.",
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
            Console.WriteLine("First plugin is initializing.");
            mainWindow = new MainWindow();
            mainWindow.Init();
        }
    }
}