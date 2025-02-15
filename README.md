#Astroentity
This is not intended as an astronomical tool. There had to be a data theme so I chose the sky. That said, there are only a handful of entities in the database.

##Points of interest:
Entity Framework advises that the instance lifetime of a DbContext should correspond to a "unit of work". That is to say, a new instance is created to add, remove, or update one or more records and then that instance is disposed. This means binding directly to a DbSet.Local will result in an error, since the instance of DbSet is disposed along with the DbContext it came from.

A simple bridge between the two can be found here. PersistentChangeTracker<T> uses DbContext.Local to initialize an ObservableCollection<T>. The CollectionChanged and PropertyChanged events are hooked to automatically update the underlying database when records are added, removed, or modified in the bound view.
