using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomation.Steps
{
    public class ClickSimulateButton : BaseStep
    {
        public ClickSimulateButton(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking the 'Simulate' button...");

            var page = Repository.Get<IPage>();

            var simulateButtonLocator = page.Locator("button:has(span.m_811560b9:has-text('Simulate'))");
            await simulateButtonLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await simulateButtonLocator.ClickAsync();

            Console.WriteLine("'Simulate' button clicked successfully.");
        }
    }
}
