using Astroentity.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Astroentity.ViewModels
{
    internal partial class VM_Stars : ViewModelBase
    {
        [ObservableProperty]
        PersistentChangeTracker<Data.Record_Star>? tracker;

        public VM_Stars()
        {
            Data.DataContext db = new();
            db.Stars.Load();
            Tracker = new(db.Stars.Local);
        }
    }
}
