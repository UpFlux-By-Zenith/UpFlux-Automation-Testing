using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;
using UpFluxAutomationTest.Assertion;
using UpFluxAutomationTest.TestBase;

namespace UpFluxAutomation.DashboardTest
{
    [TestFixture]
    public class LearnMoreTest : TestBase
    {
        [Test]
        public async Task TestLearnMoreTest()
        {
            try
            {
                Console.WriteLine("Starting Learn More Test...");

                // Create and initialize EngineerData
                var engineerData = new EngineerData
                {
                    UpFluxEndPoint = BaseUrl,
                    Email = EngineerEmail,
                    EngineerToken = EngineerToken
                };

                Repository.Add(engineerData);

                // Initialize the flow 
                IStep flow = new NavigateToUpFlux(Repository);
                flow.Chain(new ClickLearnMoreButton(Repository));
                flow.Chain(new LearnMoreAssertion(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Learn More flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Learn More Test: {ex.Message}");
            }
        }
    }
}
