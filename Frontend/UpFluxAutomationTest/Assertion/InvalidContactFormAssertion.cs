using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;

namespace UpFluxAutomationTest.Assertion
{
    public class InvalidContactFormAssertion : BaseStep
    {
        public InvalidContactFormAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Verifying Validation message successed...");
            var page = Repository.Get<IPage>();

            var validationMessage = page.Locator("text=Please fill in this field.");

            // Perform the assertion
            await Assertions.Expect(validationMessage).ToBeVisibleAsync();

            Console.WriteLine("Validation message have successed.");
        }
    }
}

