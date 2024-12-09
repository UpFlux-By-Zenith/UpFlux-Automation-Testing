using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace UpFluxAutomationTest.Assertion
{
    public class EngineerLoginAssertion
    {
        /// <summary>
        /// Verifies that the engineer dashboard is visible.
        /// </summary>
        /// <param name="page">The Playwright page object.</param>
        public async Task VerifyEngineerDashboardIsVisibleAsync(IPage page)
        {
            // Wait for the engineer dashboard selector
            Console.WriteLine("Verifying engineer dashboard...");
            var LoginSuccess = page.Locator("#engineerDashboard");

            // Perform the assertion
            await Assertions.Expect(LoginSuccess).ToBeVisibleAsync(); 
        }
    }
}
