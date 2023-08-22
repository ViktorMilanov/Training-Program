using Reflection.DataContracts;

namespace Plugin2
{
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
}
