using System.Net.Http.Json;
using Blazor.Example.Shared.Models;
using Blazor.Example.Shared.Services;
#if WEBASSEMBLY
using Blazor.Example.Shared.Services;
#endif
using Microsoft.AspNetCore.Components;

namespace Blazor.Example.Components.CodeBehind
{
    public class FormComponent : ComponentBase
    {
        protected ContactUsModel FormModel { get; set; } = new();

        protected string Result { get; set; }

        [Inject]
        private HttpClient HttpClient { get; set; }

        [Inject]
        private StateContainer StateContainer { get; set; }

        [Inject]
        private IHttpClientFactory HttpClientFactory { get; set; }

        protected async Task HandleValidSubmit()
        {
            Result = $"{FormModel.Name}: {FormModel.Comments}";

            StateContainer.ContactUs = FormModel;

            try
            {
#if WEBASSEMBLY
                await HttpClient.PostAsJsonAsync("https://localhost:7443/Test/ContactUs", FormModel);
#else
                var client = HttpClientFactory.CreateClient();
                await client.PostAsJsonAsync("https://localhost:7443/Test/ContactUs", FormModel);
#endif
            }
            catch
            {
                //Do nothing
            }
        }
    }
}
