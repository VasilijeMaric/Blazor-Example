using Microsoft.AspNetCore.Components;

namespace Blazor.Example.Components.CodeBehind
{
    public class ComplexCounterComponent : ComponentBase
    {
        [Parameter]
        public int Count { get; set; }

        [Parameter] public Func<int, string> TextColorClass { get; set; } = _ => string.Empty; 

        [Parameter]
        public EventCallback<int> CountChanged { get; set; }

        protected async Task IncrementCount(int amount)
        {
            Count += amount;

            await CountChanged.InvokeAsync(Count);
        }
    }
}
