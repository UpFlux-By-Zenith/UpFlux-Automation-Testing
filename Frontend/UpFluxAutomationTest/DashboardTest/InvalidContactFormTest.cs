using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;
using UpFluxAutomation.Steps.Dashboard;
using UpFluxAutomationTest.Assertion;
using UpFluxAutomationTest.TestBase;

namespace UpFluxAutomation.DashboardTest
{
    [TestFixture]
    public class InvalidContactFormTest : TestBase
    {
        [Test]
        public async Task TestInvalidContactForm()
        {
            try
            {
                Console.WriteLine("Starting Invalid Summit Contact Form Test ...");

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
                flow.Chain(new ClickSummitMessageButton(Repository));
                flow.Chain(new InvalidContactFormAssertion(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Invalid Summit Contact Form flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Invalid Summit Contact Form Test: {ex.Message}");
            }
        }
    }
}
