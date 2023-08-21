using Reflection.DataContracts;

namespace PluginTwo
{
    public class PluginTwo : IPlugin
    {
        public void Init()
        {
            Console.WriteLine("Plugin Two initialized.");
        }

        public AboutInfo GetAbout()
        {
            return new AboutInfo
            {
                Name = "Plugin Two",
                About = "This is Plugin Two",
                Credits = "Author Two",
                Version = "2.0",
                BuildNumber = "456"
            };
        }

        public IMainWindow GetMainWindow()
        {
            return new MainWindowTwo();
        }

        public string GetPluginName()
        {
            return "Plugin Two";
        }
    }

    public class MainWindowTwo : IMainWindow
    {
        public List<INavigation> GetTopNavigation()
        {
            return new List<INavigation>
            {
                new NavigationTwo()
            };
        }

        public List<Tool> GetLeftBar()
        {
            return new List<Tool>
            {
                new Tool
                {
                    Name = "Tool Two",
                    Icon = "icon.png",
                    Description = "This is Tool Two",
                    NavigationPath = "/tools/tool2"
                }
            };
        }

        public IUI GetUI()
        {
            return new UITwo();
        }

        public void Open()
        {
            Console.WriteLine("Opening MainWindowTwo.");
        }

        public void Init()
        {
            Console.WriteLine("Initializing MainWindowTwo.");
        }
    }

    public class NavigationTwo : INavigation
    {
        public List<NavigationItem> GetNavigation()
        {
            return new List<NavigationItem>
            {
                new NavigationItem
                {
                    Name = "Item Two",
                    Description = "This is Item Two",
                    NavigationPath = "/nav/item2"
                }
            };
        }
    }

    public class UITwo : IUI
    {
        public IFrame GetMainFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetLeftFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetRightFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetTopFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetBottomFrame()
        {
            return new FrameTwo();
        }
    }

    public class FrameTwo : IFrame
    {
        public void SomeFrameMethod()
        {
            Console.WriteLine("FrameTwo: SomeFrameMethod");
        }
    }
}
