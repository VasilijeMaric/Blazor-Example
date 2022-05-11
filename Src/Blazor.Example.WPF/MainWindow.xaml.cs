using Blazor.Example.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Example.WPF
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();

            serviceCollection.AddBlazorWebViewDeveloperTools();
            serviceCollection.AddHttpClient();

            Compositions.Initialize(serviceCollection);

            Resources.Add("services", serviceCollection.BuildServiceProvider());
            
            InitializeComponent();
        }
    }
}
