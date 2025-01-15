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
    public class ClickLearnMoreButton : BaseStep
    {
        public ClickLearnMoreButton(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Clicking Learn More Button");

            var page = Repository.Get<IPage>();

            // Locate and click the button by its visible text
            var buttonLocator = page.Locator("span.m_811560b9.mantine-Button-label:text('Learn More')");
            await buttonLocator.ClickAsync();

            Console.WriteLine("Learn More Button Has been Cliked");
        }
    }
}
