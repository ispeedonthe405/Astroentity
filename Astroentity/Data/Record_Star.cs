using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Astroentity.Data
{
    [Table("Stars")]
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

        [ObservableProperty]
        public string starSystem = string.Empty;
    }
}
