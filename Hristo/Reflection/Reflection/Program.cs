using System.Data.SqlClient;
using System.Reflection;
using Reflection.DataContracts;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=HIvanov-Dual\\MSSQLSERVER01;Database=Plugins;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Loading plugins...");

                string pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
                if (Directory.Exists(pluginsDirectory))
                {
                    bool exitProgram = false;
                    List<IPlugin> loadedPlugins = new();

                    while (!exitProgram)
                    {
                        string[] pluginFiles = Directory.GetFiles(pluginsDirectory, "*.dll");

                        loadedPlugins.Clear(); // Clear previously loaded plugins

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

                            string insertQuery = "INSERT INTO UserChoices (PluginName, ChoiceDateTime) VALUES (@PluginName, @ChoiceDateTime)";
                            using (SqlCommand command = new(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@PluginName", selectedPlugin.GetPluginName());
                                command.Parameters.AddWithValue("@ChoiceDateTime", DateTime.Now);
                                command.ExecuteNonQuery();
                            }

                            Console.WriteLine($"About {selectedPlugin.GetPluginName()}:\n");
                            AboutInfo about = selectedPlugin.GetAbout();
                            Console.WriteLine($"Name: {about.Name}\nAbout: {about.About}\nVersion: {about.Version}\n");

                            Console.WriteLine("Do you want to select another plugin? (y/n)");
                            string continueChoice = Console.ReadLine();
                            if (continueChoice.ToLower() != "y")
                            {
                                exitProgram = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                    }

                    connection.Close();
                }

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
