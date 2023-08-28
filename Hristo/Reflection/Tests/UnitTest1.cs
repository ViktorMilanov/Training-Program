using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System.Reflection;

namespace ConsoleApp.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private StringWriter _output;

        [SetUp]
        public void Setup()
        {
            _output = new StringWriter();
            Console.SetOut(_output);
        }

        [TearDown]
        public void Cleanup()
        {
            _output.Dispose();
        }

        [Test]
        public void Test_NoPluginsDirectory_FailsGracefully()
        {
            // Arrange
            string nonExistentDirectory = "NonExistentDirectory";
            var originalBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("APPBASE", nonExistentDirectory);

            // Act
            Program.Main(new string[0]);

            // Assert
            string expectedOutput = "No plugins found in the Plugins directory.";
            Assert.IsTrue(_output.ToString().Contains(expectedOutput));

            // Reset APPBASE
            AppDomain.CurrentDomain.SetData("APPBASE", originalBaseDirectory);
        }

        // Add more test methods for other scenarios...

        // Example of a mock-based test
        [Test]
        public void Test_SelectPlugin_PrintsPluginInfoAndMethods()
        {
            // Arrange
            var pluginMock = new Mock<IPlugin>();
            pluginMock.Setup(p => p.GetPluginName()).Returns("TestPlugin");
            var pluginList = new List<IPlugin> { pluginMock.Object };
            var selectedPlugin = pluginList[0];

            var pluginTypeMock = new Mock<Type>();
            pluginTypeMock.Setup(t => t.GetMethods()).Returns(new MethodInfo[0]);

            var assemblyMock = new Mock<Assembly>();
            assemblyMock.Setup(a => a.GetTypes()).Returns(new Type[] { pluginTypeMock.Object });

            var fileMock = new Mock<FileInfo>();
            fileMock.Setup(f => f.FullName).Returns("plugin.dll");

            var directoryMock = new Mock<DirectoryInfo>();
            directoryMock.Setup(d => d.GetFiles("*.dll")).Returns(new FileInfo[] { fileMock.Object });

            var baseDirectoryMock = new Mock<AppDomain>();
            baseDirectoryMock.Setup(b => b.BaseDirectory).Returns("BaseDirectory");
            AppDomain.CurrentDomain.SetData("APPBASE", baseDirectoryMock.Object.BaseDirectory);

            var directoryInfoMock = new Mock<DirectoryInfo>();
            directoryInfoMock.Setup(d => d.Exists).Returns(true);
            directoryInfoMock.Setup(d => d.GetFiles("*.dll")).Returns(new FileInfo[] { fileMock.Object });

            var directoryInfoFactoryMock = new Mock<Func<string, DirectoryInfo>>();
            directoryInfoFactoryMock.Setup(f => f(It.IsAny<string>())).Returns(directoryInfoMock.Object);

            var assemblyMockFactory = new Mock<Func<string, Assembly>>();
            assemblyMockFactory.Setup(f => f(It.IsAny<string>())).Returns(assemblyMock.Object);

            var activatorMock = new Mock<Func<Type, object>>();
            activatorMock.Setup(a => a(It.IsAny<Type>())).Returns(selectedPlugin);

            var consoleMock = new Mock<TextWriter>();

            Program.GetDirectoryInfo = directoryInfoFactoryMock.Object;
            Program.GetAssembly = assemblyMockFactory.Object;
            Program.ActivateInstance = activatorMock.Object;
            Program.ConsoleOut = consoleMock.Object;

            // Act
            Program.Main(new string[0]);

            // Assert
            pluginMock.Verify(p => p.GetPluginName(), Times.Once);
            consoleMock.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
