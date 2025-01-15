using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;

namespace UpFluxAutomationTest.Assertion
{
    public class LearnMoreAssertion : BaseStep
    {
        public LearnMoreAssertion(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting Learn More Section...");

            var page = Repository.Get<IPage>();

            await page.WaitForLoadStateAsync();
            var aboutUsHeaderLocator = page.Locator("h3.m_8a5d1357.mantine-Title-root:text('About Us')");

            // Perform the assertion
            await Assertions.Expect(aboutUsHeaderLocator).ToBeVisibleAsync();

            Console.WriteLine("Learn More section have been checked.");
        }
    }
}

