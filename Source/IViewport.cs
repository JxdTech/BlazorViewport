namespace BlazorViewport;

public interface IViewport
{
    bool IsRendered { get; }
    Breakpoint Breakpoint { get; }
}
