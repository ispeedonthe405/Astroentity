using Astroentity.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Astroentity.ViewModels
{
    internal partial class VM_Galaxies : ViewModelBase
    {
        [ObservableProperty]
        List<Record_Galaxy>? data = [];

        public VM_Galaxies()
        {
            using Data.DataContext db = new();
            db.Galaxies.Load();
            Data = db.Galaxies.Local.ToList();
        }
    }
}
