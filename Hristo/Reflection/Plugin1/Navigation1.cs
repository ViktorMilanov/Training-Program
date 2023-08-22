using Reflection.DataContracts;

namespace Plugin1
{
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
}
