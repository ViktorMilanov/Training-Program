using Reflection.DataContracts;

namespace Plugin2
{
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
}
