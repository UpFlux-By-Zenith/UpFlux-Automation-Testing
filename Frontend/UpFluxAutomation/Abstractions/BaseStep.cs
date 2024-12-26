using Microsoft.Playwright;
using System.Threading.Tasks;
using UpFluxAutomation.Models;

namespace UpFluxAutomation.Abstractions
{
    public abstract class BaseStep : IStep
    {
        protected readonly IRepository Repository;
        private IStep _next;

        protected BaseStep(IRepository repository, IStep next = null)
        {
            Repository = repository;
            _next = next;
        }

        public IStep Chain(IStep next)
        {
            _next = next;
            return next;
        }

        public async Task Execute()
        {
            var page = Repository.Get<IPage>();

            await PerformExecute();

            if (_next != null)
            {
                await _next.Execute();
            }
        }
        protected abstract Task PerformExecute();
    }
}
