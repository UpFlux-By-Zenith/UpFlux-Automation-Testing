using NUnit.Framework;
using UpFluxAutomation.Steps;
using UpFluxAutomationTest.TestBase;

namespace UpFluxAutomation.Tests
{
    [TestFixture]
    public class EngineerLoginTests : TestBase
    {
        [Test]
        public async Task TestEngineerLogin()
        {
            Console.WriteLine("Starting TestEngineerLogin...");

            var loginSteps = new EngineerLogin();

            // Execute the engineer login steps
            await loginSteps.Execute(Page, EngineerEmail, EngineerToken);

        }
    }
}
