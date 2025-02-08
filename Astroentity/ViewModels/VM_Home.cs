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
        string description1 = string.Empty;

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

            description1 = "This application serves as a simple demo of " +
                            "Entity Framework, SQLite, and Avalonia. It's " +
                            "also a bit of a vanity showcase for my sbavalonia " +
                            "and sbdotnet libs.";

            description2 = "In the Navigation Pane on the left you can " +
                            "view and interact with various tables from " +
                            "the SQLite database. Because this is meant to " +
                            "be a quick demo, the tables feature only a few " +
                            "entries. On the plus side, you do get to make up " +
                            "new stars, nebulae, and galaxies.";
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
