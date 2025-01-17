using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps.UpdateManagemet
{
    public class ClickViewIcon : BaseStep
    {
        public ClickViewIcon(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking View Button...");

            var page = Repository.Get<IPage>();

            var viewButtonLocator = page.Locator("tr.m_4e7aa4fd.mantine-Table-tr td.m_4e7aa4ef.mantine-Table-td:has(a[data-discover='true'] img.view):nth-match(1)");
            await viewButtonLocator.ClickAsync();

            Console.WriteLine("View Button Cliked...");
        }
    }
}



