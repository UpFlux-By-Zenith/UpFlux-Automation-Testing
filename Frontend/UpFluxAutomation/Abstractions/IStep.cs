using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UpFluxAutomation.Abstractions
{
    public interface IStep
    {
        Task Execute();
        IStep Chain(IStep next);
    }
}
