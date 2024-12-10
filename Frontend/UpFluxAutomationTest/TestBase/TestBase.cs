using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;
using UpFluxAutomation.Helpers;

namespace UpFluxAutomationTest.TestBase
{
    public class TestBase
    {
        protected IPage Page;
        protected IBrowser Browser;
        protected IRepository Repository;
        protected string EngineerEmail;
        protected string EngineerToken;

        [SetUp]
        public async Task Setup()
        {
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string baseUrl = configuration["BaseUrl"] ?? throw new Exception("BaseUrl is not configured.");
            EngineerEmail = configuration["EngineerEmail"] ?? throw new Exception("EngineerEmail is not configured.");
            EngineerToken = configuration["EngineerToken"] ?? throw new Exception("EngineerToken is not configured.");

            Console.WriteLine($"BaseUrl: {baseUrl}");
            Console.WriteLine($"EngineerEmail: {EngineerEmail}");
            Console.WriteLine($"EngineerToken: {EngineerToken}");

            // Setup Playwright and Browser
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                BaseURL = baseUrl
            });

            Page = await context.NewPageAsync();

            // Initialize Repository 
            Repository = new MemoryRepository();
            Repository.Add(Page);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
        }
    }
}
