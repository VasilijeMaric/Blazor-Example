using System.Net.Http.Json;
using Blazor.Example.Shared.Models;
using Blazor.Example.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Example.Components.CodeBehind
{
    public class FormComponent : ComponentBase
    {
        protected ContactUsModel FormModel { get; set; } = new();

        protected string Result { get; set; }

#if WEBASSEMBLY
        [Inject]
        private HttpClient HttpClient { get; set; }

        [Inject]
        private StateContainer StateContainer { get; set; }
#else
        [Inject]
        private IHttpClientFactory HttpClientFactory { get; set; }
#endif
        protected async Task HandleValidSubmit()
        {
            Result = $"{FormModel.Name}: {FormModel.Comments}";

            try
            {
#if WEBASSEMBLY
            StateContainer.ContactUs = FormModel;

            await HttpClient.PostAsJsonAsync("https://localhost:5443/Test/ContactUs", FormModel);
#else
                var client = HttpClientFactory.CreateClient();
                await client.PostAsJsonAsync("https://localhost:5443/Test/ContactUs", FormModel);
#endif
            }
            catch
            {
                //Do nothing
            }
        }
    }
}
