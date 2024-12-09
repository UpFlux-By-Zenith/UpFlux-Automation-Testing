using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Helpers;

namespace UpFluxAutomation.Steps
{
    public class NavigateToLogin : BaseStep
    {
        public NavigateToLogin(MemoryRepository repository) : base(repository) { }

        protected override async Task PerformExecute(IPage page)
        {
            Console.WriteLine("Navigating to Login Page...");
            await page.GotoAsync("/login");
        }
    }
}
