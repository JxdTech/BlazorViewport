namespace BlazorViewport;

public class ViewportOptions
{
    public int ReportRate { get; set; } = 100;

    public bool EnableLogging { get; set; } = true;

    public bool NotifyOnBreakpointOnly { get; set; } = true;

    public bool NotifyOnInitialize { get; set; } = true;

    public Dictionary<Breakpoint, int> BreakpointDefinitions { get; set; } = new Dictionary<Breakpoint, int>()
    {
        [Breakpoint.Xxl] = 1400,
        [Breakpoint.Xl] = 1200,
        [Breakpoint.Lg] = 992,
        [Breakpoint.Md] = 768,
        [Breakpoint.Sm] = 576,
        [Breakpoint.Xs] = 0,
    };

}