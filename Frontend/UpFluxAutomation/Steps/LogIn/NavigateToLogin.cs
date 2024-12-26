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
            var engineerData = Repository.Get<EngineerData>();

            if (engineerData == null || string.IsNullOrWhiteSpace(engineerData.UpFluxEndPoint))
            {
                throw new InvalidOperationException("EngineerData or UpFluxEndPoint is missing.");
            }

            await page.GotoAsync(engineerData.UpFluxEndPoint);
            await page.WaitForTimeoutAsync(1000);

            // Click the login link
            await page.Locator("a[href='/login'][data-discover='true']").ClickAsync();

            Console.WriteLine("Login page showed...");
        }
    }
}
