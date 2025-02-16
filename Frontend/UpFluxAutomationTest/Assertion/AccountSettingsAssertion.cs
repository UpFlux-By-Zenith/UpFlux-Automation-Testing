using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class AccountSettingsAssertion : BaseStep
    {
        public AccountSettingsAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting Account Settings Page...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var accountSettingsLocator = page.Locator("span.m_811560b9:has-text('Account Settings')");

            // Perform the assertion
            await Assertions.Expect(accountSettingsLocator).ToBeVisibleAsync();

            Console.WriteLine("Account Settings Page have been asserted.");
        }
    }
}

