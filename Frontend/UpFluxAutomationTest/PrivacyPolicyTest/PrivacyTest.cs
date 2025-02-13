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

namespace UpFluxAutomation.PrivacyPolicyTest
{
    [TestFixture]
    public class PrivacyTest : TestBase
    {
        [Test]
        public async Task TestPrivacyPolicy()
        {
            try
            {
                Console.WriteLine("Starting Privacy Policy Test ...");

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
                flow.Chain(new ClickPrivacyPolicy(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Privacy Policy flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Privacy Policy Test: {ex.Message}");
            }
        }
    }
}
