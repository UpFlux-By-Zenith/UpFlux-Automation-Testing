using Microsoft.Playwright;

namespace UpFluxAutomationTest.LoginTest
{
    public class Login
    {
        [Fact]
        public async Task UpFluxHomePage()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://localhost:3000/");
            await page.WaitForTimeoutAsync(2000);
            Assert.Contains("UpFlux", await page.TitleAsync());
            await browser.CloseAsync();
        }
    }
}

//Test Playright setup is working correctly 