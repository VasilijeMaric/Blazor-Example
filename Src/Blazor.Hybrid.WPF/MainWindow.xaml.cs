using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Hybrid.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
            
            InitializeComponent();
        }
    }
}
