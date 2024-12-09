using Microsoft.Playwright;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace UpFluxAutomation.Steps
{
    public class EngineerLogin
    {
        public async Task Execute(IPage page, string engineerEmail, string engineerToken)
        {
            Console.WriteLine("Starting Engineer Login...");

            // Navigate to login page
            Console.WriteLine("Navigating to login page...");
            await page.GotoAsync("/login");

            // Fill in email
            Console.WriteLine("Filling in email...");
            await page.Locator("input[placeholder='E-mail']").FillAsync(engineerEmail);

            // Create a temporary JSON file for the token
            var tempTokenFilePath = Path.Combine(Path.GetTempPath(), "engineerToken.json");
            var tokenContent = new { engineerToken = engineerToken }; 
            var tokenJson = JsonSerializer.Serialize(tokenContent);
            await File.WriteAllTextAsync(tempTokenFilePath, tokenJson);

            try
            {
                // Upload the token JSON file
                Console.WriteLine("Uploading token file...");
                await page.Locator("input[type='file']").SetInputFilesAsync(tempTokenFilePath);

                // Click the login button
                await page.Locator("button:has-text('LOG IN')").ClickAsync();
                await page.WaitForSelectorAsync("#engineerDashboard");
                Console.WriteLine("Engineer login successful.");
            }
            finally
            {
                // Cleanup: Delete the temporary file
                if (File.Exists(tempTokenFilePath))
                {
                    File.Delete(tempTokenFilePath);
                }
            }
        }
    }
}
