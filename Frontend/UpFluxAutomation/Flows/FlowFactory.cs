using Microsoft.Playwright;
using System;
using UpFluxAutomation.Abstractions;
using UpFluxAutomation.Models;
using UpFluxAutomation.Steps;

namespace UpFluxAutomation.Flows
{
    public static class FlowFactory
    {
        public static IStep CreateFlow(this PredefinedFlow predefinedFlow, IRepository repository)
        {
            IStep flow;

            switch (predefinedFlow)
            {
                case PredefinedFlow.EngineerLogin:

                    flow = new NavigateToLogin(repository);
                    flow.Chain(new FillEngineerDetails(repository))
                        .Chain(new ClickLoginButton(repository));
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(predefinedFlow), predefinedFlow, null);
            }

            return flow;
        }
    }
}
