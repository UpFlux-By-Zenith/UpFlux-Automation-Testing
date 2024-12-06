using Microsoft.Playwright;
using NUnit.Framework;

namespace UpFluxAutomationTest.TestBase
{
    public class TestBase
    {
        protected IPage Page;
        protected IBrowser Browser;

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var context = await Browser.NewContextAsync();
            Page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Browser.CloseAsync();
        }
    }
}
