using System;
using System.Threading.Tasks;
using NUnit.Framework;
using WebTool.Services.DataBreach;

namespace WebTool.UnitTests.Services.DataBreach
{
    [TestFixture]
    public class DataBreachServiceTests
    {
        [Test]
        [TestCase("test")]
        [TestCase("data")]
        [TestCase("spy")]
        [TestCase("hunter")]
        public async Task CheckAccountAsync_QueryWithCompromisedAccount_ReturnBreachResultsObjectWithInfo(string account)
        {
            var dataBreachService = new DataBreachService();

            var results = await dataBreachService.CheckAccountAsync(account);
            var resultTitle = results[0].Title;

            bool result;

            if (string.IsNullOrWhiteSpace(resultTitle))
                result = false;
            else
                result = true;

            Assert.That(result, Is.True);
        }
    }
}
