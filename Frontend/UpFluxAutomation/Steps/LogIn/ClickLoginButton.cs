using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Helpers;

namespace UpFluxAutomation.Steps
{
    public class ClickLoginButton : BaseStep
    {
        public ClickLoginButton(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking the Login Button...");

            var page = Repository.Get<IPage>();

            await page.Locator("button:has-text('LOG IN')").ClickAsync();

            Console.WriteLine("Login Button Clicked!");
        }
    }
}
