using System.Reflection;
using Reflection.DataContracts;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string pluginsFolder = "Plugins";
            List<IPlugin> plugins = LoadPlugins(pluginsFolder);

            Console.WriteLine($"Found {plugins.Count} plugins:");
            for (int i = 0; i < plugins.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {plugins[i].GetPluginName()} - {plugins[i].GetAbout().Version}");
            }

            Console.Write("Choose plugin (number): ");
            int chosenPluginIndex = int.Parse(Console.ReadLine()) - 1;
            IPlugin chosenPlugin = plugins[chosenPluginIndex];

            chosenPlugin.Init();
            IMainWindow mainWindow = chosenPlugin.GetMainWindow();
            _ = mainWindow.GetTopNavigation();
            _ = mainWindow.GetLeftBar();
        }

        static List<IPlugin> LoadPlugins(string folderPath)
        {
            List<IPlugin> plugins = new();
            string[] pluginFiles = Directory.GetFiles(folderPath, "*.dll");

            foreach (string pluginFile in pluginFiles)
            {
                Assembly assembly = Assembly.LoadFrom(pluginFile);
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        IPlugin plugin = Activator.CreateInstance(type) as IPlugin;
                        plugins.Add(plugin);
                    }
                }
            }

            return plugins;
        }
    }
}
