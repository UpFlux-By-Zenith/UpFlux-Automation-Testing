using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps
{
    public class SelectClusterOptionFromDropdown : BaseStep
    {
        public SelectClusterOptionFromDropdown(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Selecting the second option from the dropdown...");

            var page = Repository.Get<IPage>();

            var dropdownLocator = page.Locator("input.mantine-Select-input[placeholder='Selection']");
            await dropdownLocator.ClickAsync();

            await page.WaitForSelectorAsync("div[data-combobox-option='true'][role='option']");

            var secondOptionLocator = page.Locator("div[data-combobox-option='true'][role='option']").Nth(1);
            await secondOptionLocator.ClickAsync();

            Console.WriteLine("Second option selected successfully.");
        }
    }
}
