let dotNetRef = null;

export function initialize(caller) {
    dotNetRef = caller;
    window.onresize = reportViewportSizeChanged;
}

export function getViewportSize() {
  return {
    width: window.innerWidth,
    height: window.innerHeight
  }
} 

function reportViewportSizeChanged() {
    let windowSize = getViewportSize();
    dotNetRef.invokeMethodAsync("OnViewportSizeChanged", windowSize);
}