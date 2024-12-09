using Rebus.Pipeline;
using System;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps;

namespace UpFluxAutomation.Flows
{
    public static class FlowFactory
    {
        public static IStep CreateFlow(PredefinedFlow predefinedFlow, MemoryRepository repository)
        {
            IStep flow = null;

            switch (predefinedFlow)
            {
                case PredefinedFlow.EngineerLogin:
                    flow = new NavigateToLoginStep(repository);
                    break;

                // Add cases for other flows here
                default:
                    throw new ArgumentOutOfRangeException(nameof(predefinedFlow), predefinedFlow, null);
            }

            return flow;
        }
    }
}
