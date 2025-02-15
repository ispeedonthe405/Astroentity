using Astroentity.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Astroentity.ViewModels
{
    internal partial class VM_Galaxies : ViewModelBase
    {
        [ObservableProperty]
        PersistentChangeTracker<Record_Galaxy>? tracker;

        public VM_Galaxies()
        {
            using Data.DataContext db = new();
            db.Galaxies.Load();
            Tracker = new(db.Galaxies.Local);
        }
    }
}
