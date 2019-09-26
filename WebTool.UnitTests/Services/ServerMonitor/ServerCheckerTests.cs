using System;
using System.Threading.Tasks;
using NUnit.Framework;
using WebTool.Services.ServerMonitor;

namespace WebTool.UnitTests.Services.ServerMonitor
{
    [TestFixture]
    public class ServerCheckerTests
    {
        [Test]
        [TestCase("https://www.google.com")]
        [TestCase("https://google.com")]
        public async Task CheckIfDomainIsValidAsync_DomainIsValid_ReturnTrue(string domain)
        {
            var serverChecker = new ServerChecker();

            var result = await serverChecker.CheckIfDomainIsValidAsync(domain);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("https://google")]
        [TestCase("thisisaninvaliddomain")]
        public async Task CheckIfDomainIsValidAsync_DomainIsNotValid_ReturnFalse(string domain)
        {
            var serverChecker = new ServerChecker();

            var result = await serverChecker.CheckIfDomainIsValidAsync(domain);

            Assert.That(result, Is.False);
        }
    }
}
