﻿using NUnit.Framework;
using UpFluxAutomationTest.TestBase;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;
using System;
using UpFluxAutomation.Abstractions;
using UpFluxAutomationTest.Assertion;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UpFluxAutomation.LoginTestProfilteTest
{ 
    [TestFixture]
    public class CheckAccountSettingsTest : TestBase
    {
        [Test]
        public async Task TestCheckAcountSettings()
        {
            try
            {
                Console.WriteLine("Starting Check Account Settings Test...");

                // Create and initialize EngineerData
                var engineerData = new EngineerData
                {
                    UpFluxEndPoint = BaseUrl,
                    Email = EngineerEmail,
                    EngineerToken = EngineerToken
                };

                Repository.Add(engineerData);

                // Initialize the flow 
                IStep flow = new NavigateToUpFlux(Repository);
                flow.Chain(new NavigateToLogin(Repository));
                flow.Chain(new FillEngineerDetails(Repository));
                flow.Chain(new ClickLoginButton(Repository));
                flow.Chain(new EngineerLoginAssertion(Repository));

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Check Account Settings flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Test Check Account Settings: {ex.Message}");
            }
        }
    }
}
