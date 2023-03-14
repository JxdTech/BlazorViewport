using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorViewport;

public abstract class ViewportBase : ComponentBase, IViewport
{
    private Lazy<Task<IJSObjectReference>>? _moduleTask;

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = default!;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public bool IsRendered { get; private set; }

    public ViewportSize ViewportSize { get; private set; } = new ViewportSize();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _moduleTask = new(() => JSRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorViewport/blazor-viewport.js").AsTask());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (_moduleTask != null && firstRender)
        {
            var browser = await _moduleTask.Value;
            await browser.InvokeVoidAsync("initialize", DotNetObjectReference.Create(this));
            ViewportSize = await browser.InvokeAsync<ViewportSize>("getViewportSize");
            await Task.Delay(2000);
            IsRendered = true;
            StateHasChanged();
        }
    }

    [JSInvokable]
    public void OnViewportSizeChanged(ViewportSize viewportSize)
    {
        ViewportSize = viewportSize;
        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask != null && _moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
