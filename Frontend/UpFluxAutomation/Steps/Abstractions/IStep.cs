using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UpFluxAutomation.Steps.Abstractions
{
    public interface IStep
    {
        Task Execute(IPage page);
        IStep Chain(IStep next);
    }
}
