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

namespace UpFluxAutomation.LoginTest
{
    [TestFixture]
    public class DashboardResponsivenessTest : TestBase
    {
        [Test]
        public async Task TestEngineerLogin()
        {
            try
            {
                Console.WriteLine("Starting TestEngineerLogin...");

                // Create and initialize EngineerData
                var engineerData = new EngineerData
                {
                    UpFluxEndPoint = BaseUrl,
                    Email = EngineerEmail,
                    EngineerToken = EngineerToken
                };

                Repository.Add(engineerData);

                // Initialize the flow 
                IStep flow = new  DashboardResponsiveness(Repository);

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("EngineerLogin flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during TestEngineerLogin: {ex.Message}");
            }
        }
    }
}
