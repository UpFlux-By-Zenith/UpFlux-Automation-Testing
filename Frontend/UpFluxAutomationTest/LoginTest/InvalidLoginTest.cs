using NUnit.Framework;
using UpFluxAutomationTest.TestBase;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;
using System;
using UpFluxAutomation.Abstractions;
using UpFluxAutomationTest.Assertion;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UpFluxAutomation.Tests
{
    [TestFixture]
    public class InvalidLoginTest : TestBase
    {
        [Test]
        public async Task TestInvalidEngineerLogin()
        {
            try
            {
                Console.WriteLine("Starting Test Invalid Engineer Login...");

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
                flow.Chain(new FillInvalidEngineerDetails(Repository));
                flow.Chain(new ClickLoginButton(Repository));
                flow.Chain(new InvalidLoginAssertion(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Invalid Engineer Login flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Test Invalid EngineerLogin: {ex.Message}");
            }
        }
    }
}
