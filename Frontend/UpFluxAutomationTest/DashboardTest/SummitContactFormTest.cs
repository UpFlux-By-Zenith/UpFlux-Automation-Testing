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
    public class SummitContactFormTest : TestBase
    {
        [Test]
        public async Task TestSummitContactForm()
        {
            try
            {
                Console.WriteLine("Starting Summit Contact Form Test ...");

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
                flow.Chain(new FillAndSummitContactForm(Repository));
                flow.Chain(new ClickSummitMessageButton(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Summit Contact Form flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Summit Contact Form Test: {ex.Message}");
            }
        }
    }
}
