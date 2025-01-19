using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;

namespace UpFluxAutomationTest.Assertion
{
    public class EngineerLoginAssertion : BaseStep
    {
        public EngineerLoginAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Verifying login successed...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync(); 
            var successMessageLocator = page.Locator("text=Update Management");
            
            // Perform the assertion
            await Assertions.Expect(successMessageLocator).ToBeVisibleAsync();

            Console.WriteLine("Login have successed.");
        }
    }
}

