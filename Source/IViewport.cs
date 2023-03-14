namespace BlazorViewport;

public interface IViewport
{
    bool IsRendered { get; }
    ViewportSize ViewportSize { get; }
}
