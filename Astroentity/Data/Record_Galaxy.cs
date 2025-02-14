using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Astroentity.Data
{
    [Table("Galaxies")]
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
