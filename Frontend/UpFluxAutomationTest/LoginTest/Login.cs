using Microsoft.Playwright;

namespace UpFluxAutomationTest.LoginTest
{
    public class Login
    {
        [Fact]
        public async Task TestGoogleHomePage()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://google.com");
            Assert.Contains("Google", await page.TitleAsync());
            await browser.CloseAsync();
        }
    }
}

//Test Playright setup is working correctly 