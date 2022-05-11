using Blazor.Example.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Example.Shared
{
    public static class Compositions
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddSingleton<StateContainer>();
        }
    }
}
