﻿using DynamicExtensionsPlugin.Implementations;
using Reflection.DataContracts;

namespace DynamicExtensionsPlugin
{
    public class DynamicExtensionsPlugin : IPlugin
    {
        private AboutInfo aboutInfo;
        private MainWindow mainWindow;
        public DynamicExtensionsPlugin()
        {
            Console.WriteLine("Constructor of FeatureEnrichmentPlugin is called.");
            aboutInfo = new AboutInfo
            {
                Name = "Dynamic Extensions Plugin",
                About = "This plugin is the second plugin from my plugins. It does even more magic things.",
                Credits = "Viktor Milanov",
                Version = "1.0",
                BuildNumber = "12345"
            };
            mainWindow = new MainWindow();
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
            mainWindow.Init();
        }
    }
}