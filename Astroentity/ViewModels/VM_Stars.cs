using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Astroentity.ViewModels
{
    internal partial class VM_Stars : ViewModelBase
    {
        [ObservableProperty]
        List<Data.Record_Star>? data = [];

        public VM_Stars()
        {
            Data.DataContext db = new();
            db.Stars.Load();
            Data = db.Stars.Local.ToList();
        }
    }
}
