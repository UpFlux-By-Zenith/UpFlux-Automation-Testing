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

            await page.WaitForTimeoutAsync(1500);

            Console.WriteLine("Invalid Engineer Details Filled Successfully.");
        }
    }
}
