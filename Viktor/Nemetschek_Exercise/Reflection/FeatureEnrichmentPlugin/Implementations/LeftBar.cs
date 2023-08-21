using Reflection.DataContracts;

namespace FeatureEnrichmentPlugin.Implementations
{
    public class LeftBar : ITools
    {
        private List<Tool> tools;

        public LeftBar()
        {
            tools = new List<Tool>
            {
                new Tool { Name = "Tool1", Description = "Tool 1", Icon = "icon1", NavigationPath = "/tool1" },
                new Tool { Name = "Tool2", Description = "Tool 2", Icon = "icon2", NavigationPath = "/tool2" }
            };
        }

        public List<Tool> GetTools()
        {
            return tools;
        }
    }
}
