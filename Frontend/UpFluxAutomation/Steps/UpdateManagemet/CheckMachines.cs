using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps.UpdateManagemet
{
    public class CheckMachines : BaseStep
    {
        public CheckMachines(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Navigating into Update Management Page...");

            var page = Repository.Get<IPage>();

            // Scroll down the page 
            await page.EvaluateAsync("window.scrollBy(0, window.innerHeight);");

            Console.WriteLine("Update management page showed...");
        }
    }
}
