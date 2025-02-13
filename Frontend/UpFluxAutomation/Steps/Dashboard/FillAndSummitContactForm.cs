using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;


namespace UpFluxAutomation.Steps.Dashboard
{
    public class FillAndSummitContactForm : BaseStep
    {
        public FillAndSummitContactForm(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Filling out the contact form...");

            var page = Repository.Get<IPage>();

            await page.WaitForSelectorAsync("input#name");
            await page.WaitForSelectorAsync("input#email");
            await page.WaitForSelectorAsync("textarea#message");

            // Name field
            await page.FillAsync("input#name", "Felix Martinez");

            // Email field
            await page.FillAsync("input#email", "Martinez@upflux.com");

            // Message field
            await page.FillAsync("textarea#message", "This is a test message using UpFlux.");
            await page.WaitForTimeoutAsync(500);

            Console.WriteLine("Form fill successfully.");
        }
    }
}