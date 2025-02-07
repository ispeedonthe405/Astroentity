using CommunityToolkit.Mvvm.ComponentModel;

namespace Astroentity.Data
{
    internal partial class Record_Star : Record_Base
    {
        [ObservableProperty]
        public string name = string.Empty;

        [ObservableProperty]
        public string description = string.Empty;

        [ObservableProperty]
        public double distance;

        [ObservableProperty]
        public string stellarClass = string.Empty;
    }
}
