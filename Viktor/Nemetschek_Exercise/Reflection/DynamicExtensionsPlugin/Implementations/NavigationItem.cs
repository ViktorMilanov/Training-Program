using Reflection.DataContracts;

namespace DynamicExtensionsPlugin.Implementations
{
    public class NavigationItem : INavigation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string NavigationPath { get; set; }
        public List<Reflection.DataContracts.NavigationItem> GetNavigation()
        {
            List<Reflection.DataContracts.NavigationItem> navigationItems = new List<Reflection.DataContracts.NavigationItem>
            {
                new Reflection.DataContracts.NavigationItem { Name = "Page1", Description = "Navigate to Page 1", NavigationPath = "/page1" },
                new Reflection.DataContracts.NavigationItem { Name = "Page2", Description = "Navigate to Page 2", NavigationPath = "/page2" }
            };

            return navigationItems;
        }
    }
}
