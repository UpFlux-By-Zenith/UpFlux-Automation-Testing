using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class VersionControlAssertion : BaseStep
    {
        public VersionControlAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Assert Version Control Page...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var versionControlLocator = page.Locator("text=Version Control");

            // Perform the assertion
            await Assertions.Expect(versionControlLocator).ToBeVisibleAsync();

            Console.WriteLine("Version Control Page have been Asserted.");
        }
    }
}
