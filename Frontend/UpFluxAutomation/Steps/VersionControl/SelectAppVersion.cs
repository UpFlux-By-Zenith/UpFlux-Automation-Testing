using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps.VersionControl
{
    public class SelectAppVersion : BaseStep
    {
        public SelectAppVersion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Select App Version option...");

            var page = Repository.Get<IPage>();

            var dropdownVersionLocator = page.Locator("input[placeholder='Select App Version']");
            await dropdownVersionLocator.ClickAsync();

            var selectAppVersionLocator = page.Locator("div.m_92253aa5.mantine-Select-option[data-combobox-option='true']:has-text('Version')").Nth(2);
            await selectAppVersionLocator.ClickAsync();
            await page.WaitForTimeoutAsync(1000);

            Console.WriteLine("App Version option selected...");
        }
    }
}

