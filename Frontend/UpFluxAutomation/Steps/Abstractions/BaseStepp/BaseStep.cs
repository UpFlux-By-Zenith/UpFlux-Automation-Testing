using System.Threading.Tasks;
using Microsoft.Playwright;
using UpFluxAutomation.Helpers;
using UpFluxAutomation.Steps.Abstractions;

namespace UpFluxAutomation.Steps
{
    public abstract class BaseStep : IStep
    {
        protected readonly MemoryRepository Repository;
        private IStep _next;

        protected BaseStep(MemoryRepository repository)
        {
            Repository = repository;
        }

        public IStep Chain(IStep next)
        {
            _next = next;
            return next;
        }

        public async Task Execute(IPage page)
        {
            await PerformExecute(page);

            if (_next != null)
            {
                await _next.Execute(page);
            }
        }

        protected abstract Task PerformExecute(IPage page);
    }
}
