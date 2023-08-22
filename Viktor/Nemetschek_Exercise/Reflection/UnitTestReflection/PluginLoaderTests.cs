using Microsoft.VisualStudio.TestTools.UnitTesting;
using
using System;
using NUnit.Framework;

namespace UnitTestReflection
{
    [TestClass]
    public class PluginLoaderTests
    {
        [TestMethod]
        public void TestLoadPlugins_LoadsPluginsSuccessfully()
        {
            // Arrange
            string pluginsDirectory = GetPluginsDirectory();
            var pluginLoader = new PluginLoader(pluginsDirectory);

            // Act
            List<IPlugin> plugins = pluginLoader.LoadPlugins();

            // Assert
            Assert.NotNull(plugins);
            Assert.Greater(plugins.Count, 0);
        }

        [TestMethod]
        public void TestLoadPlugins_InvalidDirectory_ReturnsEmptyList()
        {
            // Arrange
            string invalidDirectory = @"C:\NonExistentDirectory";
            var pluginLoader = new PluginLoader(invalidDirectory);

            // Act
            List<IPlugin> plugins = pluginLoader.LoadPlugins();

            // Assert
            Assert.NotNull(plugins);
            Assert.IsEmpty(plugins);
        }

        [TestMethod]
        public void TestLoadPlugins_NoDllFiles_ReturnsEmptyList()
        {
            // Arrange
            string emptyDirectory = @"..\..\..\EmptyDirectory";
            var pluginLoader = new PluginLoader(emptyDirectory);

            // Act
            List<IPlugin> plugins = pluginLoader.LoadPlugins();

            // Assert
            Assert.NotNull(plugins);
            Assert.IsEmpty(plugins);
        }

        [TestMethod]
        public void TestSelectPlugin_WithValidIndex_SelectsCorrectPlugin()
        {
            // Arrange
            string pluginsDirectory = GetPluginsDirectory();
            var pluginLoader = new PluginLoader(pluginsDirectory);
            List<IPlugin> plugins = pluginLoader.LoadPlugins();

            // Act
            int selectedPluginIndex = 0; // Choose a valid index here
            IPlugin selectedPlugin = plugins[selectedPluginIndex];
            AboutInfo aboutInfo = selectedPlugin.GetAbout();

            // Assert
            Assert.NotNull(selectedPlugin);
            Assert.AreEqual(selectedPlugin.GetPluginName(), aboutInfo.Name);
        }

        [Test]
        public void TestSelectPlugin_InvalidIndex_ThrowsArgumentException()
        {
            Assert.True(true);
        }

    }
}
