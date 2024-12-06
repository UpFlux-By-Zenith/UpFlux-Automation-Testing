using System.IO;
using System.Threading.Tasks;
using UpFluxAutomation.Helpers;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Playwright;


namespace UpFluxAutomation.Steps
{
    public class EngineerLogin
    {
        private readonly Repository _repository;

        public EngineerLogin(Repository repository)
        {
            _repository = repository;
        }

        public async Task LoginAsEngineer(IPage page, string tokenFilePath)
        {
            Console.WriteLine("Starting Engineer Login...");
            await page.GotoAsync("/login");

            var engineerData = _repository.GetEngineerData(tokenFilePath);
            await page.Locator("input[placeholder='E-mail']").FillAsync(engineerData.Email);
            await page.Locator("input[type='file']").SetInputFilesAsync(tokenFilePath);
            await page.Locator("button:has-text('LOG IN')").ClickAsync();
            await page.WaitForSelectorAsync("#engineerDashboard"); 
        }
    }
}
