using Astroentity.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Astroentity.ViewModels
{
    internal partial class VM_Galaxies : ViewModelBase
    {
        [ObservableProperty]
        DataContext dB = new();

        [ObservableProperty]
        Microsoft.EntityFrameworkCore.ChangeTracking.LocalView<Data.Record_Galaxy>? dataView;

        public VM_Galaxies()
        {
            DB.Galaxies.Load();
            DataView = DB.Galaxies.Local;
        }
    }
}
