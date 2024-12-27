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

            // Click the login link
            await page.Locator("a[href='/login'][data-discover='true']").ClickAsync();

            Console.WriteLine("Login page showed...");
        }
    }
}
