using NUnit.Framework;
using UpFluxAutomationTest.TestBase;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;
using System;
using UpFluxAutomation.Abstractions;
using UpFluxAutomationTest.Assertion;
using UpFluxAutomation.Steps.UpdateManagemet;
using UpFluxAutomation.Steps.VersionControl;

namespace UpFluxAutomation.VersionControlTest
{
    [TestFixture]
    public class SelectAppVersionTest : TestBase
    {
        [Test]
        public async Task TestAppVersion()
        {
            try
            {
                Console.WriteLine("Starting AppVersion Test...");

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
                flow.Chain(new ClickViewIcon(Repository));
                flow.Chain(new VersionControlAssertion(Repository));
                flow.Chain(new ClickAppVersionButton(Repository));
                flow.Chain(new SelectApp(Repository));
                flow.Chain(new SelectAppVersion(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Check AppVersion  flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during  AppVersion Test: {ex.Message}");
            }
        }
    }
}
