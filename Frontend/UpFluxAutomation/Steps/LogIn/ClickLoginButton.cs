using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Helpers;

namespace UpFluxAutomation.Steps
{
    public class ClickLoginButton : BaseStep
    {
        public ClickLoginButton(MemoryRepository repository) : base(repository) { }

        protected override async Task PerformExecute(IPage page)
        {
            Console.WriteLine("Clicking the Login Button...");
            await page.Locator("button:has-text('LOG IN')").ClickAsync();
        }
    }
}
