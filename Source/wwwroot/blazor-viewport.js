let _dotNetRef = null;
let _options = {};
let _breakpoint = null;

export function initialize(caller, options) {
    _dotNetRef = caller;
    _options = options;
    window.onresize = reportBreakpointChanged;
    if (_options.notifyOnInitialize === true) {
        reportBreakpointChanged();
    }
}

export function getBreakpoint() {
    let width = window.innerWidth;
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

function reportBreakpointChanged() {
    let breakpoint = getBreakpoint();
    if(_breakpoint === breakpoint)
        return;
    if(_options.enableLogging) {
        console.log("Breakpoint Changed: Size = " + breakpoint);
    }
    _dotNetRef.invokeMethodAsync("OnBreakpointChanged", breakpoint);
}