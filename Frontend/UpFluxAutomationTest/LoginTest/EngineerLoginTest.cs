using NUnit.Framework;
using UpFluxAutomation.Flows;
using UpFluxAutomationTest.TestBase;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps;
using System;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomation.Tests
{
    [TestFixture]
    public class EngineerLoginTests : TestBase
    {
        [Test]
        public async Task TestEngineerLogin()
        {
            try
            {
                // Create and initialize EngineerData
                var engineerData = new EngineerData
                {
                    Email = EngineerEmail,
                    EngineerToken = EngineerToken
                };

                Repository.Add(engineerData);

                // Create the predefined flow for EngineerLogin
                IStep Flow = PredefinedFlow.EngineerLogin.CreateFlow(Repository);

                // Execute the flow
                await Flow.Execute();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during TestEngineerLogin: {ex.Message}");
            }
        }
    }
}


