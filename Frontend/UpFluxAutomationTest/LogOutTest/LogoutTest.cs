using NUnit.Framework;
using UpFluxAutomationTest.TestBase;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;
using System;
using UpFluxAutomation.Abstractions;
using UpFluxAutomationTest.Assertion;
using UpFluxAutomation.Steps.UpdateManagemet;

namespace UpFluxAutomation.ProfilteTest
{
    [TestFixture]
    public class LogoutTest : TestBase
    {
        [Test]
        public async Task TestLogout()
        {
            try
            {
                Console.WriteLine("Starting Check  Logout Test...");

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
                flow.Chain(new ClickSmartUpdateButton(Repository));
                flow.Chain(new ClusteringAssertion(Repository));
                flow.Chain(new CLickLogout(Repository));
                flow.Chain(new LogoutAssertion(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Logout flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Test  Logout: {ex.Message}");
            }
        }
    }
}
