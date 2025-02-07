using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Astroentity.Data
{
    internal partial class Record_Base : ObservableObject
    {
		/////////////////////////////////////////////////////////
		#region Properties

		[ObservableProperty, Key]
		public int iD;

		#endregion Properties
		/////////////////////////////////////////////////////////

	}
}
