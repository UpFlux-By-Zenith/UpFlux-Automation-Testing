using NUnit.Framework;
using UpFluxAutomation.Flows;
using UpFluxAutomationTest.TestBase;
using UpFluxAutomation.Steps.Abstractions;
using UpFluxAutomation.Helpers;
using UpFluxAutomationTest.Assertion;

namespace UpFluxAutomation.Tests
{
    [TestFixture]
    public class EngineerLoginTests : TestBase
    {
        [Test]
        public async Task TestEngineerLogin()
        {
            // Create and initialize EngineerData
            var engineerData = new EngineerData
            {
                Email = EngineerEmail,
                EngineerToken = EngineerToken
            };

            // Initialize Repository 
            Repository = new MemoryRepository();
            Repository.Add(engineerData);

            // Create the predefined flow for EngineerLogin
            IStep Flow = PredefinedFlow.EngineerLogin.CreateFlow(Repository);
            Flow.Chain(new EngineerLoginAssertion(Repository));

            // Execute the flow
            await Flow.Execute(Page);
        }
    }
}
