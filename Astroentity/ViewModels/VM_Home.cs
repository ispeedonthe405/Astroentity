using Avalonia;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection;

namespace Astroentity.ViewModels
{
    internal partial class VM_Home : ViewModelBase
    {
        /////////////////////////////////////////////////////////
        #region Properties

        [ObservableProperty]
        string title = App.AppTitle;

        [ObservableProperty]
        string description1 = "A simple demonstration of EntityFramework with SQLite, the MVVM pattern, and Avalonia";

        [ObservableProperty]
        string description2 = "";

        [ObservableProperty]
        WriteableBitmap? headerBitmap;

        #endregion Properties
        /////////////////////////////////////////////////////////
        

        public VM_Home()
        {
            Application.Current!.ActualThemeVariantChanged += App_ActualThemeVariantChanged;
            ReloadImage();
        }

        private void App_ActualThemeVariantChanged(object? sender, System.EventArgs e)
        {
            ReloadImage();
        }

        private void ReloadImage()
        {
            string key = (string)Application.Current!.ActualThemeVariant.Key;
            string resourceName = $"Astroentity.Assets.telescope64{key}.png";

            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (resource is null)
                {
                    sbdotnet.Logger.Warning($"Failed to load {resourceName}");
                    return;
                }

                WriteableBitmap bmp = WriteableBitmap.Decode(resource);
                HeaderBitmap = bmp;
            }
        }
    }
}
