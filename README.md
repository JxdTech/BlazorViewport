# BlazorViewport
* Monitors viewport resize and reports breakpoint changes.

***
***


### 1.  Install Package
    dotnet add package JxdTech.BlazorViewport 

### 2.  _imports.razor
    @using BlazorViewport 

### 3. App.razor

    // Wrap Contents of App.razor with Viewport
    <Viewport>
        <Router AppAssembly="@typeof(App).Assembly">
            ...
        </Router>
    </Viewport>

### 4. Index.razor / Any Component
    
    @inherits ViewportComponentBase

* contains Viewport:IViewport 
* Viewport has 2 properties
    1) bool IsRendered { get; }
        * Changes to true After JSRuntime is available and event listeners are registeres
    2) Breakpoint Breakpoint { get; }
        * provides current breakpoint
    
### 5. (optional) Customize ViewportOptions in appsettings.json
 
 * Default ViewportOptions

        "ViewportOptions": {

            "EnableLogging": false,

            "NotifyOnInitialize": true,

            "Breakpoints" : {
                "5" : 1400, // Xxl
                "4" : 1200, // Xl
                "3" : 992, // Lg
                "2" : 768, // Md
                "1" : 576, // Sm
                "0" : 0 // Xs
            }
        }

***
***

## Demo Application
View Demo app for simple example
1. App.razor
    * Uses Viewport 
2. Pages/Index.razor
    * implements ViewportComponentBase
3. appsettings.json
    * configures ViewportOptions
4. appsettings.Development.json
    * configures Development ViewportOptions

***

