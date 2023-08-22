using Reflection.DataContracts;

namespace Plugin1
{
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
}
