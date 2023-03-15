using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace BlazorViewport;

public abstract class ViewportBase : ComponentBase, IViewport
{
    private Lazy<Task<IJSObjectReference>>? _moduleTask;

    private ViewportOptions ViewportOptions { get; set; } = new ViewportOptions();

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = default!;

    [Inject]
    private IConfiguration Configuration { get; set; } = default!;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public bool IsRendered { get; private set; }

    public Breakpoint Breakpoint { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        var options = Configuration.GetSection("ViewportOptions");
        if (options.Exists())
            options.Bind(ViewportOptions);
        _moduleTask = new(() => JSRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorViewport/blazor-viewport.js").AsTask());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (_moduleTask != null && firstRender)
        {
            var browser = await _moduleTask.Value;
            await Task.Delay(1000);
            await browser.InvokeVoidAsync("initialize", DotNetObjectReference.Create(this), ViewportOptions);
        }
    }

    [JSInvokable]
    public void OnBreakpointChanged(Breakpoint breakpoint)
    {
        Breakpoint = breakpoint;
        if (!IsRendered)
            IsRendered = true;
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
