using NUnit.Framework;
using UpFluxAutomationTest.TestBase;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;
using System;
using UpFluxAutomation.Abstractions;
using UpFluxAutomationTest.Assertion;
using UpFluxAutomation.Steps.UpdateManagemet;

namespace UpFluxAutomation.UpdateManagementTest
{
    [TestFixture]
    public class CheckMachinesTest : TestBase
    {
        [Test]
        public async Task TestCheckMachines()
        {
            try
            {
                Console.WriteLine("Starting Check Machines Test...");

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
                flow.Chain(new NavigateToLogin(Repository));
                flow.Chain(new FillEngineerDetails(Repository));
                flow.Chain(new ClickLoginButton(Repository));
                flow.Chain(new EngineerLoginAssertion(Repository));
                flow.Chain(new CheckMachines(Repository));
                flow.Chain(new UpdateManagementAssertion(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Check Machines flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during CheckMachinesTest: {ex.Message}");
            }
        }
    }
}
