using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class ClustermanagementAssertion : BaseStep
    {
        public ClustermanagementAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("assert Cluster Management Page...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var ClusterManagementLocator = page.Locator("p.mantine-Text-root:has-text('Cluster Management')");

            // Perform the assertion
            await Assertions.Expect(ClusterManagementLocator).ToBeVisibleAsync();

            Console.WriteLine("Cluster Management Page have been asserted.");
        }
    }
}

