using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps.Abstractions;

namespace UpFluxAutomation.Steps
{
    public class ClickLoginButton : BaseStep
    {
        public ClickLoginButton(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute(IPage page)
        {
            Console.WriteLine("Clicking the Login Button...");

            // Perform the click on the login button
            await page.Locator("button:has-text('LOG IN')").ClickAsync();

            Console.WriteLine("Login Button Clicked!");
        }
    }
}
