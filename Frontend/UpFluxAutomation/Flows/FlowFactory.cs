using Microsoft.Playwright;
using System;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps;
using UpFluxAutomation.Steps.Abstractions;

namespace UpFluxAutomation.Flows
{
    public static class FlowFactory
    {
        public static IStep CreateFlow(this PredefinedFlow predefinedFlow, MemoryRepository repository)
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
