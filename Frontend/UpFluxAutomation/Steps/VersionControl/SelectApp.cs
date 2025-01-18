using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps.VersionControl
{
    public class SelectApp : BaseStep
    {
        public SelectApp(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Select App option...");

            var page = Repository.Get<IPage>();

            var dropdownLocator = page.Locator("input[placeholder='Select App']");
            await dropdownLocator.ClickAsync();

            await page.WaitForSelectorAsync("div[data-combobox-option='true']");
            var appOptionLocator = page.Locator("div[data-combobox-option='true']").Nth(2); 
            await appOptionLocator.ClickAsync();

            Console.WriteLine("App option selected...");
        }
    }
}

