﻿using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps.Abstractions;

namespace UpFluxAutomation.Steps
{
    public class FillEngineerDetails : BaseStep
    {
        public FillEngineerDetails(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute(IPage page)
        {
            Console.WriteLine("Filling Engineer Details...");

            var engineerData = Repository.Get<EngineerData>();

            // Fill in email
            await page.Locator("input[placeholder='E-mail']").FillAsync(engineerData.Email);

            // Create a temporary JSON file for the token
            var tempFilePath = Path.Combine(Path.GetTempPath(), "engineerToken.json");
            var tokenJson = JsonSerializer.Serialize(new { engineerToken = engineerData.EngineerToken });
            await File.WriteAllTextAsync(tempFilePath, tokenJson);

            // Upload the token JSON file
            await page.Locator("input[type='file']").SetInputFilesAsync(tempFilePath);

            // Clean up the temporary file
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }

            Console.WriteLine("Engineer Details Filled Successfully.");
        }
    }
}
