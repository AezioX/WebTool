using System;
using NUnit.Framework;
using WebTool.Services.ServerMonitor;
using Moq;
using WebTool.Models.ServerMonitor;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WebTool.UnitTests.Services.ServerMonitor
{
    [TestFixture]
    public class ServerMonitorServiceTests
    {
        [Test]
        public async Task GetUpdatedServersData_WhenServerListIsNotEmpty_ServerListNotEmpty()
        {
            //Set up ServersService mock object
            var serversService = new Mock<IServersService>();
            var servers = new Servers();
            servers.MonitoredServers.Add(new Server { Name = "Test" });
            serversService.Setup(sS => sS.GetStoredServerListAsync()).ReturnsAsync(servers);

            var serverMonitorService = new ServerMonitorService(new ServerChecker(), serversService.Object);

            var result = await serverMonitorService.GetUpdatedServersDataAsync();

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public async Task GetUpdatedServersData_WhenServerListIsEmpty_ServerListIsEmpty()
        {
            //Set up ServersService mock object
            var serversService = new Mock<IServersService>();
            var servers = new Servers();
            serversService.Setup(sS => sS.GetStoredServerListAsync()).ReturnsAsync(servers);

            var serverMonitorService = new ServerMonitorService(new ServerChecker(), serversService.Object);

            var result = await serverMonitorService.GetUpdatedServersDataAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetUpdatedServersData_WhenServerListIsNotEmpty_ReturnListOfServersObject()
        {
            //Set up ServersService mock object
            var serversService = new Mock<IServersService>();
            var servers = new Servers();
            servers.MonitoredServers.Add(new Server { Name = "Test" });
            serversService.Setup(sS => sS.GetStoredServerListAsync()).ReturnsAsync(servers);

            var serverMonitorService = new ServerMonitorService(new ServerChecker(), serversService.Object);

            var result = await serverMonitorService.GetUpdatedServersDataAsync();

            Assert.That(result, Is.TypeOf<ObservableCollection<Server>>());
        }
    }
}