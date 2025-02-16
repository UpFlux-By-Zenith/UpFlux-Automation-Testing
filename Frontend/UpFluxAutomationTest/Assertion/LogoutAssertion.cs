using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class LogoutAssertion : BaseStep
    {
        public LogoutAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting successful logout...");

            var page = Repository.Get<IPage>();

            await page.WaitForTimeoutAsync(500);
            var welcomeMessageLocator = page.Locator("h1.mantine-Text-root:has-text('Welcome to UpFlux!')");
            await welcomeMessageLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

            //Perform the assertion
            await Assertions.Expect(welcomeMessageLocator).ToBeVisibleAsync();

            Console.WriteLine("Logout have been asserted.");
        }
    }
}

