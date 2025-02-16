using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomation.Steps
{ 
    public class ClickClusterManagementIcon : BaseStep
    {
        public ClickClusterManagementIcon(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking the Cluster Management icon...");

            var page = Repository.Get<IPage>();

            var clusterIconLocator = page.Locator("a.cluster-circle.large-circle");
            await clusterIconLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await clusterIconLocator.ScrollIntoViewIfNeededAsync();
            await clusterIconLocator.ClickAsync();

            Console.WriteLine("Cluster Management icon clicked successfully.");
        }
    }
}
