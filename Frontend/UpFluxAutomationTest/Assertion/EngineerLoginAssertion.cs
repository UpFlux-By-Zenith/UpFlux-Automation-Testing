using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps;

namespace UpFluxAutomationTest.Assertion
{
    public class EngineerLoginAssertion : BaseStep
    {
        public EngineerLoginAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Verifying login success message...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var successMessageLocator = page.Locator("h4:has-text('You have been logged in successfully')");

            // Perform the assertion
            await Assertions.Expect(successMessageLocator).ToBeVisibleAsync();

            Console.WriteLine("Login success message verified successfully.");
        }
    }
}

