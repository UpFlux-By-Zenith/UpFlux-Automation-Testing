using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps.UpdateManagemet
{
    public class ClickSmartUpdateButton : BaseStep
    {
        public ClickSmartUpdateButton(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking the Smart Update button...");

            var page = Repository.Get<IPage>();

            var smartUpdateButtonLocator = page.Locator("button.mantine-Button-root:has-text('Smart Update')");
            await smartUpdateButtonLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

            // Click the smart Update button
            await smartUpdateButtonLocator.ClickAsync();

            Console.WriteLine("Smart Update button clicked.");
        }
    }
}

