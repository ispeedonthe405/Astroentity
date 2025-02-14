using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Astroentity.ViewModels
{
    internal partial class VM_Stars : ViewModelBase
    {
        [ObservableProperty]
        Microsoft.EntityFrameworkCore.ChangeTracking.LocalView<Data.Record_Star>? dataView;

        public VM_Stars()
        {
            Data.DataContext db = new();
            db.Stars.Load();
            DataView = db.Stars.Local;
        }
    }
}
