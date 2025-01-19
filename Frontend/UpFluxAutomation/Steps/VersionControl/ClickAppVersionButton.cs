using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps.VersionControl
{ 
    public class ClickAppVersionButton : BaseStep
    {
        public ClickAppVersionButton(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking App Version Button...");

            var page = Repository.Get<IPage>();

            var configureButtonLocator = page.Locator("span.m_80f1301b.mantine-Button-inner >> text='Configure App Version'");
            await configureButtonLocator.ClickAsync();

            Console.WriteLine("App Version Cliked...");
        }
    }
}

