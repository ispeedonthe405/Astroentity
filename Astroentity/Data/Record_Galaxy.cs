using CommunityToolkit.Mvvm.ComponentModel;

namespace Astroentity.Data
{
    internal partial class Record_Galaxy : Record_Base
    {
        [ObservableProperty]
        public string name = string.Empty;

        [ObservableProperty]
        public string description = string.Empty;

        [ObservableProperty]
        public double distance;
    }
}
