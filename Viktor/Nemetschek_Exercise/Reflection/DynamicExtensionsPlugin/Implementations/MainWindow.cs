using Reflection.DataContracts;
using System;
using System.Collections.Generic;

namespace DynamicExtensionsPlugin.Implementations
{
    public class MainWindow : IMainWindow
    {
        private List<INavigation> topNavigation;
        private ITools leftBar;
        private IUI ui;

        public MainWindow()
        {

        }
        public List<Tool> GetLeftBar()
        {
            return leftBar.GetTools();
        }

        public List<INavigation> GetTopNavigation()
        {
            return topNavigation;
        }

        public IUI GetUI()
        {
            return ui;
        }

        public void Init()
        {
            topNavigation = new List<INavigation>
            {
                new NavigationItem { Name = "Home", Description = "Navigate to Home", NavigationPath = "/home" },
                new NavigationItem { Name = "Profile", Description = "Navigate to Profile", NavigationPath = "/profile" }
            };



            ui = new UI();

            Console.WriteLine("MainWindow is initializing.");
        }

        public void Open()
        {
            Console.WriteLine("MainWindow of the first plugin is now open.");
        }

        List<Tool> IMainWindow.GetLeftBar()
        {
            throw new NotImplementedException();
        }

        List<INavigation> IMainWindow.GetTopNavigation()
        {
            throw new NotImplementedException();
        }
    }
}
