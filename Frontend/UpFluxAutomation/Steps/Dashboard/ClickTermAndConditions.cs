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
    public class ClickTermAndConditions : BaseStep
    {
        public ClickTermAndConditions(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking Term And Conditions Button");

            var page = Repository.Get<IPage>();
          
            var termsLinkLocator = page.Locator("a.footer-link.mantine-Text-root.mantine-Anchor-root:has-text('Terms and Conditions')");

            await termsLinkLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await termsLinkLocator.ClickAsync();

            Console.WriteLine("Term And Conditions Button Has been Cliked");
        }
    }
}