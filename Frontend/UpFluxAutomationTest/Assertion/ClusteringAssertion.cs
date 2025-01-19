using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class ClusteringAssertion : BaseStep
    {
        public ClusteringAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("assert Update Clustering Page...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var ClusteringLocator = page.Locator("p.mantine-Text-root:has-text('Network Upload')");

            // Perform the assertion
            await Assertions.Expect(ClusteringLocator).ToBeVisibleAsync();

            Console.WriteLine("Clustering Page have been asserted.");
        }
    }
}

