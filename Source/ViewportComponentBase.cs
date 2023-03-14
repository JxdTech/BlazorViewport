using Microsoft.AspNetCore.Components;

namespace BlazorViewport;

public abstract class ViewportComponentBase : ComponentBase
{
    [CascadingParameter]
    protected IViewport Viewport { get; set; } = default!;
}