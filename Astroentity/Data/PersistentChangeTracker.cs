using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace Astroentity.Data
{
    internal partial class PersistentChangeTracker<T> : 
        ObservableObject
        where T : Record_Base
    {
        [ObservableProperty]
        public ObservableCollection<T>? dataset;

        public PersistentChangeTracker(Microsoft.EntityFrameworkCore.ChangeTracking.LocalView<T> localView)
        {
            Dataset = new ObservableCollection<T>(localView);
            Dataset.CollectionChanged += Dataset_CollectionChanged;

            foreach (var record in Dataset)
            {
                record.PropertyChanging += Record_PropertyChanging;
                record.PropertyChanged += Record_PropertyChanged;
            }
        }

        protected virtual void Dataset_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove &&
                e.OldItems is not null)
            {
                try
                {
                    using DataContext dc = new();
                    dc.RemoveRange(e.OldItems);
                    dc.SaveChanges();
                }
                catch (Exception ex)
                {
                    sbdotnet.Logger.Error(ex);
                }                
            }

            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add &&
                     e.NewItems is not null)
            {
                try
                {
                    using DataContext dc = new();
                    dc.AddRange(e.NewItems);
                    dc.SaveChanges();
                }
                catch (Exception ex)
                {
                    sbdotnet.Logger.Error(ex);
                }
            }
        }

        protected virtual void Record_PropertyChanging(object? sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            
        }

        protected virtual void Record_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (sender is not null)
                {
                    using DataContext dc = new();
                    dc.Update(sender);
                    dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                sbdotnet.Logger.Error(ex);
            }
        }
    }
}
