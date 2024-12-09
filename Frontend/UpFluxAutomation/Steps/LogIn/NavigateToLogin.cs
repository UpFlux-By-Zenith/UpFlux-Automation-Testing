using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Helpers;

namespace UpFluxAutomation.Steps
{
    public class NavigateToLogin : BaseStep
    {
        public NavigateToLogin(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Navigating to Login Page...");

            var page = Repository.Get<IPage>();

            await page.GotoAsync("/login");

            Console.WriteLine("login page Showed...");
        }
    }
}
