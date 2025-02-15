using Astroentity.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Astroentity.ViewModels
{
    internal partial class VM_Nebulae : ViewModelBase
    {
        [ObservableProperty]
        PersistentChangeTracker<Record_Nebula>? tracker;

        public VM_Nebulae()
        {
            using Data.DataContext db = new();
            db.Nebulae.Load();
            Tracker = new(db.Nebulae.Local);
        }
    }
}
