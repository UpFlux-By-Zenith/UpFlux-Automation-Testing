using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;

namespace UpFluxAutomationTest.Assertion
{
    public class InvalidLoginAssertion : BaseStep
    {
        public InvalidLoginAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Verifying Invalid login successed...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var InvaligLoginMessage = page.Locator("text=E-mail or Token not recognised.");

            // Perform the assertion
            await Assertions.Expect(InvaligLoginMessage).ToBeVisibleAsync();

            Console.WriteLine("Invalid Login have successed.");
        }
    }
}

