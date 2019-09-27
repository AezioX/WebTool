using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NUnit.Framework;
using WebTool.Services.DomainDatabase;
using WebTool.Models.DomainDatabase;

namespace WebTool.UnitTests.Services.DomainDatabase
{
    [TestFixture]
    public class DomainDatabaseServiceTests
    {
        [Test]
        [TestCase("test")]
        public async Task CheckDomainsDatabase_ValidQueryString_ReturnListWithRequestedDomainString(string data)
        {
            var domainDatabaseService = new DomainDatabaseService();

            var results = await domainDatabaseService.CheckDomainsDatabase(data);
            var result = results[0].Domain;

            Assert.That(result, Does.Contain("test"));
        }

        [Test]
        [TestCase("test")]
        public async Task CheckDomainsDatabase_ValidQueryString_ReturnListOfDomainsDataObject(string data)
        {
            var domainDatabaseService = new DomainDatabaseService();

            var results = await domainDatabaseService.CheckDomainsDatabase(data);

            Assert.That(results, Is.TypeOf<ObservableCollection<DomainsData>>());
        }

        [Test]
        [TestCase("jk324gi3g42h3g42u3hgfsa")]
        public void CheckDomainsDatabase_NonExistentDomainString_ThrowException(string data)
        {
            var domainDatabaseService = new DomainDatabaseService();

            Assert.That(async() => await domainDatabaseService.CheckDomainsDatabase(data), Throws.Exception);
        }
    }
}
