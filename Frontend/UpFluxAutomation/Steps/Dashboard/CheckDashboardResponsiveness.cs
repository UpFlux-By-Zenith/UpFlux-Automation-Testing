using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps
{
    public class CheckDashboardResponsiveness : BaseStep
    {
        public CheckDashboardResponsiveness(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();
            var engineerData = Repository.Get<EngineerData>();

            var viewports = new Dictionary<string, (int Width, int Height)>
        {
            { "Desktop", (1920, 1000)},
            { "Laptop", (1440, 900) },
            { "Tablet", (768, 1024) },
            { "Mobile", (375, 667) }
        };

            foreach (var viewport in viewports)
            {
                await page.SetViewportSizeAsync(viewport.Value.Width, viewport.Value.Height);
                await page.GotoAsync(engineerData.UpFluxEndPoint);
                await page.WaitForTimeoutAsync(1000);

                Console.WriteLine($"Tested responsiveness on {viewport.Key}");
            }
        }
    }
}