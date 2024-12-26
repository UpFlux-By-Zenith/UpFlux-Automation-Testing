using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps
{
    public class NavigateToLogin : BaseStep
    {
        public NavigateToLogin(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Navigating to Login Page...");

            var page = Repository.Get<IPage>();
            EngineerData env = this.Repository.Get<EngineerData>();

            await page.GotoAsync(env.UpFluxEndPoint.ToString());
            await page.WaitForTimeoutAsync(1000);
            await page.Locator("a[href='/login'][data-discover='true']").ClickAsync();

            Console.WriteLine("login page Showed...");
        }
    }
}
