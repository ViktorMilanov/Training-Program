using System.Reflection;
using Reflection.DataContracts;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading plugins...");

            string pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (Directory.Exists(pluginsDirectory))
            {
                string[] pluginFiles = Directory.GetFiles(pluginsDirectory, "*.dll");

                List<IPlugin> loadedPlugins = new();

                foreach (string pluginFile in pluginFiles)
                {
                    Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
                    Type[] types = pluginAssembly.GetTypes();

                    foreach (Type type in types)
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type))
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            loadedPlugins.Add(plugin);
                            Console.WriteLine($"Loaded plugin: {plugin.GetPluginName()}");
                        }
                    }
                }

                Console.WriteLine("Select a plugin to get information about:");
                for (int i = 0; i < loadedPlugins.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {loadedPlugins[i].GetPluginName()}");
                }

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= loadedPlugins.Count)
                {
                    IPlugin selectedPlugin = loadedPlugins[choice - 1];

                    Console.WriteLine($"About {selectedPlugin.GetPluginName()}:");
                    AboutInfo about = selectedPlugin.GetAbout();
                    Console.WriteLine($"About: {about.Name}, Version: {about.Version}");
                    Console.WriteLine();

                    Type selectedType = selectedPlugin.GetType();
                    MethodInfo[] methods = selectedType.GetMethods();
                    foreach (MethodInfo method in methods)
                    {
                        Console.WriteLine($"Method: {method.Name}, Type: {method.ReturnType}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("No plugins found in the Plugins directory.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
