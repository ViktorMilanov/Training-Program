using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Reflection;
using Reflection.DataContracts;

List<IPlugin> plugins = new List<IPlugin>();
string pluginsDirectory = @"..\..\..\Plugins";


DBDataAccess dbDataAccess = new DBDataAccess();
/*dbDataAccess.CreateLogsTable();*/


foreach (var dllPath in Directory.GetFiles(pluginsDirectory, "*dll", SearchOption.AllDirectories))
{
    Assembly assembly = Assembly.LoadFrom(dllPath); 
    foreach (var type in assembly.GetTypes())
    {
        if(typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
        {
            var plugin = (IPlugin)Activator.CreateInstance(type);
            plugins.Add(plugin);
        }
    }
}
int selectedPluginIndex = 0;
while (selectedPluginIndex != plugins.Count)
{
    Console.WriteLine("Loaded plugins:");
    for (int i = 0; i < plugins.Count; i++)
    {
        if (plugins[i].GetAbout() == null)
        {
            Console.WriteLine($"{i + 1}. {plugins[i]}");
        }
        else
        {
            Console.WriteLine($"{i + 1}. {plugins[i].GetPluginName()}");
        }
    }
    Console.WriteLine($"{plugins.Count + 1}. Exit");
    Console.Write("Choose a plugin by entering its number: ");
    selectedPluginIndex = int.Parse(Console.ReadLine()) - 1;

    if (selectedPluginIndex >= 0 && selectedPluginIndex < plugins.Count)
    {
        IPlugin selectedPlugin = plugins[selectedPluginIndex];
        selectedPlugin.Init();

        AboutInfo aboutInfo = selectedPlugin.GetAbout();
        Console.WriteLine($"Plugin Name: {selectedPlugin.GetPluginName()}");
        Console.WriteLine($"Plugin Version: {aboutInfo.Version}");
        Console.WriteLine("\nPlugin Methods:");
        Type pluginType = selectedPlugin.GetType();
        MethodInfo[] methods = pluginType.GetMethods();

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine($"Method Name: {method.Name}");
            Console.WriteLine($"Return Type: {method.ReturnType}");
        }

        dbDataAccess.InsertLog(selectedPlugin.GetPluginName(), aboutInfo.Version);

        plugins[selectedPluginIndex] = (IPlugin)Activator.CreateInstance(plugins[selectedPluginIndex].GetType());

    }
    else if (selectedPluginIndex > plugins.Count)
    {
        throw new ArgumentException("Invalid plugin number");
    }
}