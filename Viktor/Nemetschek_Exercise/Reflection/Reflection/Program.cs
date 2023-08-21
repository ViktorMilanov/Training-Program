using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Reflection.DataContracts;
    
List<IPlugin> plugins = new List<IPlugin>();
string pluginsDirectory = @"..\..\..\Plugins";



foreach (var dllPath in Directory.GetFiles(pluginsDirectory, "*dll"))
{
    Assembly assembly = Assembly.LoadFrom(dllPath);
    foreach (var type in assembly.GetTypes())
    {
        if(typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
        {
            string typeToString = type.ToString();
            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
            plugins.Add(plugin);
        }
    }
}
Console.WriteLine("Loaded plugins:");
for (int i = 0; i < plugins.Count; i++)
{
    Console.WriteLine($"{i + 1}. {plugins[i].GetPluginName()}");
}
Console.Write("Choose a plugin by entering its number: ");
int selectedPluginIndex = int.Parse(Console.ReadLine()) - 1;

if (selectedPluginIndex >= 0 && selectedPluginIndex < plugins.Count)
{
    IPlugin selectedPlugin = plugins[selectedPluginIndex];
    selectedPlugin.Init();

    AboutInfo aboutInfo = selectedPlugin.GetAbout();
    Console.WriteLine($"Plugin Name: {selectedPlugin.GetPluginName()}");
    Console.WriteLine($"Plugin Version: {aboutInfo.Version}");

}
else
{
    throw new ArgumentException("Invalid plugin number");
}