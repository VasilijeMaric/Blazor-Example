using Blazor.Example.Shared;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;

namespace Blazor.Example.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddServerSideBlazor();

            services.AddHttpClient();

            //NOTE: Runtime compilation for .razor is currently not supported
            services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                var libraryPath = Path.GetFullPath(
                    Path.Combine(_webHostEnvironment.ContentRootPath, "..", "Blazor.Example.Components")
                );

                options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("DevCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            Compositions.Initialize(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("DevCorsPolicy");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
