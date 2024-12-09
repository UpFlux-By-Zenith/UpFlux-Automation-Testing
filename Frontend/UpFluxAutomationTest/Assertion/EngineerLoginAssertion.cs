using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps;
using UpFluxAutomation.Steps.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class EngineerLoginAssertion : BaseStep
    {
        public EngineerLoginAssertion(MemoryRepository repository) : base(repository) { }

        protected override async Task PerformExecute(IPage page)
        {
            Console.WriteLine("Verifying login success message...");

             var successMessageLocator = page.Locator("h4:has-text('You have been logged in successfully')");

            // Perform the assertion
            await Assertions.Expect(successMessageLocator).ToBeVisibleAsync();

            Console.WriteLine("Login success message verified successfully.");
        }
    }
}
