using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;


namespace UpFluxAutomation.Steps.Dashboard
{
    public class ClickSummitMessageButton : BaseStep
    {
        public ClickSummitMessageButton(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking Summit Message Button...");

            var page = Repository.Get<IPage>();

            //Click the Send Message button
            var sendButtonLocator = page.Locator("button.submit-button:has-text('Send Message')");
            await sendButtonLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await sendButtonLocator.ClickAsync();

            Console.WriteLine("Clicked Summit Message Button successfully.");
        }
    }
}


