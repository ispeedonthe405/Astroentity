using CommunityToolkit.Mvvm.ComponentModel;

namespace Astroentity.Data
{
    internal partial class Record_Options : Record_Base
    {
        [ObservableProperty]
        public string themeOverride = "Default";
    }
}
