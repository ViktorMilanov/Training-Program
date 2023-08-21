using Reflection.DataContracts;

namespace PluginOne
{
    public class PluginOne : IPlugin
    {
        public void Init()
        {
            Console.WriteLine(this.GetAbout().Name+" initialized.");
        }

        public AboutInfo GetAbout()
        {
            return new AboutInfo
            {
                Name = "Plugin One",
                About = "This is Plugin One",
                Credits = "Author One",
                Version = "1.0",
                BuildNumber = "123"
            };
        }

        public IMainWindow GetMainWindow()
        {
            return new MainWindowOne();
        }

        public string GetPluginName()
        {
            return this.GetAbout().Name;
        }
    }

    public class MainWindowOne : IMainWindow
    {
        public List<INavigation> GetTopNavigation()
        {
            return new List<INavigation>
            {
                new NavigationOne()
            };
        }

        public List<Tool> GetLeftBar()
        {
            return new List<Tool>
            {
                new Tool
                {
                    Name = "Tool One",
                    Icon = "icon.png",
                    Description = "This is Tool One",
                    NavigationPath = "/tools/tool1"
                }
            };
        }

        public IUI GetUI()
        {
            return new UIOne();
        }

        public void Open()
        {
            Console.WriteLine("Opening MainWindowOne.");
        }

        public void Init()
        {
            Console.WriteLine("Initializing MainWindowOne.");
        }
    }

    public class NavigationOne : INavigation
    {
        public List<NavigationItem> GetNavigation()
        {
            return new List<NavigationItem>
            {
                new NavigationItem
                {
                    Name = "Item One",
                    Description = "This is Item One",
                    NavigationPath = "/nav/item1"
                }
            };
        }
    }

    public class UIOne : IUI
    {
        public IFrame GetMainFrame()
        {
            return new FrameOne();
        }

        public IFrame GetLeftFrame()
        {
            return new FrameOne();
        }

        public IFrame GetRightFrame()
        {
            return new FrameOne();
        }

        public IFrame GetTopFrame()
        {
            return new FrameOne();
        }

        public IFrame GetBottomFrame()
        {
            return new FrameOne();
        }
    }

    public class FrameOne : IFrame
    {
        public void SomeFrameMethod()
        {
            Console.WriteLine("FrameOne: SomeFrameMethod");
        }
    }
}
