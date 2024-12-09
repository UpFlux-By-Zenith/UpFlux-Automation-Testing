using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Helpers;

namespace UpFluxAutomation.Steps
{
    public class FillEngineerDetails : BaseStep
    {
        public FillEngineerDetails(MemoryRepository repository) : base(repository) { }

        protected override async Task PerformExecute(IPage page)
        {
            Console.WriteLine("Filling Engineer Details...");
           
            var engineerEmail = Repository.Get<string>("EngineerEmail");
            var engineerToken = Repository.Get<string>("EngineerToken");

            await page.Locator("input[placeholder='E-mail']").FillAsync(engineerEmail);

            var tempFilePath = Path.Combine(Path.GetTempPath(), "engineerToken.json");
            var tokenJson = JsonSerializer.Serialize(new { engineerToken });
            await File.WriteAllTextAsync(tempFilePath, tokenJson);

            await page.Locator("input[type='file']").SetInputFilesAsync(tempFilePath);

            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }

            Console.WriteLine(" Engineer Details Done...");
        }
    }
}
