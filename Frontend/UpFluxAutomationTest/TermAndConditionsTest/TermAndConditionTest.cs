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

namespace UpFluxAutomation.TermAndConditionsTest
{
    [TestFixture]
    public class TermAndConditionTest : TestBase
    {
        [Test]
        public async Task TestTermAndCondition()
        {
            try
            {
                Console.WriteLine("Starting Term & Condition Test ...");

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
                flow.Chain(new ClickTermAndConditions(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Term & Condition flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Term & Condition Test: {ex.Message}");
            }
        }
    }
}
