namespace BlazorViewport;

public class ViewportOptions
{
    public bool EnableLogging { get; set; } = false;

    public bool NotifyOnInitialize { get; set; } = true;

    public Dictionary<Breakpoint, int> Breakpoints { get; set; } = new Dictionary<Breakpoint, int>()
    {
        [Breakpoint.Xxl] = 1400,
        [Breakpoint.Xl] = 1200,
        [Breakpoint.Lg] = 992,
        [Breakpoint.Md] = 768,
        [Breakpoint.Sm] = 576,
        [Breakpoint.Xs] = 0,
    };

}