using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps
{
    public class FillEngineerDetails : BaseStep
    {
        public FillEngineerDetails(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Filling Engineer Details...");

            var page = Repository.Get<IPage>();
            var engineerData = Repository.Get<EngineerData>();

            // Create a temporary JSON file for the token
            var tempFilePath = Path.Combine(Path.GetTempPath(), "engineerToken.json");
            var tokenJson = JsonSerializer.Serialize(new { engineerToken = engineerData.EngineerToken });
            await File.WriteAllTextAsync(tempFilePath, tokenJson);

            // Upload the token JSON file
            await page.Locator("input[type='file']").SetInputFilesAsync(tempFilePath);

            Console.WriteLine("Engineer Details Filled Successfully.");
        }
    }
}

