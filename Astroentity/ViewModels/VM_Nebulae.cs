using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Astroentity.ViewModels
{
    internal partial class VM_Nebulae : ViewModelBase
    {
        [ObservableProperty]
        List<Data.Record_Nebula>? data;

        public VM_Nebulae()
        {
            using Data.DataContext db = new();
            db.Nebulae.Load();
            Data = db.Nebulae.Local.ToList();
        }
    }
}
