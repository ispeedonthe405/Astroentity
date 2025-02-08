using Astroentity.ViewModels;
using Astroentity.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using sbavalonia.symbols;
using System.Linq;

namespace Astroentity
{
    public partial class App : Application
    {
        public static string AppTitle { get; } = "Astroentity";
        public static string AppVersion { get; } = "1.0.0";
        public static Color DynamicForegroundColor = Colors.Ivory;


        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            SelectDynamicColors();
            sbdotnet.Logger.UseTrace = true;
            ActualThemeVariantChanged += App_ActualThemeVariantChanged;
        }

        private void App_ActualThemeVariantChanged(object? sender, System.EventArgs e)
        {
            SelectDynamicColors();
        }

        private void SelectDynamicColors()
        {
            string key = (string)ActualThemeVariant.Key;
            if (key.Equals("Light"))
            {
                SymbolManager.SymbolColor = Colors.Black;
                DynamicForegroundColor = Colors.Black;
            }
            else
            {
                SymbolManager.SymbolColor = Colors.Ivory;
                DynamicForegroundColor = Colors.Ivory;
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new VM_MainWindow(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}