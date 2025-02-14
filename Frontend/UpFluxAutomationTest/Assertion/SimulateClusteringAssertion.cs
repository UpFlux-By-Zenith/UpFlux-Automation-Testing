using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class SimulateClusteringAssertion : BaseStep
    {
        public SimulateClusteringAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Assert Simulute Clustering ...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var ClusteringLocator = page.Locator("button:has(span.m_811560b9:has-text('Simulate'))");

            // Perform the assertion
            await Assertions.Expect(ClusteringLocator).ToBeVisibleAsync();

            Console.WriteLine("Simulate Clustering Button have been asserted.");
        }
    }
}

