let _dotNetRef = null;
let _options = {};
let _breakpoint = null;

export function initialize(caller, options) {
    _dotNetRef = caller;
    _options = options;
    window.onresize = reportViewportSizeChanged;
    if(_options.notifyOnInitialize === true) {
      reportViewportSizeChanged();
    }
}

export function getViewportSize() {
  var width = window.innerWidth
  height = window.innerHeight;
  return {
    width: width,
    height: height,
    breakpoint: getBreakpoint(width)
  }
} 

function getBreakpoint(width) {
  if (width >= _options.breakpointDefinitions["Xxl"])
      return 5;
  if (width >= _options.breakpointDefinitions["Xl"])
      return 4;
  else if (width >= _options.breakpointDefinitions["Lg"])
      return 3;
  else if (width >= _options.breakpointDefinitions["Md"])
      return 2;
  else if (width >= _options.breakpointDefinitions["Sm"])
      return 1;
  else //Xs
      return 0;
}

function reportViewportSizeChanged() {
    let windowSize = getViewportSize();
    if(_options.notifyOnBreakpointOnly === true && _breakpoint === windowSize.breakpoint) {
        return
    } 
    _breakpoint = windowSize.breakpoint;
    _dotNetRef.invokeMethodAsync("OnViewportSizeChanged", windowSize);
}