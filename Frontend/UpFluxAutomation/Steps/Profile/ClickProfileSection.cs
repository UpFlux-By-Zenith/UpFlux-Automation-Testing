using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps
{
    public class ClickProfileSection : BaseStep
    {
        public ClickProfileSection(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking the Profile button...");

            var page = Repository.Get<IPage>();

            var profileButtonLocator = page.Locator("a[href='/account-settings']:has-text('Profile')");
            await profileButtonLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await profileButtonLocator.ClickAsync();

            Console.WriteLine("Profile button clicked successfully.");
        }
    }
}
