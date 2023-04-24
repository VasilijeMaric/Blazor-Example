# Blazor Examples and Templates
This repository contains the source-code I used in preparation of my talk "Forget about JavaScript with Blazor" (or the Dutch version: "Nooit meer JavaScript met Blazor").

## Requirements
You need at least Visual Studio 17.3 with MAUI enabled for this solution to work properly.

## Projects
The solution is divided into two sections:
- Templates
- Examples

### Templates
This section demonstrates the different ways to use Blazor using the default templates provided by Microsoft. I made this purely for convenience and reference purposes.

This section is subdivided into the following sections:
- Hybrid contains the templates for [Blazor Hybrid](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-6.0#blazor-hybrid) using MAUI, WinForms and WPF.
- Server contains the template for the [Blazor Server](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-6.0#blazor-server).
- WebAssembly contains the templates for [Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-6.0#blazor-webassembly) using both the Hosted as well as the Standalone model.

NOTE: The Hosted-projects need to have both the Server- and Client-project running, use the ["Multiple Startup projects"-feature](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2022) of Visual Studio to do that.

### Examples
This section demonstrates the use of Blazor in a bunch of different scenarios, just like the Templates above do. 

However, the biggest difference is that all these examples use a single Component-library (`Blazor.Example.Components`) to show-off the possibility to share a code between different target platforms. The components themselves use a plethora of Blazor functionality ranging from a databinding to JavaScript interop.

All the other projects use one or more of these Components in their logic.

Last but not least, there is also the `Blazor.Example.Tests` project to demonstrate how to perform Unit Tests on Components.

NOTE: All example rely on a Controller in the `Blazor.Example.Core` project to demonstrate sharing of state information. Therefore, you need to run `Blazor.Example.Web` alongside the other examples.

## Components
In the paragraph I'll briefly go over all shared Components and their functionality.

### Counter.razor
Counter with an increment button.

### CounterWithParameter.razor
Same counter as above, but this time with a parameter to set the initial value with One-way binding.

### CounterWithBinding.razor
Same counter as above, but this time with a parameter to set the initial value with Two-way binding.

### CounterComplex.razor
Counter with multiple buttons to increment or decrement the value. Has a class-based code-behind and uses bundled styling and assets.

### CounterDemo.razor
Combines all of the above counters into a single component and applies conditional styling based on the counter values.

### JavaScriptInterop.razor
Two buttons that will either call a JavaScript function from .NET, or call a .NET function from JavaScript.

### HelloWorld.razor
Non-form text-input which will echo back its value when submitted.

### Form.razor
Form with two inputs that, once submitted, can have a local state, as well as a server-shared state. 

For demonstration purposes, start the Hybrid WPF, Standalone WebAssembly and the ASP.NET Server at the same time. Then fill out the form on all of them, checking the "Test"-page on all of them between submissions. You'll see that the Component maintains a local state that is not influenced by the server, but also a server-shared state that changes when one of the other forms submit.

## URLs
For convenience, these are the URLs for each of the projects when running.

Examples:
- ASP.NET Server: https://localhost:7443
- Standalone WebAssembly: https://localhost:8443

Templates:
- Server: https://localhost:7443
- WebAssembly Hosted Client / Server: https://localhost:7443 / https://localhost:8443
- WebAssembly Hosted PWA Client / Server: https://localhost:7443 / https://localhost:8443
- Standalone: https://localhost:7443
- Standalone PWA: https://localhost:7443