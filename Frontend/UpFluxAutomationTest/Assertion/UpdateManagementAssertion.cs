using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class UpdateManagementAssertion : BaseStep
    {
        public UpdateManagementAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Verifying Update Management Access...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var UpdateManagementLocator = page.Locator("text=Configure Update");

            // Perform the assertion
            await Assertions.Expect(UpdateManagementLocator).ToBeVisibleAsync();

            Console.WriteLine("Update Management Section have been accessed.");
        }
    }
}

