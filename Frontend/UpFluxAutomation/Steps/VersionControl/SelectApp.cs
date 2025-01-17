using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Steps.VersionControl
{
    public class SelectApp : BaseStep
    {
        public SelectApp(IRepository repository, IStep next = null) : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Select App option...");

            var page = Repository.Get<IPage>();

            var secondOptionLocator = page.Locator("role=listbox >> nth=1"); 
            await secondOptionLocator.ClickAsync();

            Console.WriteLine("App option selected...");
        }
    }
}

