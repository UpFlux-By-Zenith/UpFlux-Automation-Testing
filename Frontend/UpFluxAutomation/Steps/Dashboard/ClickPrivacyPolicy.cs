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
    public class ClickPrivacyPolicy : BaseStep
    {
        public ClickPrivacyPolicy(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking Privacy Policy Section");

            var page = Repository.Get<IPage>();

            // Scroll to the bottom of the page
            await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight);");

            // Wait for the link to be fully loaded and visible
            var termsLinkLocator = page.Locator("a.footer-link.mantine-Text-root.mantine-Anchor-root:has-text('Privacy Policy')");
            await termsLinkLocator.ScrollIntoViewIfNeededAsync();
            await termsLinkLocator.ClickAsync(new LocatorClickOptions { Force = true });
            await page.WaitForTimeoutAsync(2000);

            Console.WriteLine("Privacy Policy section Has been Cliked");
        }
    }
}