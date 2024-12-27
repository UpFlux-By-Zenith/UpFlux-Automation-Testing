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
    public class NavigateToUpFlux: BaseStep
    {
        public NavigateToUpFlux(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Navigating to UpFlux Dashboard...");

            var page = Repository.Get<IPage>();
            var engineerData = Repository.Get<EngineerData>();

            if (engineerData == null || string.IsNullOrWhiteSpace(engineerData.UpFluxEndPoint))
            {
                throw new InvalidOperationException("EngineerData or UpFluxEndPoint is missing.");
            }

            await page.GotoAsync(engineerData.UpFluxEndPoint);
            await page.WaitForTimeoutAsync(1000);

            Console.WriteLine("Dashboard page showed...");
        }
    }
}
