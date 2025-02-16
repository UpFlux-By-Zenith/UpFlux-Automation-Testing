using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps
{
    public class CLickLogout : BaseStep
    {
        public CLickLogout(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Hovering over Profile and clicking Logout...");

            var page = Repository.Get<IPage>();

            var profileMenuLocator = page.Locator("li.profile a[href='/account-settings']");
            await profileMenuLocator.HoverAsync();
           
            var logoutButtonLocator = page.Locator("a:has-text('Logout')");
            await logoutButtonLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await logoutButtonLocator.ClickAsync();

            Console.WriteLine("Logout clicked successfully.");
        }
    }
}
