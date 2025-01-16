using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps
{
    public class FillInvalidEngineerDetails : BaseStep
    {
        public FillInvalidEngineerDetails(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Filling Inavalid Engineer Details...");

            var page = Repository.Get<IPage>();
            var engineerData = Repository.Get<EngineerData>();

            // Fill in email
            await page.Locator("input[placeholder='E-mail']").WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await page.Locator("input[placeholder='E-mail']").FillAsync("");

            // Create a temporary JSON file for the token
            var tempFilePath = Path.Combine(Path.GetTempPath(), "engineerToken.json");
            var tokenJson = JsonSerializer.Serialize(new { engineerToken = engineerData.EngineerToken });
            await File.WriteAllTextAsync(tempFilePath, tokenJson);

            // Upload the token JSON file
            await page.Locator("input[type='file']").SetInputFilesAsync(tempFilePath);
            await page.WaitForTimeoutAsync(2800);

            Console.WriteLine("Invalid Engineer Details Filled Successfully.");
        }
    }
}
