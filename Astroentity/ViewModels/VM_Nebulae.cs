using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Astroentity.ViewModels
{
    internal partial class VM_Nebulae : ViewModelBase
    {
        [ObservableProperty]
        Microsoft.EntityFrameworkCore.ChangeTracking.LocalView<Data.Record_Nebula>? dataView;

        public VM_Nebulae()
        {
            Data.DataContext db = new();
            db.Nebulae.Load();
            DataView = db.Nebulae.Local;
        }
    }
}
