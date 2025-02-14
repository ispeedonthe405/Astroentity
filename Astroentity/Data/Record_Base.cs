using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Astroentity.Data
{
    internal partial class Record_Base : ObservableObject
    {
		/////////////////////////////////////////////////////////
		#region Properties

		private int _ID;

		[Key]
		public int ID
		{
			get => _ID;
			set => SetProperty(ref _ID, value, nameof(ID));
		}

		#endregion Properties
		/////////////////////////////////////////////////////////

	}
}
